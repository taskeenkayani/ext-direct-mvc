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

    internal static class TypeExtensions {

        internal static bool HasAttribute<T>(this Type type) where T : Attribute {
            T attribute = type.GetAttribute<T>();
            return attribute != null;
        }

        internal static T GetAttribute<T>(this Type type) where T : Attribute {
            T attribute = null;
            var attributes = (T[])type.GetCustomAttributes(typeof(T), true);
            if (attributes.Length > 0) {
                attribute = attributes[0];
            }
            return attribute;
        }
    }
}
