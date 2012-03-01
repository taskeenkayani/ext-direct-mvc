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
    using System.Text;
    using System.Web.Mvc;
    using Ext.Direct.Mvc.Resources;
    using Newtonsoft.Json;

    public class DirectController : Controller {

        protected internal DirectResult Direct(object data) {
            return Direct(data, (string)null);
        }

        protected internal DirectResult Direct(object data, string contentType) {
            return Direct(data, contentType, (Encoding)null);
        }

        protected internal DirectResult Direct(object data, string contentType, Encoding contentEncoding) {
            return Direct(data, contentType, contentEncoding, (JsonSerializerSettings)null);
        }

        protected internal DirectResult Direct(object data, params JsonConverter[] converters) {
            return Direct(data, null, converters);
        }

        protected internal DirectResult Direct(object data, string contentType, params JsonConverter[] converters) {
            return Direct(data, contentType, null, converters);
        }

        protected internal DirectResult Direct(object data, string contentType, Encoding contentEncoding, params JsonConverter[] converters) {
            JsonSerializerSettings settings = (converters != null && converters.Length > 0) ? new JsonSerializerSettings { Converters = converters } : null;
            return Direct(data, contentType, contentEncoding, settings);
        }

        protected internal virtual DirectResult Direct(object data, string contentType, Encoding contentEncoding, JsonSerializerSettings settings) {
            return new DirectResult {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                Settings = settings
            };
        }

        protected internal DirectEventResult DirectEvent(string name) {
            return DirectEvent(name, null);
        }

        protected internal DirectEventResult DirectEvent(string name, object data) {
            return DirectEvent(name, data, (string)null);
        }

        protected internal DirectEventResult DirectEvent(string name, object data, string contentType) {
            return DirectEvent(name, data, contentType, (Encoding)null);
        }

        protected internal DirectEventResult DirectEvent(string name, object data, string contentType, Encoding contentEncoding) {
            return DirectEvent(name, data, contentType, contentEncoding, (JsonSerializerSettings)null);
        }

        protected internal DirectEventResult DirectEvent(string name, object data, params JsonConverter[] converters) {
            return DirectEvent(name, data, null, converters);
        }

        protected internal DirectEventResult DirectEvent(string name, object data, string contentType, params JsonConverter[] converters) {
            return DirectEvent(name, data, contentType, null, converters);
        }

        protected internal DirectEventResult DirectEvent(string name, object data, string contentType, Encoding contentEncoding, params JsonConverter[] converters) {
            JsonSerializerSettings settings = (converters != null && converters.Length > 0) ? new JsonSerializerSettings { Converters = converters } : null;
            return DirectEvent(name, data, contentType, contentEncoding, settings);
        }

        protected internal virtual DirectEventResult DirectEvent(string name, object data, string contentType, Encoding contentEncoding, JsonSerializerSettings settings) {
            if (String.IsNullOrEmpty(name)) {
                throw new ArgumentException(DirectResources.Common_NullOrEmpty, "name");
            }

            return new DirectEventResult {
                Name = name,
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                Settings = settings
            };
        }
    }
}
