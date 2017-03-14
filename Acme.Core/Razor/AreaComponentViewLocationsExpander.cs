#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Achilles.Acme.Razor
{
    public class AreaViewComponentLocationExpander : IViewLocationExpander
    {
        public void PopulateValues( ViewLocationExpanderContext context )
        {
        }

        public IEnumerable<string> ExpandViewLocations( ViewLocationExpanderContext context, IEnumerable<string> viewLocations )
        {
            var viewComponentArea = context.ActionContext.HttpContext.Items["viewComponentArea"];

            if ( viewComponentArea != null )
            {
                var viewComponentAreaViewLocations = new string[]
                {
                    "/Areas/"+ viewComponentArea + "/Views/{0}.cshtml"
                };

                viewLocations = viewComponentAreaViewLocations.Concat( viewLocations );
            }

            return viewLocations;
        }
    }
}
