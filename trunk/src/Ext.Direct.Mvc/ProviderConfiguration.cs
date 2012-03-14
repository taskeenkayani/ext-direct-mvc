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
    using System.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class ProviderConfiguration : ConfigurationSection {

        private static ProviderConfiguration _configuration;

        public static ProviderConfiguration GetConfiguration() {
            if (_configuration == null) {
                _configuration = ConfigurationManager.GetSection("ext.direct") as ProviderConfiguration;
            }
            return _configuration ?? (_configuration = new ProviderConfiguration());
        }

        public static JsonConverter GetDefaultDateTimeConverter() {
            string dateFormat = GetConfiguration().DateFormat;
            JsonConverter converter;
            switch (dateFormat.ToLower()) {
                case "js":
                case "javascript":
                    converter = new JavaScriptDateTimeConverter();
                    break;
                case "iso":
                    converter = new IsoDateTimeConverter();
                    break;
                default:
                    converter = null;
                    break;
            }
            return converter;
        } 

        [ConfigurationProperty("name", IsRequired = false, DefaultValue = "Ext.REMOTING_API")]
        public string Name {
            get { return (string)this["name"]; }
        }

        [ConfigurationProperty("namespace", IsRequired = false)]
        public string Namespace {
            get { return (string)this["namespace"]; }
        }

        // Number that specifies the amount of time in milliseconds to wait before sending a batched request.
        // If not specified then the default value, configured by Ext JS will be used, which is 10
        [ConfigurationProperty("buffer", IsRequired = false, DefaultValue = null)]
        public int? Buffer {
            get { return (int?)this["buffer"]; }
        }

        // Number of times to re-attempt delivery on failure of a call.
        // If not specified then the default value, configured by Ext JS will be used, which is 1
        [ConfigurationProperty("maxRetries", IsRequired = false, DefaultValue = null)]
        public int? MaxRetries {
            get { return (int?)this["maxRetries"]; }
        }

        // The timeout to use for each request.
        // If not specified then the default value, configured by Ext JS will be used, which is I don't remember
        [ConfigurationProperty("timeout", IsRequired = false, DefaultValue = null)]
        public int? Timeout {
            get { return (int?)this["timeout"]; }
        }

        [ConfigurationProperty("dateFormat", IsRequired = false, DefaultValue = "Iso")]
        public string DateFormat {
            get { return (string)this["dateFormat"]; }
        }

        [ConfigurationProperty("debug", IsRequired = false, DefaultValue = false)]
        public bool Debug {
            get { return (bool)this["debug"]; }
        }
    }
}
