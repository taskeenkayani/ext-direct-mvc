/* ****************************************************************************
 * 
 * Copyright (c) 2011 Eugene Lishnevsky. All rights reserved.
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
    using Ext.Direct.Mvc.Configuration;
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

            HttpResponseBase httpResponse = context.HttpContext.Response;
            var directRequest = context.HttpContext.Items[DirectRequest.DirectRequestKey] as DirectRequest;

            if (directRequest != null) {
                this.WriteResponse(directRequest, httpResponse);
            } else {
                // Allow regular response when the action is not called through Ext Direct
                this.WriteContent(httpResponse);
            }
        }

        public virtual void WriteResponse(DirectRequest directRequest, HttpResponseBase httpResponse) {
            var directResponse = new DirectResponse(directRequest) {
                Result = this.Data,
                Settings = this.Settings
            };

            directResponse.Write(httpResponse, this.ContentType, this.ContentEncoding);
        }

        private void WriteContent(HttpResponseBase response) {
            if (!String.IsNullOrEmpty(this.ContentType)) {
                response.ContentType = this.ContentType;
            }
            if (this.ContentEncoding != null) {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data != null) {
                if (this.Data is String) {
                    response.Write(this.Data);
                } else {
                    using (JsonWriter writer = new JsonTextWriter(response.Output)) {
                        JsonSerializer serializer = JsonSerializer.Create(this.Settings);

                        if (DirectConfig.DefaultDateTimeConverter != null) {
                            serializer.Converters.Add(DirectConfig.DefaultDateTimeConverter);
                        }

                        writer.Formatting = DirectConfig.Debug ? Formatting.Indented : Formatting.None;
                        serializer.Serialize(writer, this.Data);
                    }
                }
            }
        }
    }
}
