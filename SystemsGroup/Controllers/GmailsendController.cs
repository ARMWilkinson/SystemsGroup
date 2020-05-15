using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemsGroup.Models;
using System.Net.Http;

namespace SystemsGroup.Controllers
{
    public class GmailsendController : Controller
    {
        // GET: Gmailsend
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44314/api/Email");

            var consumewebapi = hc.PostAsJsonAsync<Email>("Email", ec);
            consumewebapi.Wait();

            var sendmail = consumewebapi.Result;
            if(sendmail.IsSuccessStatusCode)
            {
                ViewBag.message = "The mail has been sent to " + ec.to.ToString();
            }
            return View();
        }
    }
}