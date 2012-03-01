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
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Globalization;

    public class DirectValueProviderDictionary : ValueProviderDictionary {

        public DirectValueProviderDictionary(Object[] data, ParameterDescriptor[] parameterDescriptors) : base(null) {
            for (int i = 0; i < parameterDescriptors.Length; i++) {
                object rawValue = data[i];

                if (rawValue != null) {
                    Type vType = rawValue.GetType();
                    Type pType = parameterDescriptors[i].ParameterType;

                    // Deserialize only objects and arrays and let MVC handle everything else.
                    if (vType == typeof(JObject) && pType != typeof(JObject) ||
                        vType == typeof(JArray) && pType != typeof(JArray)) {

                        rawValue = JsonConvert.DeserializeObject(rawValue.ToString(), pType);
                    }
                }

                string attemptedValue = Convert.ToString(rawValue, CultureInfo.InvariantCulture);
                this.Add(parameterDescriptors[i].ParameterName, new ValueProviderResult(rawValue, attemptedValue, CultureInfo.InvariantCulture));
            }
        }

    }
}
