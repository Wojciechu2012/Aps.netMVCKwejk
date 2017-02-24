using ImageTest.IRepo;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ImageTest.Models
{
    public class ApplicationDbContext : IdentityDbContext<Uzytkownik>, IApplicationDbContext
    {
        
        public ApplicationDbContext(): base("DefaultConnection" )
        {
        }
       
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<ImageGallery> ImageGallery { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
    }




