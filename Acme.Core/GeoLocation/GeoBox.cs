#region Copyright Notice

// Copyright (c) by Achilles Software, http://achilles-software.com
//
// The source code contained in this file may not be copied, modified, distributed or
// published by any means without the express written agreement by Achilles Software.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com
//
// All rights reserved.

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