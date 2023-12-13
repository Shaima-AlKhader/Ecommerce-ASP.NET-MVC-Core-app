using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceTeckits.Models;

namespace EcommerceTickets.Controllers
{
    public class ProducersController : Controller
    {
        DbEntities.ecommerceappdbContext context= new DbEntities.ecommerceappdbContext();

        public IActionResult Index()
        {
            List<Producer> lst = new List<Producer>();
            lst = (from obj in context.Producers.ToList()
                   select new Producer
                   {
                       ProducerId=obj.ProducerId,
                       ProfilePictureUrl = obj.ProfilePictureUrl,
                       ProducerFullName = obj.ProducerFullName,
                       ProducerBio= obj.ProducerBio

                   }).ToList();
            return View(lst);
        }
        //Get: Producers/AddNewProducer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producer producer)
        {
            if (producer.ProfilePictureUrl != null && producer.ProducerFullName!= null
                && producer.ProducerBio != null)
            {
                DbEntities.Producer obj = new DbEntities.Producer();

                obj.ProducerId = producer.ProducerId;
                obj.ProfilePictureUrl=producer.ProfilePictureUrl;
                obj.ProducerFullName = producer.ProducerFullName;
                obj.ProducerBio = producer.ProducerBio;

                context.Producers.Add(obj);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // Get: Producers/Details
        public IActionResult Details(int ID)
        {
            DbEntities.Producer obj = new DbEntities.Producer();
            obj = context.Producers.Where(x => x.ProducerId == ID).FirstOrDefault();

            Producer producer = new Producer();

            producer.ProducerId = obj.ProducerId;
            producer.ProfilePictureUrl = obj.ProfilePictureUrl;
            producer.ProducerFullName = obj.ProducerFullName;
            producer.ProducerBio = obj.ProducerBio;

            if (producer == null) return NotFound();

            return View(producer);
        }

        //Get: Actors/Edit
        public IActionResult Edit(int ID)
        {
            DbEntities.Producer producer = new DbEntities.Producer();
            producer = context.Producers.Where(x => x.ProducerId == ID).FirstOrDefault();

            Producer producerModel = new Producer();

            producerModel.ProducerId = producer.ProducerId;
            producerModel.ProfilePictureUrl = producer.ProfilePictureUrl;
            producerModel.ProducerFullName = producer.ProducerFullName;
            producerModel.ProducerBio = producer.ProducerBio;

            return View(producerModel);
        }

        [HttpPost]
        public IActionResult Edit(int ID, Producer producer)
        {
            DbEntities.Producer obj = new DbEntities.Producer();
            obj = context.Producers.Where(x => x.ProducerId == ID).FirstOrDefault();


            obj.ProfilePictureUrl = producer.ProfilePictureUrl;
            obj.ProducerFullName = producer.ProducerFullName;
            obj.ProducerBio = producer.ProducerBio;

            context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult DeleteError()
        {
            return View();
        }
        public IActionResult Delete(int ID)
        {
            int count = context.Movies.Where(x => x.ProducerId == ID).Count();
            if (count == 0)
            {
                DbEntities.Producer obj = new DbEntities.Producer();
                obj = context.Producers.Where(x => x.ProducerId == ID).FirstOrDefault();

                context.Producers.Remove(obj);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("DeleteError");


        }

    }
}
