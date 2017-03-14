using Achilles.Acme.Models;

namespace Achilles.Acme.Configuration
{
    public class SiteOptions
    {
        /// <summary>
        /// The website name
        /// </summary>
        public string Name { get; set; } = "Acme";

        /// <summary>
        /// The company name
        /// </summary>
        public string Company { get; set; } = "Your Company Name";

        /// <summary>
        /// The mobile web app name
        /// </summary>
        public string MobileAppName { get; set; } = "Acme Mobile"
;
        public bool UseSSL { get; } = false;

        public string EmailHost { get; set; }

        /// <summary>
        /// Top level domain name
        /// </summary>
        public string TLD { get; set; } = "your-domain.com";

        public string DateFormat { get; set; }

        // FIXME: Move to ???
        public string TwitterAccount { get; set; } = "";

        public string StorageUri { get; set; } = "";
    }
}
