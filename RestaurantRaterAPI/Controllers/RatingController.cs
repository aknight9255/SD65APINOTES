using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        //POST == create 
        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            if (ModelState.IsValid)
            {
                _context.Ratings.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);

        }
        //GET ALL == Read
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            List<Rating> listOfRatings = await _context.Ratings.ToListAsync();
            return Ok(listOfRatings);
        }
        // GET BY ID
        // PUT == Edit
        //DELETE == Delete
    }
}
