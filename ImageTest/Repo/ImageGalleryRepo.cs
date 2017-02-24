using ImageTest.IRepo;
using ImageTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageTest.Repo
{
    public class ImageGalleryRepo:IImageGalleryRepo
    {
        private readonly IApplicationDbContext _db;

        public ImageGalleryRepo (IApplicationDbContext db)
        {
            _db = db;
        }

        public void AddImageToGallery(ImageGallery ig)
        {
            _db.ImageGallery.Add(ig);
            _db.SaveChanges();
        }

        public Uzytkownik GetUserName(string id)
        {
            return _db.Users.Find(id);
        }

        public List<ImageGallery> PobierzZdjecia()
        {
            return _db.ImageGallery.ToList();
        }

        public ImageGallery GetPhoto(int id)
        {
            var item = _db.ImageGallery.Find(id);

            return item;
        }

        public IEnumerable<Review> GetReviews(int id)
        {
            return _db.Reviews.Where(m => m.ImageGalleryId == id).ToList();
        }

        public void DeleteImage(int id)
        {
            var item = _db.ImageGallery.Find(id);
            _db.ImageGallery.Remove(item);
            _db.SaveChanges();
        }

    }
}