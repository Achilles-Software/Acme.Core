using Microsoft.SyndicationFeed;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Achilles.Acme.Models
{
    public class SyndicationFeed
    {
        #region Fields

        #endregion

        #region Properties

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public Uri BaseUri { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public string Language { get; set; }
        public Collection<SyndicationPerson> Authors { get; set; }
        public Uri ImageUrl { get; set; }
        public IEnumerable<SyndicationItem> Items { get; set; } = new List<SyndicationItem>();

        Collection<SyndicationCategory> categories;
        Collection<SyndicationPerson> contributors;
        
        string generator;
       
        Collection<SyndicationLink> links;

        #endregion
    }
}
