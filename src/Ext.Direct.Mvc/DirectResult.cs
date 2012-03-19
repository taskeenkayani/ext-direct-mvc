/* ****************************************************************************
 * 
 * Copyright (c) 2012 Eugene Lishnevsky. All rights reserved.
 * 
 * This file is part of Ext.Direct.Mvc.
 *
 * Ext.Direct.Mvc is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Ext.Direct.Mvc is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with Ext.Direct.Mvc.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ***************************************************************************/

namespace Ext.Direct.Mvc {
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Resources;
    using Newtonsoft.Json;

    public class DirectResult : JsonResult {

        public JsonSerializerSettings Settings {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)) {
                throw new InvalidOperationException(DirectResources.JsonRequest_GetNotAllowed);
            }

            HttpResponseBase httpResponse = context.HttpContext.Response;
            var directRequest = context.HttpContext.Items[DirectRequest.DirectRequestKey] as DirectRequest;

            if (directRequest != null) {
                WriteResponse(directRequest, httpResponse);
            } else {
                // Allow regular response when the action is not called through Ext Direct
                WriteContent(httpResponse);
            }
        }

        internal virtual void WriteResponse(DirectRequest directRequest, HttpResponseBase response) {
            var method = DirectProvider.GetCurrent().GetMethod(directRequest.Action, directRequest.Method);
            DirectResponse directResponse;

            if (method.EventName != null) {
                directResponse = new DirectEventResponse(directRequest) {
                    Name = method.EventName,
                    Data = Data,
                    Settings = Settings
                };
            } else {
                directResponse = new DirectDataResponse(directRequest) {
                    Result = Data,
                    Settings = Settings
                };
            }

            directResponse.Write(response, ContentType, ContentEncoding);
        }

        private void WriteContent(HttpResponseBase response) {
            if (!String.IsNullOrEmpty(ContentType)) {
                response.ContentType = ContentType;
            } else {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null) {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null) {
                if (Data is String) {
                    // write strings directly to avoid double quotes around them caused by JsonSerializer
                    response.Write(Data);
                } else {
                    using (JsonWriter writer = new JsonTextWriter(response.Output)) {
                        JsonSerializer serializer = JsonSerializer.Create(Settings);
                        var converter = ProviderConfiguration.GetDefaultDateTimeConverter();
                        if (converter != null) {
                            serializer.Converters.Add(converter);
                        }
#if DEBUG
                        writer.Formatting = Formatting.Indented;
#else
                        writer.Formatting = ProviderConfiguration.GetConfiguration().Debug ? Formatting.Indented : Formatting.None;
#endif
                        serializer.Serialize(writer, Data);
                    }
                }
            }
        }
    }
}
