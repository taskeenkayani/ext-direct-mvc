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
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ext.Direct.Mvc.Resources;

    public class DirectMethodInvoker : ControllerActionInvoker {

        protected override IDictionary<string, object> GetParameterValues(ControllerContext controllerContext, ActionDescriptor actionDescriptor) {
            var directRequest = controllerContext.HttpContext.Items[DirectRequest.DirectRequestKey] as DirectRequest;
            var parametersDict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            ParameterDescriptor[] parameterDescriptors = actionDescriptor.GetParameters();

            if (directRequest == null) {
                throw new NullReferenceException(DirectResources.Common_DirectRequestIsNull);
            }

            if (!directRequest.IsFormPost && directRequest.Data != null) {
#if MVC10
                controllerContext.Controller.ValueProvider = new DirectValueProviderDictionary(directRequest.Data, parameterDescriptors);
#else
                controllerContext.Controller.ValueProvider = new DirectValueProvider(directRequest.Data, parameterDescriptors);
#endif
            }

            foreach (ParameterDescriptor parameterDescriptor in parameterDescriptors) {
                parametersDict[parameterDescriptor.ParameterName] = GetParameterValue(controllerContext, parameterDescriptor);
            }
            return parametersDict;
        }
    }
}
