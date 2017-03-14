#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Types;
using Microsoft.AspNetCore.Mvc;
using System.Text;

#endregion

namespace Achilles.Acme.Actions
{
    /// <summary>
    /// A vCard version 2.1 action result.
    /// </summary>
    public class vCardResult : ActionResult
    {
        #region Fields

        private vCard _card;

        #endregion

        #region Constructor(s)

        public vCardResult( vCard card )
        {
            _card = card;
        }

        #endregion

        #region Public Methods

        public override void ExecuteResult( ActionContext context )
        {
            var response = context.HttpContext.Response;

            response.ContentType = "text/vcard";
            response.Headers.Add( "Content-Disposition", "attachment; fileName=" + _card.FirstName + "_" + _card.LastName + ".vcf" );

            var cardString = _card.ToString();

            var inputEncoding = Encoding.GetEncoding( 0 ); // Default Encoding;
            var outputEncoding = Encoding.GetEncoding( "windows-1257" );

            var cardBytes = inputEncoding.GetBytes( cardString );

            var outputBytes = Encoding.Convert( inputEncoding, outputEncoding, cardBytes );

            response.Body.Write( outputBytes, 0, outputBytes.Length );
        }

        #endregion
    }
}
