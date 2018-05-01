using SubscriptionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionService.Controllers
{
    public class SubscriberController : Controller
    {
        private SubscriberContext _db = new SubscriberContext();
        
        public SubscriberController()
        {
            _db = new SubscriberContext();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Witaj w serwisie";
            return View();
        }

        public ActionResult List()
        {
            var subscribers = _db.Subscribers;
            return View(subscribers);

        }

        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Subscribe(Subscriber model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var subscriber = _db.Subscribers.FirstOrDefault(u => u.Email.Equals(model.Email));
                    if(subscriber==null)
                    {
                        subscriber = model;
                        subscriber.RegistrationDate = DateTime.Now;

                        _db.Subscribers.Add(subscriber);
                        _db.SaveChanges();
                       
                    }
                    else
                    {
                        TempData["Error"] = "Taki adres już istnieje";
                        return View(model);
                    }
                }
                catch
                {
                    TempData["Error"] = "Wystąpił błąd w aplikacji";
                    return View();
                }

                TempData["Message"] = "Adres został zapisany";
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }

        public ActionResult Unsubscribe()
        {
            return View();

        }

        public ActionResult Unsubscribe(Subscriber model)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    var subscriber = _db.Subscribers.FirstOrDefault(u => u.Email.Equals(model.Email) && u.Name.Equals(model.Name) && u.Surname.Equals(model.Surname));

                    if(subscriber!=null)
                    {
                        _db.Subscribers.Remove(subscriber);
                        _db.SaveChanges();
                    }

                    else
                    {
                        TempData["Error"] = "Brak podanej subskrypcji";
                        return View(model);
                    }



                }

                catch
                {
                    TempData["Error"] = "Wystąpił błąd w aplikacji";
                    return View();
                }

                TempData["Message"] = "Adres email został usunięty poprawnie";
                return RedirectToAction("Index");


            }

            else
            {
                return View(model);
            }
        }
    }
}