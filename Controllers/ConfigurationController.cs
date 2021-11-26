using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Models.Context;
using OMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;
using Newtonsoft.Json;
using OMS.Helpers;

namespace OMS.Controllers
{
    public class ConfigurationController : Controller
    {
        private IRoles roles;
        private Roles tblRoles;
        List<object> lMessage = new List<object>();
        public ConfigurationController(IRoles roles)
        {
            this.roles = roles;
        }
        public IActionResult Roles()
        {
            return View();
        }
        //public PartialViewResult LoadRoles()
        //{
        //    var result = roles.GetAllRoles();
        //    return PartialView("LoadRoles", result);
        //}
        public PartialViewResult RolesCrud(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    tblRoles = new Roles();
                    tblRoles.RoleId = 0;
                    return PartialView("RolesCrud", tblRoles);
                }
                else
                {
                    tblRoles = roles.GetById(Id);

                    return PartialView("RolesCrud", tblRoles);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public JsonResult Save(Roles param)
        {
           
            if (param.RoleId == 0)
            {
                lMessage = roles.SaveRole(param);
                
            }
            else
                lMessage = roles.UpdateRole(param);
            
            return Json(JsonConvert.SerializeObject(lMessage));
        }
        public JsonResult GetRoleById(int Id)
        {
            return Json(JsonConvert.SerializeObject(roles.GetById(Id)));
        }

        public JsonResult Delete(int Id)
        {
            lMessage = roles.Delete(Id);

            return Json(JsonConvert.SerializeObject(lMessage));
        }

        public JsonResult GetRoleList(PageInfo param)
        {
            var role = roles.GetAllRoles(param);
            return Json(JsonConvert.SerializeObject(role, Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));

        }
    }
}
