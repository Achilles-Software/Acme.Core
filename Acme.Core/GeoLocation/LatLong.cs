#region Copyright Notice

// Copyright (c) Achilles Software, http://achilles-software.com
//
// The source code contained in this file may not be copied, modified, distributed or
// published by any means without the express written agreement by Achilles Software.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com
//
// All rights reserved.

#endregion

#region Namespaces

using System;

#endregion

namespace Achilles.Acme.GeoLocation
{
    public class LatLong
    {
        #region Constructor(s)

        public LatLong()
        {
            Latitude = 0.0;
            Longitude = 0.0;
        }

        public LatLong( double latitude, double longitude )
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

        #region Properties

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        #endregion
    }
}