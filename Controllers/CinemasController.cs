using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceTeckits.Models;

namespace EcommerceTickets.Controllers
{
    public class CinemasController : Controller
    {
        DbEntities.ecommerceappdbContext context=new DbEntities.ecommerceappdbContext();


        public async Task<IActionResult> Index()
        {
            List<Cinema> lst = new List<Cinema>();
            lst = (from obj in context.Cinemas.ToList()
                   select new Cinema
                   {
                      CinemaId = obj.CinemaId,
                      Description=obj.Description,
                      Logo=obj.Logo,
                      CinemaName=obj.CinemaName

                   }).ToList();
            return View(lst);
        }

        //Get: Actors/Edit
        public IActionResult Edit(int ID)
        {
            DbEntities.Cinema cinema = new DbEntities.Cinema();
            cinema = context.Cinemas.Where(x => x.CinemaId == ID).FirstOrDefault();

            Cinema ciemaModel = new Cinema();

            ciemaModel.CinemaId =ID;
            ciemaModel.CinemaName = cinema.CinemaName;
            ciemaModel.Logo = cinema.Logo;
            ciemaModel.Description = cinema.Description;
           
            return View(ciemaModel);
        }

        [HttpPost]
        public IActionResult Edit(int ID, Cinema cinema)
        {
            DbEntities.Cinema obj = new DbEntities.Cinema();
            obj = context.Cinemas.Where(x => x.CinemaId == ID).FirstOrDefault();

            obj.CinemaName=cinema.CinemaName;
            obj.Logo = cinema.Logo;
            obj.Description = cinema.Description;

            context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult DeleteError()
        {
            return View();
        }
        public IActionResult Delete(int ID)
        { 
            int count = context.Movies.Where(x => x.CinemaId == ID).Count();
            if (count == 0)
            {
                DbEntities.Cinema obj = new DbEntities.Cinema();
                obj = context.Cinemas.Where(x => x.CinemaId == ID).FirstOrDefault();

                context.Cinemas.Remove(obj);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("DeleteError");


        }
    }
}
