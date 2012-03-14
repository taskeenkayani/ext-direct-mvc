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
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Resources;
    using Newtonsoft.Json;

    public class DirectAction {

        private readonly Dictionary<string, DirectMethod> _methods;

        public string Name {
            get;
            private set;
        }

        public DirectAction(Type type) {
            Name = type.Name;
            if (Name.EndsWith("Controller")) {
                Name = Name.Substring(0, Name.IndexOf("Controller", StringComparison.InvariantCultureIgnoreCase));
            }
            _methods = new Dictionary<string, DirectMethod>();
            Configure(type);
        }

        private void Configure(Type type) {
            var methods = type.GetMethods()
                .Where(x =>
                    (x.ReturnType == typeof(ActionResult) || x.ReturnType.IsSubclassOf(typeof(ActionResult))) &&
                    !x.HasAttribute<DirectIgnoreAttribute>()
                );

            foreach (MethodInfo method in methods) {
                var directMethod = new DirectMethod(method);
                if (_methods.ContainsKey(directMethod.Name)) {
                    throw new Exception(String.Format(DirectResources.DirectAction_MethodExists, directMethod.Name, Name));
                }
                _methods.Add(directMethod.Name, directMethod);
            }
        }

        public DirectMethod GetMethod(string name) {
            return _methods.ContainsKey(name) ? _methods[name] : null;
        }

        public void WriteJson(JsonWriter writer) {
            writer.WritePropertyName(Name);
            writer.WriteStartArray();
            foreach (var method in _methods.Values) {
                method.WriteJson(writer);
            }
            writer.WriteEndArray();
        }
    }
}