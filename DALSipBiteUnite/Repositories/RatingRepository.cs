using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;

namespace DALSipBiteUnite.Repositories
{
    public interface IRatingRepository
    {
        void AddRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int ratingId);
        Rating GetRatingById(int ratingId);
        List<Rating> GetAllRatings();
    }

    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }

        public void UpdateRating(Rating rating)
        {
            _context.Ratings.Update(rating);
            _context.SaveChanges();
        }

        public void DeleteRating(int ratingId)
        {
            var rating = _context.Ratings.Find(ratingId);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                _context.SaveChanges();
            }
        }

        public Rating GetRatingById(int ratingId)
        {
            return _context.Ratings.Find(ratingId);
        }

        public List<Rating> GetAllRatings()
        {
            return _context.Ratings.ToList();
        }
    }
}
