using Microsoft.AspNetCore.Http;
using OMS.Helpers;
using OMS.Models.Context;
using OMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.DAL
{
    public class ModuleRepository : IModules
    {
        private readonly AppDBContext entities;
        private IHttpContextAccessor httpContextAccessor;
        public ModuleRepository(AppDBContext appDBContext,IHttpContextAccessor httpContextAccessor)
        {
            this.entities = appDBContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IEnumerable<Modules> GelAllModules()
        {
            return entities.Modules.Where(x=>x.IsActive == true && x.IsDeleted == false).ToList();
        }

        public IEnumerable<Pages> GelAllPages()
        {
            return entities.Pages.Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
        }

        public IEnumerable<SubModules> GelAllSubModules()
        {
            return entities.SubModules.Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
        }
    }
}
