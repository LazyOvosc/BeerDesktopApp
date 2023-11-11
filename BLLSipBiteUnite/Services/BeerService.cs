using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSipBiteUnite.Services
{
    public interface IBeerService
    {
        void AddBeer(Beer beer);
        void UpdateBeer(Beer beer);
        void DeleteBeer(int beerId);
        Beer GetBeerById(int beerId);
        List<Beer> GetAllBeers();
    }

    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public void AddBeer(Beer beerDto)
        {
            _beerRepository.AddBeer(beerDto);
        }

        public void UpdateBeer(Beer beer)
        {
            _beerRepository.UpdateBeer(beer);
        }

        public void DeleteBeer(int beerId)
        {
            _beerRepository.DeleteBeer(beerId);
        }

        public Beer GetBeerById(int beerId)
        {
            return _beerRepository.GetBeerById(beerId);
        }

        public List<Beer> GetAllBeers()
        {
            return _beerRepository.GetAllBeers();

        }
    }
}
