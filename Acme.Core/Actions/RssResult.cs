#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

#endregion

namespace Achilles.Acme.Actions
{
    public class RssResult : ActionResult
    {
        #region Properties/Fields

        public SyndicationFeed RssFeed { get; private set; }

        #endregion

        #region Constructor

        public RssResult( SyndicationFeed rssFeed )
        {
            RssFeed = rssFeed;
        }

        #endregion

        #region Public Methods

        public async override Task ExecuteResultAsync( ActionContext context )
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            using ( var xmlWriter = CreateXmlWriter( context.HttpContext.Response ) )
            {
                var feedWriter = new RssFeedWriter( xmlWriter );

                await feedWriter.WriteTitle( RssFeed.Title );
                await feedWriter.WriteDescription( RssFeed.Description );
                await feedWriter.WriteCopyright( RssFeed.Copyright );
                await feedWriter.WriteLanguage( new System.Globalization.CultureInfo( RssFeed.Language ) );
                await feedWriter.Write( new SyndicationLink( RssFeed.BaseUri ) );

                // Add Items
                foreach ( var item in RssFeed.Items )
                {
                    await feedWriter.Write( item );
                }

                await feedWriter.Flush();
            }
        }

        #endregion

        #region Private Methods

        private XmlWriter CreateXmlWriter( HttpResponse response )
        {
            return XmlWriter.Create( response.Body, new XmlWriterSettings()
            {
                Async = true,
                Encoding = Encoding.UTF8
            } );
        }

        #endregion
    }
}
