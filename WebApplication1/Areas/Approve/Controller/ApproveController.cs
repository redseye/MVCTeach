using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Areas.Approve.Controllers
{
    public class ApproveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
