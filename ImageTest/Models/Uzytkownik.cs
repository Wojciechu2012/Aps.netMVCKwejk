using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ImageTest.Models
{
   
        public class Uzytkownik : IdentityUser
        {
        
        public Uzytkownik()
        {
            this.Gallery = new HashSet<ImageGallery>();
        }
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }       

        public virtual ICollection<ImageGallery> Gallery { get; private set; }
        }
    
}