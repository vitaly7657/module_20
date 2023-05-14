using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using module_20.ContextFolder;
using module_20.Entities;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace module_20.Controllers
{
    public class SubscriberController : Controller
    {
        public IActionResult AllView()
        {
            ViewBag.Subscribers = new DataContext().Subscribers;
            return View();
        }

        public IActionResult Delete(int id)
        {
            using (var db = new DataContext())
            {                
                var sub = db.Subscribers.Where(x => x.Id == id).Single<Subscriber>();
                db.Subscribers.Remove(sub);
                db.SaveChanges();
                return View();
            }

        }

        [HttpGet]        
        public IActionResult Details(int id)
        {
            using (var db = new DataContext())
            {
                var sub = db.Subscribers.Where(x => x.Id == id).Single<Subscriber>();
                return View(sub);
            }
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Replace(int id)
        {
            using (var db = new DataContext())
            {
                var sub = db.Subscribers.Where(x => x.Id == id).Single<Subscriber>();
                return View(sub);
            }
        }

        [HttpPost]
        public IActionResult GetDataFromViewField(string name, string surname, string patronymic, string phoneNumber, string address, string description)
        {
            using (var db = new DataContext())
            {
                db.Subscribers.Add(
                    new Entities.Subscriber()
                    {
                        Name = name,
                        Surname = surname,
                        Patronymic = patronymic,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        Description = description
                    });
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        public IActionResult ReplaceDataFromViewField(int id, string name, string surname, string patronymic, string phoneNumber, string address, string description)
        {
            using (var db = new DataContext())
            {
                var sub = db.Subscribers.Where(x => x.Id == id).Single<Subscriber>();
                sub.Id = id;
                sub.Name = name;
                sub.Surname = surname;
                sub.Patronymic = patronymic;
                sub.PhoneNumber = phoneNumber;
                sub.Address = address;
                sub.Description = description;

                db.SaveChanges();
            }
            return Redirect("~/");
        }
    }
}
