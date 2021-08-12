using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Models;

namespace WishAPI.Data
{
    public class MockWishRepository : IWishRepository
    {
        private List<Wish> SampleWishes = new List<Wish>()
        {
            new Wish() {Id=0,Name="A teddy bear"},
            new Wish() {Id=1,Name="A LinkedIn Learning subscription"},
            new Wish() {Id=2,Name="A big fat steak"}
        };

        public Wish GetRandomWish()
        {
            Random rand = new Random();
            return SampleWishes.ElementAt(rand.Next(0, SampleWishes.Count));
        }

        public Wish GetWishById(int id)
        {
            return SampleWishes.Where(w => w.Id == id).FirstOrDefault();
        }

        public IEnumerable<Wish> GetWishes()
        {
            return SampleWishes;
        }
    }
}
