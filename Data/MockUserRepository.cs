using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Models;

namespace WishAPI.Data
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> MockUsers = new List<User>()
        {
            new User() {
                Id=0, 
                Name="Get", 
                Wishes = new List<Wish> ()
                {
                    new Wish() {Id=0,Name="A teddy bear"},
                    new Wish() {Id=1,Name="A LinkedIn Learning subscription"},
                    new Wish() {Id=2,Name="A big fat steak"}
                }
            }
        };
        public User GetUserById(int id)
        {
            return MockUsers.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
