#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.GeoLocation;
using System;

#endregion

namespace Achilles.Acme.GeoLocation
{
    public class GeoBoundingBox
    {
        #region Constructor(s)

        public GeoBoundingBox( LatLong lowerBounds, LatLong upperBounds )
        {
            UpperBounds = upperBounds;
            LowerBounds = lowerBounds;
        }

        #endregion

        #region Properties

        public LatLong UpperBounds { get; set; }
        public LatLong LowerBounds { get; set; }

        #endregion
    }
}