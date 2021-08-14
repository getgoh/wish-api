using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Models;

namespace WishAPI.Data
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
    }
}
