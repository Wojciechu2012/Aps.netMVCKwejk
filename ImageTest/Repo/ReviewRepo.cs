using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageTest.Models;
using ImageTest.IRepo;

namespace ImageTest.Repo
{
    public class ReviewRepo : IReviewsRepo
    {
        private readonly IApplicationDbContext _db;

        public ReviewRepo(IApplicationDbContext db)
        {
            _db = db;
        }

        public void AddReviewToImage(Review rev)
        {
            _db.Reviews.Add(rev);
            _db.SaveChanges();
        }


        public void RemoveReviews(int id)
        {
            var item = _db.Reviews.Find(id);

            if (item != null)
            {
                _db.Reviews.Remove(item);
                _db.SaveChanges();
            }
            

            
        }
    }
}