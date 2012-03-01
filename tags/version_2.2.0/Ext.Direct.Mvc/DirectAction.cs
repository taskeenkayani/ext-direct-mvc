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
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Ext.Direct.Mvc.Configuration;
    using Ext.Direct.Mvc.Resources;
    using Newtonsoft.Json;

    internal class DirectAction {

        private readonly IDictionary<string, DirectMethod> _methods;

        internal string Name {
            get;
            private set;
        }

        internal static DirectAction Create(Type type) {
            if (type.IsSubclassOf(typeof(Controller))) {
                DirectAction action = null;
                if (DirectConfig.DescriptorGeneration == DescriptorGeneration.OptOut) {
                    if (!type.HasAttribute<DirectIgnoreAttribute>()) {
                        action = new DirectAction(type);
                    }
                } else {
                    action = new DirectAction(type);
                    if (!type.HasAttribute<DirectIncludeAttribute>() && action.MethodCount == 0) {
                        action = null;
                    }
                }
                return action;
            }
            return null;
        }

        private int MethodCount {
            get {
                return _methods.Count();
            }
        }

        // Private constructor.
        // This class can only be instantiated by the static Create method above
        private DirectAction(Type type) {
            this.Name = type.Name;
            if (this.Name.EndsWith("Controller")) {
                this.Name = this.Name.Substring(0, this.Name.IndexOf("Controller"));
            }
            _methods = new Dictionary<string, DirectMethod>();
            ConfigureMethods(type);
        }

        // Returns a configured Direct method by name
        internal DirectMethod GetMethod(string name) {
            return _methods.ContainsKey(name) ? _methods[name] : null;
        }

        // Writes JSON representaion of the action to the specified JsonWriter.
        // Used to generate Ext.Direct API
        internal void WriteJson(JsonWriter jsonWriter) {
            jsonWriter.WritePropertyName(Name);
            jsonWriter.WriteStartArray();
            foreach (var method in _methods.Values) {
                method.WriteJson(jsonWriter);
            }
            jsonWriter.WriteEndArray();
        }

        private void ConfigureMethods(Type type) {
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo mi in methods) {
                bool returnsActionResult = (mi.ReturnType == typeof(ActionResult) || mi.ReturnType.IsSubclassOf(typeof(ActionResult)));

                // In order for a class method to be a Direct method, it must be a controller action, i.e. return ActionResult
                if (returnsActionResult) {
                    DirectMethod method = null;

                    if (DirectConfig.DescriptorGeneration == DescriptorGeneration.OptOut) {
                        if (!mi.HasAttribute<DirectIgnoreAttribute>()) {
                            method = new DirectMethod(mi);
                        }
                    } else if (type.HasAttribute<DirectIncludeAttribute>() || mi.HasAttribute<DirectIncludeAttribute>()) {
                        method = new DirectMethod(mi);
                    }

                    if (method != null) {
                        string name = method.Name;
                        if (_methods.ContainsKey(name)) {
                            throw new Exception(String.Format(DirectResources.DirectAction_MethodExists, name, this.Name));
                        }
                        _methods.Add(name, method);
                    }
                }
            }
        }

    }
}