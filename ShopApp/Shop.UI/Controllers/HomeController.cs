using Microsoft.AspNetCore.Mvc;
using Shop.UI.Filters;
using Shop.UI.Models;
using System.Diagnostics;

namespace Shop.UI.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}