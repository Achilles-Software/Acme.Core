#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

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