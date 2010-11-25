/* ****************************************************************************
 * 
 * Copyright (c) 2010 Eugene Lishnevsky. All rights reserved.
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

    /// <summary>
    /// Specifies client-side descriptor generation option.
    /// </summary>
    public enum DescriptorGeneration {
        /// <summary>
        /// Client-side descriptors are generated for all controller actions. Undesired controllers or actions can be excluded using the <see cref="DirectIgnoreAttribute"/>
        /// </summary>
        OptOut,

        /// <summary>
        /// Client-side descriptors are generated only for controllers and actions marked with the <see cref="DirectIncludeAttribute"/>
        /// </summary>
        OptIn
    }
}
