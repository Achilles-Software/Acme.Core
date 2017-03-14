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

using Achilles.Acme.GeoLocation;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Achilles.Acme.GeoLocation
{
    public static class GeoSearch
    {
        public static GeoBoundingBox BoundingBox( double distance, LatLong location ) 
        {
            double lon1 = location.Longitude - distance / Math.Abs( Math.Cos( ToRadians( location.Latitude ) ) * 69 ); 
            double lon2 = location.Longitude + distance / Math.Abs( Math.Cos( ToRadians( location.Latitude ) ) * 69 );
            double lat1 = location.Latitude - ( distance / 69 );
            double lat2 = location.Latitude + ( distance / 69 );

            return new GeoBoundingBox( new LatLong( lat1, lon1 ), new LatLong( lat2, lon2 ) );  
        }

        public static double Proximity( double lat1, double lon1, double lat2, double lon2 )
        {
            // Calculate proximity by using the Spherical law of Cosines algorithm

            lat1 = ToRadians( lat1 );
            lon1 = ToRadians( lon1 );

            lat2 = ToRadians( lat2 );
            lon2 = ToRadians( lon2 );

            double radius = 6371; // km
            double d = Math.Acos( Math.Sin(lat1) * Math.Sin(lat2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Cos(lon2 - lon1)) * radius;

            return d;
        }

        public static double ToRadians( double degrees )
        {
            return degrees * Math.PI / 180;
        }
    }
}