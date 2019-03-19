using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class WebApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}