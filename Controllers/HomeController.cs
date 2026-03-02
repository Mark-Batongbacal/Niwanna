using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Niwanna.Data;
using Niwanna.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Niwanna.Controllers
{
    public class HomeController : Controller
    {
        private readonly IponContext _context;
        private const string Passcode = "120219";
        private const string CookieName = "IponAuth";

        public HomeController(IponContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (Request.Cookies[CookieName] != Passcode)
                return RedirectToAction("Login");

            var ipon = _context.Ipons
                        .Include(i => i.Entries)
                        .FirstOrDefault() ?? new Ipon();

            return View(ipon);
        }

        [HttpGet("/ping")]
        public IActionResult Ping()
        {
            Console.WriteLine("Ping received at " + DateTime.Now);
            return Ok("pong");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string passcode)
        {
            if (passcode == Passcode)
            {
                Response.Cookies.Append(CookieName, Passcode, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30)
                });
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Incorrect passcode!";
            return View();
        }

        [HttpPost]
        public IActionResult Add(string Name, int Amount, string Note)
        {
            var ipon = _context.Ipons
                        .Include(i => i.Entries)
                        .FirstOrDefault();

            if (ipon == null)
            {
                ipon = new Ipon();
                _context.Ipons.Add(ipon);
                _context.SaveChanges();
            }

            var entry = new IponEntry
            {
                Name = Name,
                Amount = Amount,
                Note = Note,
                IponId = ipon.IponId
            };

            _context.Entries.Add(entry);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
