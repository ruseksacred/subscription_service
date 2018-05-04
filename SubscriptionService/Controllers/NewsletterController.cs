using SubscriptionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SubscriptionService.Controllers
{
    public class NewsletterController : Controller
    {
        private SubscriberContext _db = new SubscriberContext();

        public NewsletterController()
        {
            _db = new SubscriberContext();
        }

        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Newsletter news)
        {
            if(ModelState.IsValid)
            {
                var subscribers = _db.Subscribers;
                List<string> emails = subscribers.Select(u => u.Email).ToList();

                if(emails.Count>0)
                {
                    //Send Email;

                    return View("Send");
                }

                else
                {
                    TempData["Error"] = "Brak osób do wysłania newstsellera";
                    return View();
                }
                
            }
            return View(news);
        }
    }
}