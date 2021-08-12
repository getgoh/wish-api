using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Models;

namespace WishAPI.Data
{
    public interface IWishRepository
    {
        public IEnumerable<Wish> GetWishes();
        public Wish GetWishById(int id);
        public Wish GetRandomWish();
    }
}
