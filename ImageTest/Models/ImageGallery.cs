using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImageTest.Models
{
    public class ImageGallery
    {
        [Key]
        public int Id { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        [Required(ErrorMessage ="Please select image")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public string UzytkownikId { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Name should be at least 6 characters.")]
        public string Title { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual ICollection<Review> Reviews { get; private set; }
    }
}