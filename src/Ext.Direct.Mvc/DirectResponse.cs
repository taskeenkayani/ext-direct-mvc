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
    using System.IO;
    using System.Text;
    using System.Web;
    using Newtonsoft.Json;

    [JsonObject]
    public abstract class DirectResponse {

        protected DirectResponse(DirectRequest request) {
            IsFileUpload = request.IsFileUpload;
        }

        [JsonIgnore]
        public bool IsFileUpload {
            get;
            private set;
        }

        [JsonIgnore]
        public JsonSerializerSettings Settings {
            get;
            set;
        }

        public string ToJson() {
            string jsonResponse;
            JsonSerializer serializer = JsonSerializer.Create(Settings);

            var converter = ProviderConfiguration.GetDefaultDateTimeConverter();
            if (converter != null) {
                // Default DateTime converter is added last therefore will not override the
                // one provided by the caller.
                serializer.Converters.Add(converter);
            }

            using (var stringWriter = new StringWriter()) {
                using (var jsonWriter = new JsonTextWriter(stringWriter)) {
#if DEBUG
                    jsonWriter.Formatting = Formatting.Indented;
#else
                    jsonWriter.Formatting = ProviderConfiguration.GetConfiguration().Debug ? Formatting.Indented : Formatting.None;
#endif
                    serializer.Serialize(jsonWriter, this);
                    jsonResponse = stringWriter.ToString();
                }
            }

            return jsonResponse;
        }

        public void Write(HttpResponseBase httpResponse) {
            Write(httpResponse, null, null);
        }

        public void Write(HttpResponseBase httpResponse, string contentType, Encoding contentEncoding) {
            string jsonResponse = ToJson();

            if (IsFileUpload) {
                const string s = "<html><body><textarea>{0}</textarea></body></html>";
                httpResponse.ContentType = "text/html";
                httpResponse.Write(String.Format(s, jsonResponse.Replace("&quot;", "\\&quot;")));
            } else {
                if (!String.IsNullOrEmpty(contentType)) {
                    httpResponse.ContentType = contentType;
                } else {
                    httpResponse.ContentType = "application/json";
                }
                if (contentEncoding != null) {
                    httpResponse.ContentEncoding = contentEncoding;
                }

                httpResponse.Write(jsonResponse);
            }
        }
    }
}
