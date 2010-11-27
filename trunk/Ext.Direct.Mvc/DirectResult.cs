/* ****************************************************************************
 * 
 * Copyright (c) 2010 Eugene Lishnevsky. All rights reserved.
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
    using Ext.Direct.Mvc.Resources;
    using Newtonsoft.Json;
    using Ext.Direct.Mvc.Configuration;

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
                var directResponse = new DirectResponse(directRequest) {
                    Result = this.Data,
                    Settings = this.Settings
                };

                directResponse.Write(httpResponse, ContentType, ContentEncoding);
            } else {
                // Allow regular response when the action is not called through Ext Direct
                using (JsonWriter writer = new JsonTextWriter(httpResponse.Output)) {
                    JsonSerializer serializer = JsonSerializer.Create(this.Settings);

                    if (DirectConfig.DefaultDateTimeConverter != null) {
                        serializer.Converters.Add(DirectConfig.DefaultDateTimeConverter);
                    }

                    writer.Formatting = DirectConfig.Debug ? Formatting.Indented : Formatting.None;
                    serializer.Serialize(writer, Data);
                }
            }
        }
    }
}
