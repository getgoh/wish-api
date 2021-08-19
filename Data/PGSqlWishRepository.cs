using System;
using System.Collections.Generic;
using System.Linq;
using WishAPI.Models;

namespace WishAPI.Data
{
    public class PGSqlWishRepository : IWishRepository
    {
        private readonly WishContext _context;

        public PGSqlWishRepository(WishContext context)
        {
            _context = context;
        }

        public Wish GetRandomWish()
        {
            Random rand = new Random();
            var nextRand = rand.Next(0, _context.Wishes.Count());
            return _context.Wishes.AsEnumerable().ElementAt(nextRand);
        }

        public Wish GetWishById(int id)
        {
            return _context.Wishes.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Wish> GetWishes()
        {
            return _context.Wishes.ToList();
        }
    }
}
