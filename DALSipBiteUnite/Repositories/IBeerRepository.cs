// <copyright file="BeerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DALSipBiteUnite.Repositories
{
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;

    public interface IBeerRepository
    {
        void AddBeer(Beer beer);
        void UpdateBeer(Beer beer);
        void DeleteBeer(int beerId);
        Beer GetBeerById(int beerId);
        List<Beer> GetAllBeers();
    }

    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BeerRepository()
        {
        }

        public void AddBeer(Beer beer)
        {
            _context.Beers.Add(beer);
            _context.SaveChanges();
        }

        public void UpdateBeer(Beer beer)
        {
            _context.Beers.Update(beer);
            _context.SaveChanges();
        }

        public void DeleteBeer(int beerId)
        {
            var beer = _context.Beers.Find(beerId);
            if (beer != null)
            {
                _context.Beers.Remove(beer);
                _context.SaveChanges();
            }
        }

        public Beer GetBeerById(int beerId)
        {
            return _context.Beers.Find(beerId);
        }

        public List<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }
    }
}
