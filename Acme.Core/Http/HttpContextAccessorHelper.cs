#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Http;

#endregion

namespace Achilles.Acme.Http
{
    public class HttpContextAccessorHelper
    {
        #region Fields

        private static IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Methods

        public static void Configure( IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Properties

        public static HttpContext HttpContext
        {
            get
            {
                return _httpContextAccessor.HttpContext;
            }
        }

        #endregion
    }
}
