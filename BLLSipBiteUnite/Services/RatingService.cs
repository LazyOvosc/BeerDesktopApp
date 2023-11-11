using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSipBiteUnite.Services
{
    public interface IRatingService
    {
        void AddRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int ratingId);
        Rating GetRatingById(int ratingId);
        List<Rating> GetAllRatings();
    }

    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public void AddRating(Rating rating)
        {
            _ratingRepository.AddRating(rating);
        }

        public void UpdateRating(Rating rating)
        {
            _ratingRepository.UpdateRating(rating);
        }

        public void DeleteRating(int ratingId)
        {
            _ratingRepository.DeleteRating(ratingId);
        }

        public Rating GetRatingById(int ratingId)
        {
            return _ratingRepository.GetRatingById(ratingId);
        }

        public List<Rating> GetAllRatings()
        {
            return _ratingRepository.GetAllRatings();
        }
    }
}
