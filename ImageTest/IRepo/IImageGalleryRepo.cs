using ImageTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTest.IRepo
{
    public interface IImageGalleryRepo
    {
        List<ImageGallery> PobierzZdjecia();
        void AddImageToGallery(ImageGallery ig);
        ImageGallery GetPhoto(int id);

        Uzytkownik GetUserName(string id);
        IEnumerable<Review> GetReviews(int id);
        void DeleteImage(int id);
    }
}
