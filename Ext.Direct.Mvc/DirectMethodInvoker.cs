﻿/* ****************************************************************************
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Ext.Direct.Mvc.Resources;

    public class DirectMethodInvoker : ControllerActionInvoker {

        protected override IDictionary<string, object> GetParameterValues(ControllerContext controllerContext, ActionDescriptor actionDescriptor) {
            Dictionary<string, object> parametersDict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            ParameterDescriptor[] parameterDescriptors = actionDescriptor.GetParameters();
            DirectRequest directRequest = controllerContext.HttpContext.Items[DirectRequest.DirectRequestKey] as DirectRequest;

            if (directRequest == null) {
                throw new NullReferenceException(DirectResources.Common_DirectRequestIsNull);
            }

            if (!directRequest.IsFormPost && directRequest.Data != null) {
                controllerContext.Controller.ValueProvider = new DirectValueProvider(directRequest.Data, parameterDescriptors);
            }

            foreach (ParameterDescriptor parameterDescriptor in parameterDescriptors) {
                parametersDict[parameterDescriptor.ParameterName] = GetParameterValue(controllerContext, parameterDescriptor);
            }
            return parametersDict;
        }
    }
}
