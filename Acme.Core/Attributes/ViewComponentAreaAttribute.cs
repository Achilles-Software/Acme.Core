#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Http;
using System;

#endregion

namespace Achilles.Acme.Attributes
{
    /// <summary>
    /// Specifies a view component's area location.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public class ViewComponentAreaAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="ViewComponentAreaAttribute"/> instance.
        /// </summary>
        /// <param name="areaName">The area containing the view component.</param>
        public ViewComponentAreaAttribute( string areaName )
        {
            if ( string.IsNullOrEmpty( areaName ) )
            {
                throw new ArgumentException( "Area name must not be empty", nameof( areaName ) );
            }

            // Save the view component area name to the HttpContext items collection
            var context = HttpContextAccessorHelper.HttpContext;
            context.Items["viewComponentArea"] = areaName;

            Area = areaName;
        }
        
        /// <summary>
        /// Gets the area of the view component.
        /// </summary>
        public string Area { get; private set; }
    }
}
