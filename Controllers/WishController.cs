using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishAPI.Data;
using WishAPI.Models;

namespace WishAPI.Controllers
{
    [Route("api/wish")]
    public class WishController : ControllerBase
    {
        private readonly IWishRepository _wishRepository;

        public WishController(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Wish>> GetWishes()
        {
            return Ok(_wishRepository.GetWishes());
        }

        [HttpGet("{id}")]
        public ActionResult <Wish> GetWishById(int id)
        {
            var wish = _wishRepository.GetWishById(id);
            if (wish != null)
                return Ok(wish);
            else
                return NotFound();
        }

        [HttpGet("random")]
        public ActionResult <Wish> GetRandomWish()
        {
            return Ok(_wishRepository.GetRandomWish());
        }
    }
}
