using CleverHiveDiary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CleverHiveDiary.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return View();
            }

            return View();
        }

    }
}