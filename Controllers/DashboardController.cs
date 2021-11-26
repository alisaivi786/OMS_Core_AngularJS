using Microsoft.AspNetCore.Mvc;
using OMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;

namespace OMS.Controllers
{
    public class DashboardController : Controller
    {
        private IModules modules;
        public DashboardController(IModules modules)
        {
            this.modules = modules;
        }
        public IActionResult Index()
        {
            return  View();
        }

        public IActionResult _NavMenu()
        {
            return PartialView("_NavMenu");
        }
        public IActionResult _SideBar()
        {
            return PartialView("_SideBar",modules);
        }
    }
}
