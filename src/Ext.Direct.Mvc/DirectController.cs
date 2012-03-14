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
    using Newtonsoft.Json;

    public class DirectController : Controller {

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding) {
            return Json(data, contentType, contentEncoding, JsonRequestBehavior.DenyGet, null);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior) {
            return Json(data, contentType, contentEncoding, behavior, null);
        }

        protected internal DirectResult Json(object data, params JsonConverter[] converters) {
            return Json(data, null, converters);
        }

        protected internal DirectResult Json(object data, string contentType, params JsonConverter[] converters) {
            return Json(data, contentType, null, converters);
        }
        
        protected internal DirectResult Json(object data, string contentType, Encoding contentEncoding, params JsonConverter[] converters) {
            JsonSerializerSettings settings = (converters != null && converters.Length > 0) ? new JsonSerializerSettings { Converters = converters } : null;
            return Json(data, contentType, contentEncoding, JsonRequestBehavior.DenyGet, settings);
        }

        protected internal virtual DirectResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior, JsonSerializerSettings settings) {
            return new DirectResult {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                Settings = settings,
                JsonRequestBehavior = behavior
            };
        }
    }
}
