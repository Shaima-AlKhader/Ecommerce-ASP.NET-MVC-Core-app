using Microsoft.AspNetCore.Mvc;
using EcommerceTeckits.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTickets.Controllers
{
    public class ActorsController : Controller
    {
        DbEntities.ecommerceappdbContext context=new DbEntities.ecommerceappdbContext();

        public IActionResult Index()
        {
            List<Actor> lst = new List<Actor>();
            lst = (from obj in context.Actors.ToList()
                   select new Actor
                   {
                       ActorId = obj.ActorId,
                       ProfilePictureUrl=obj.ProfilePictureUrl,
                       ActorFullName=obj.ActorFullName,
                       ActorBio = obj.ActorBio

                   }).ToList();
            return View(lst);
        }

        //Get: Actors/AddNewActor
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor actor)
        {
            if (actor.ProfilePictureUrl != null && actor.ActorFullName != null
                && actor.ActorBio != null)
            {
                DbEntities.Actor obj = new DbEntities.Actor();

                obj.ActorId= actor.ActorId;
                obj.ProfilePictureUrl = actor.ProfilePictureUrl;
                obj.ActorFullName = actor.ActorFullName;
                obj.ActorBio = actor.ActorBio;

                context.Actors.Add(obj);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(actor);   
        }

        // Get: Actors/Details
        public IActionResult Details(int ID)
        {
            DbEntities.Actor obj= new DbEntities.Actor();   
            obj = context.Actors.Where(x => x.ActorId == ID).FirstOrDefault();

            Actor actor = new Actor();

            actor.ActorId= obj.ActorId;
            actor.ProfilePictureUrl = obj.ProfilePictureUrl;
            actor.ActorFullName = obj.ActorFullName;
            actor.ActorBio = obj.ActorBio;

            if (actor == null) return NotFound();

            return View(actor);
        }

        //Get: Actors/Edit
        public IActionResult Edit(int ID)
        {
            DbEntities.Actor actor = new DbEntities.Actor();
            actor=context.Actors.Where(x => x.ActorId == ID).FirstOrDefault();
            
            Actor actorModel=new Actor();

            actorModel.ActorId = actor.ActorId;
            actorModel.ProfilePictureUrl = actor.ProfilePictureUrl;
            actorModel.ActorFullName = actor.ActorFullName;
            actorModel.ActorBio = actor.ActorBio;

            return View(actorModel);
        }

        [HttpPost]
        public IActionResult Edit (int ID, Actor actor)
        {
            DbEntities.Actor obj = new DbEntities.Actor();
            obj = context.Actors.Where(x => x.ActorId == ID).FirstOrDefault();

       
                obj.ProfilePictureUrl = actor.ProfilePictureUrl;
                obj.ActorFullName = actor.ActorFullName;
                obj.ActorBio = actor.ActorBio;

                context.SaveChanges();

                return RedirectToAction("Index");
           
        }

        public IActionResult DeleteError()
        {
            return View();
        }
        public IActionResult Delete(int ID)
        {
            int count = context.ActorMovies.Where(x => x.ActorId == ID).Count();
            if (count == 0)
            {
                DbEntities.Actor obj = new DbEntities.Actor();
                obj = context.Actors.Where(x => x.ActorId == ID).FirstOrDefault();

                context.Actors.Remove(obj);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
                return RedirectToAction("DeleteError");

            
        }

    }
}
