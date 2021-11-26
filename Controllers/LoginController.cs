using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Models.Context;
using OMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using OMS.Helpers;

namespace OMS.Controllers
{
    public class LoginController : Controller
    {
        private IUser _user;
        List<object> lMessage = new List<object>();
        public LoginController(IUser user)
        {
            this._user = user;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            TempData[Messages.MessageTypes.success.GetDescription()] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(Users users)
        {

            var lMessage = _user.Authorize(users);
            if (lMessage[1].ToString() == "success")
            {
                TempData[Messages.MessageTypes.success.GetDescription()] = Messages.Login.Success.GetDescription();
                return RedirectToAction("index", "Dashboard");
            }
            else
            {
                TempData[Messages.MessageTypes.error.GetDescription()] = Messages.Login.Invalid.GetDescription();
                return Redirect("Index");
            }
        }
        public IActionResult Logout()
        {
            TempData["success"] = null;
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
