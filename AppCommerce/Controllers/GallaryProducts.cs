using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCommerce.Controllers
{
    public class GallaryProducts : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
