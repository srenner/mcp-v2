using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        // TODO make this unique but optional, effectively used as a vanity URL
        //public string Username { get; set; }
        
        /// <summary>
        /// e.g. "Tom" or whatever
        /// </summary>
        public string DisplayName { get; set; }
    }
}
