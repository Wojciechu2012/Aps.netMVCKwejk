using ImageTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTest.Repo
{
    public interface IReviewsRepo
    {
        void AddReviewToImage(Review rev);

        void RemoveReviews(int id);
    }
}
