using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishAPI.Models
{
    public class Wish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClaimed { get; set; } = false;
    }
}
