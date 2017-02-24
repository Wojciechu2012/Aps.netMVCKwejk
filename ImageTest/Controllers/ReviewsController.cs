using ImageTest.IRepo;
using ImageTest.Repo;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageTest.Models
{
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepo _repo;
        // GET: Reviews

        public ReviewsController(IReviewsRepo repo)
        {
            _repo = repo;
        }   


        //Tworzenie komentarza
        public PartialViewResult Create(int id)
        {
            Review rev = new Review();
            rev.ImageGalleryId = id;
            return PartialView(rev);
        }
               
        [HttpPost]
        public PartialViewResult Create(Review rev)
        {
            if (ModelState.IsValid)
            {
                rev.UzytkownikId = User.Identity.GetUserId();                
                _repo.AddReviewToImage(rev);
            }

            return PartialView();
        }



        //Usuwanie komentarza        
        public ActionResult RemoveReviews(int id,int image)
        {
            _repo.RemoveReviews(id);


            return RedirectToAction("ImageDetails", "ImageGallery",new { id = image });
        }




    }
}