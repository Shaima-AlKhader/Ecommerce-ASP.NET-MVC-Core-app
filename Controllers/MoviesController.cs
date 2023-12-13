using EcommerceTeckits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTickets.Controllers
{
    public class MoviesController : Controller
    {
        DbEntities.ecommerceappdbContext context = new DbEntities.ecommerceappdbContext();

        public IActionResult Index()
        {
            List<Movie> lst = new List<Movie>();

            lst = (from obj in context.Movies.ToList().OrderBy(n => n.MovieName)
                   join _cinema in context.Cinemas.ToList() on obj.CinemaId equals _cinema.CinemaId
                   select new Movie
                   { 
                              ImageUrl = obj.ImageUrl,
                              MovieName=obj.MovieName,
                              Description = obj.Description,
                              Price = (float)obj.Price,
                              StartDate = (DateTime)obj.StartDate,
                              EndDate = (DateTime)obj.EndDate,
                              CinemaName =_cinema.CinemaName,
                            
                    }).ToList();
            return View(lst);
        }
    }
}
