#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Text;

#endregion

namespace Achilles.Acme.Types
{
    public class vCard
    {
        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public string StreetAddress { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public byte[] Image { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine( "BEGIN:VCARD" );
            builder.AppendLine( "VERSION:2.1" );

            // Name
            builder.AppendLine( "N:" + LastName + ";" + FirstName );

            // Full name
            builder.AppendLine( "FN:" + FirstName + " " + LastName );

            // Address
            builder.Append( "ADR;HOME;PREF:;;" );
            builder.Append( StreetAddress + ";" );
            builder.Append( City + ";;" );
            builder.Append( Zip + ";" );
            builder.AppendLine( CountryName );

            // Other data
            builder.AppendLine( "ORG:" + Organization );
            builder.AppendLine( "TITLE:" + JobTitle );
            builder.AppendLine( "TEL;HOME;VOICE:" + Phone );
            builder.AppendLine( "TEL;CELL;VOICE:" + Mobile );
            builder.AppendLine( "URL;" + HomePage );
            builder.AppendLine( "EMAIL;PREF;INTERNET:" + Email );

            builder.AppendLine( "END:VCARD" );

            return builder.ToString();
        }

        #endregion

        #region Future Code Fragment

        // TJT FUTURE..

        //myCard.Image = File.ReadAllBytes("C:\\Images\\me.jpg");

        //using (var file = File.OpenWrite("C:\\Files\\me.vcf"))
        //    using (var writer = new StreamWriter(file))
        //    {
        //        writer.Write(myCard.ToString());
        //    }
        //}

        #endregion
    }
}