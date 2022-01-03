using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCoreProjectApp.Data
{
    public class WebSitePasswordHistory
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime ExpiredDate { get; set; }
        public string Password { get; set; }
        public string WebSitePasswordId { get; set; }

        public WebSitePassword WebSitePassword { get; set; }
    }
}
