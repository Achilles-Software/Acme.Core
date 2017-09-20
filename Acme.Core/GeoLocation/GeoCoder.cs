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

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;

using System.Text.Encodings.Web;
using System.Threading.Tasks;

#endregion

#region Notes:

// http://maps.google.com/maps/geo?q=1600+Amphitheatre+Parkway,+Mountain+View,+CA&output=json&oe=utf8&sensor=true_or_false&key=ABQIAAAAQWfKRYCXqGy_6wTYfmzOJhSQV8z_8xxpUA4V06xXGfr-MqKokRSPKb5_VvZcXJnAtOWQTBVE4y7B3w

//...
//  // Note: you will need to replace the sensor parameter below with either an explicit true or false value.
//  <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true_or_false&amp;key=ABQIAAAAQWfKRYCXqGy_6wTYfmzOJhSQV8z_8xxpUA4V06xXGfr-MqKokRSPKb5_VvZcXJnAtOWQTBVE4y7B3w" type="text/javascript"></script>
//...

// http://maps.googleapis.com/maps/api/geocode/output?parameters

#endregion

namespace Achilles.Acme.GeoLocation
{
    [DataContract]
    public class GeoResponse
    {
        [DataMember( Name = "status" )]
        public string Status { get; set; }
        [DataMember( Name = "results" )]
        public CResult[] Results { get; set; }

        [DataContract]
        public class CResult
        {
            [DataMember( Name = "geometry" )]
            public CGeometry Geometry { get; set; }

            [DataContract]
            public class CGeometry
            {
                [DataMember( Name = "location" )]
                public CLocation Location { get; set; }

                [DataContract]
                public class CLocation
                {
                    [DataMember( Name = "lat" )]
                    public double Lat { get; set; }
                    [DataMember( Name = "lng" )]
                    public double Lng { get; set; }
                }
            }
        }
    }

    /// <summary>
    /// This class uses the Google Maps Geocoding service V3 to convert addresses (like "1600 Amphitheatre Parkway, Mountain View, CA")
    /// into geographic coordinates (like latitude 37.423021 and longitude -122.083739), which can then be used to place markers or position the map.
    /// </summary>
    public class GeoCoder
    {
        #region Fields

        public const string GoogleMapsServiceUrl = "http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false";

        #endregion

        #region Public Methods

        public async Task<GeoResponse> Request( string address )
        {
            string url = String.Format( GoogleMapsServiceUrl, UrlEncoder.Default.Encode( address ) );

            using ( HttpClient client = new HttpClient() )
            {
                using ( HttpResponseMessage response = await client.GetAsync( url ) )
                {
                    //request.Headers.Add( HttpRequestHeader.AcceptEncoding, "gzip,deflate" );
                    //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                    var responseStream = await response.Content.ReadAsStreamAsync();

                    using ( var sr = new StreamReader( responseStream ) )
                    {
                        return JsonConvert.DeserializeObject<GeoResponse>( sr.ReadToEnd() );
                    }
                }
            }
        }

        public async Task<LatLong> Location( string address )
        {
            GeoResponse response;

            try
            {
                response = await Request( address );

                return new LatLong( response.Results[0].Geometry.Location.Lat, response.Results[0].Geometry.Location.Lng );
            }
            catch
            {}

            return new LatLong();
        }

        #endregion
    }
}