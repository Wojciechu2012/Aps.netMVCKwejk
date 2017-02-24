using ImageTest.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTest.IRepo
{
   public interface IApplicationDbContext 
        {
       DbSet<ImageGallery> ImageGallery { get; set; }
       IDbSet<Uzytkownik> Users { get; set; }
        DbSet<Review> Reviews { get; set; }

        int SaveChanges();
        Database Database { get; }

    }
}
