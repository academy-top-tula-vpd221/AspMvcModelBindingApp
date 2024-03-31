using AspMvcModelBindingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspMvcModelBindingApp.Controllers
{
    public class HomeController : Controller
    {
        static List<Meetup> meetups = new List<Meetup>();

        public IActionResult Index()
        {
            return View(meetups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Meetup meetup)
        {
            //meetup.Id = Guid.NewGuid().ToString();
            meetups.Add(meetup);
            return RedirectToAction("Index");
        }
    }
}
