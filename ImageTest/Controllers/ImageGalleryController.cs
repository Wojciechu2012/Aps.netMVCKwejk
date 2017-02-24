using ImageTest.IRepo;
using ImageTest.Models;
using ImageTest.Repo;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageTest.Controllers
{

   
    public class ImageGalleryController : Controller
    {
               
        private readonly IImageGalleryRepo _repo;
        
        public ImageGalleryController(IImageGalleryRepo repo)
        {
            _repo = repo;
        }

        [Route("ImageGallery")]
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var all = _repo.PobierzZdjecia();
            if(page<0 || page > all.ToPagedList(pageNumber, pageSize).PageCount)
            {
                return RedirectToAction("Error","Shared");
                    
            }
            all.Reverse(); 
            
                       
            return View(all.ToPagedList(pageNumber,pageSize));
        }


        [Authorize]
        public ActionResult Upload()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Upload(ImageGallery IG)
        {
            if (ModelState.IsValid) { 


            if (IG.File.ContentLength > (4 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 4MB");
                return View(IG);
            }



            if (!(IG.File.ContentType == "image/jpeg")|| (IG.File.ContentType =="image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed: jpeg and gif");
                return View(IG);
            }


            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;


            byte[] data = new byte[IG.File.ContentLength];

            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);
            IG.ImageData = data;
            IG.UzytkownikId = User.Identity.GetUserId();                     
            _repo.AddImageToGallery(IG);
                return RedirectToAction("Index");
            }
            return View(IG);
        }

        public PartialViewResult GetName(string id)
        {
            var creator = _repo.GetUserName(id);
            return PartialView("~/Views/ImageGallery/_Index.cshtml", creator);
        }

        public ActionResult ImageDetails(int id)
        {
            var item = _repo.GetPhoto(id);
            return View(item);
        }

        public PartialViewResult GetReviews(int id)
        {
            var reviews = _repo.GetReviews(id);
            return PartialView("~/Views/ImageGallery/_Reviews.cshtml",reviews.ToList());
        }

        public RedirectToRouteResult DeleteImage(int id)
        {
            _repo.DeleteImage(id);
            return RedirectToAction("Index");
        }




    }
}