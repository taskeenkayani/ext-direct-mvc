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
    using System.Reflection;
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class DirectMethod {

        public string Name {
            get;
            private set;
        }

        public int Len {
            get;
            private set;
        }

        public string[] Params {
            get;
            private set;
        }

        public bool IsFormHandler {
            get;
            private set;
        }

        public bool UsesNamedArguments {
            get;
            private set;
        }

        public string EventName {
            get;
            private set;
        }

        public DirectMethod(MethodBase method) {
            var actionNameAttr = method.GetAttribute<ActionNameAttribute>();
            Name = actionNameAttr != null ? actionNameAttr.Name : method.Name;

            var directEventAttr = method.GetAttribute<DirectEventAttribute>();
            EventName = directEventAttr != null ? directEventAttr.Name : null;

            var useNamedArgsAttr = method.GetAttribute<NamedArgumentsAttribute>();
            if (useNamedArgsAttr == null) {
                Len = method.GetParameters().Length;
            } else {
                var parameterInfos = method.GetParameters();
                Params = new string[parameterInfos.Length];
                for (int i = 0; i < parameterInfos.Length; i++) {
                    Params[i] = parameterInfos[i].Name;
                }
            }

            IsFormHandler = method.HasAttribute<FormHandlerAttribute>();
            UsesNamedArguments = method.HasAttribute<NamedArgumentsAttribute>();
        }

        public void WriteJson(JsonWriter writer) {
            writer.WriteStartObject();
            writer.WriteProperty("name", Name);

            if (Params != null) {
                writer.WriteProperty("params", Params);
            } else {
                writer.WriteProperty("len", Len);
            }

            if (IsFormHandler) {
                writer.WriteProperty("formHandler", true);
            }

            writer.WriteEndObject();
        }
    }
}
