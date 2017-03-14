#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

#endregion

namespace Achilles.Acme.Actions
{
    public class XmlResult : ActionResult
    {
        #region Properties/Fields

        public XDocument XmlDoc { get; private set; }
        public string ContentType { get; set; }
        public Encoding Encoding { get; set; }

        #endregion

        #region Constructor

        public XmlResult( XDocument xmlDoc )
        {
            XmlDoc = xmlDoc;

            ContentType = "text/xml";
            Encoding = Encoding.UTF8;
        }

        #endregion

        #region Public Methods

        public override void ExecuteResult( ActionContext context )
        {
            context.HttpContext.Response.ContentType = ContentType;

            // TJT: Check this...
            // TODO:
            //context.HttpContext.Response.HeaderEncoding = this.Encoding;

            var writerSettings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding( false ),
                Indent = true,
                IndentChars = "\t"
            };

            using ( XmlWriter writer = XmlWriter.Create( context.HttpContext.Response.Body, writerSettings ) )
            {
                XmlDoc.WriteTo( writer );
            }
        }

        #endregion
    }
}