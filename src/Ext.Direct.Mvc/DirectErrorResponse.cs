﻿/* ****************************************************************************
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
    using System.Collections;
    using Newtonsoft.Json;

    [JsonObject]
    public class DirectErrorResponse : DirectDataResponse {

        public DirectErrorResponse(DirectRequest request, Exception exception) : base(request) {
            ErrorMessage = exception.Message;
            ErrorData = exception.Data.Count > 0 ? exception.Data : null;
#if DEBUG
            Where = GetErrorLocation(exception);
#else
            if (ProviderConfiguration.GetConfiguration().Debug) {
                Where = GetErrorLocation(exception);
            }
#endif
            if (request.IsFormPost) {
                Result = new {success = false};
            }
        }

        [JsonProperty("type")]
        public override string Type {
            get { return "exception"; }
        }

        [JsonProperty("message")]
        public string ErrorMessage {
            get;
            private set;
        }

        [JsonProperty("errorData", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary ErrorData {
            get;
            private set;
        }

        [JsonProperty("where", NullValueHandling = NullValueHandling.Ignore)]
        public string Where {
            get;
            private set;
        }

        private static string GetErrorLocation(Exception exception) {
            return String.Format("{0}\n{1}", exception.GetType(), exception.StackTrace);
        }
    }
}
