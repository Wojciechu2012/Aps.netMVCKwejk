using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageTest.Models
{
    public class Review
    {

        [Key]
        public int Id{get;set;}

        [MinLength(5,ErrorMessage = "Message should be at least 6 characters.")]
        public string Message { get; set; }
        public string UzytkownikId { get; set; }
        public int ImageGalleryId { get; set; }


        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual ImageGallery ImageGallery { get; set; }
    }
}