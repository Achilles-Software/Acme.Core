#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

using System.IO;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <param name="isMainPage"></param>
        /// <returns></returns>
        public static async Task<string> RenderViewToStringAsync( this Controller controller, string viewName = null, object model = null, bool isMainPage = true )
        {
            if ( string.IsNullOrEmpty( viewName ) )
            {
                viewName = (string)controller.RouteData.DataTokens["action"];
            }

            controller.ViewData.Model = model;

            using ( StringWriter sw = new StringWriter() )
            {
                var viewEngine = controller.HttpContext.RequestServices.GetRequiredService<ICompositeViewEngine>();

                ViewEngineResult viewResult = viewEngine.FindView( controller.ControllerContext, viewName, isMainPage );

                ViewContext viewContext = new ViewContext( controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw, new HtmlHelperOptions() );

                await viewResult.View.RenderAsync( viewContext );

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
