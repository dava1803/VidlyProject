using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VidlyProject.Dtos;
using VidlyProject.Models;

namespace VidlyProject.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailabe == 0)
                    return BadRequest("Movie is not available.");
                movie.NumberAvailabe--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
 
            }
            return Ok();
        }
    }
}