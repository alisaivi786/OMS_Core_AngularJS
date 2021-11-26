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
    public class RoleRepository : IRoles
    {
        private readonly AppDBContext entities;
        private IHttpContextAccessor httpContextAccessor;
        List<object> lmessages = new List<object>();
        public RoleRepository(AppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.entities = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<object> Delete(int id)
        {
            var res = entities.Roles.Find(id);

            res.IsDeleted = true;
            entities.Entry(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entities.SaveChanges();

            lmessages.Add(Messages.GeneralMessages.Deleted.GetDescription());
            lmessages.Add(Messages.MessageTypes.success.GetDescription());

            return lmessages;
        }

        PageData<Roles> IRoles.GetAllRoles(PageInfo pageInfo)
        {
            List<Roles> lRole = new List<Roles>();

            IQueryable<Roles> lsRole;
            if (!string.IsNullOrEmpty(pageInfo.SearchTerm))
                lsRole = entities.Roles.AsQueryable().Where(
                    x => (x.RoleName.ToLower().Contains(pageInfo.SearchTerm.ToLower())
                     && x.IsDeleted == false && x.IsActive == true));
            else
                lsRole = entities.Roles.AsQueryable().Where(x => x.IsActive == true && x.IsDeleted == false);

            switch (pageInfo.SortColumn)
            {
                case "FirstName":
                    if (pageInfo.SortDirection == "ASC")
                        lsRole = lsRole.OrderBy(x => x.RoleName);
                    else
                        lsRole = lsRole.OrderByDescending(x => x.RoleName);
                    break;
               
            }

            
            var plRole = Pagination.PagedResult(lsRole, pageInfo.PageNum, pageInfo.PageSize);
            return plRole;
           
        }

        public Roles GetById(int id)
        {
            return entities.Roles.Find(id);
        }

        public List<object> SaveRole(Roles role)
        {
            try
            {
                role.IsActive = true;
                role.IsDeleted = false;
                role.AddDate = DateTime.Now;
                entities.Add(role);
                entities.SaveChanges();
                lmessages.Add(Messages.GeneralMessages.Added.GetDescription());
                lmessages.Add(Messages.MessageTypes.success.GetDescription());
              
                return lmessages;
            }
            catch (Exception ex)
            {
                lmessages.Add(ex.InnerException.Message);
                lmessages.Add(Messages.MessageTypes.error.GetDescription());

                return lmessages;
            }
        }

        public List<object> UpdateRole(Roles role)
        {
            try
            {
                var res = entities.Roles.Find(role.RoleId);
                res.RoleName = role.RoleName;
                res.Description = role.Description;
                entities.Entry(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                entities.SaveChanges();
                lmessages.Add(Messages.GeneralMessages.Updated.GetDescription());
                lmessages.Add(Messages.MessageTypes.success.GetDescription());

                return lmessages;
            }
            catch (Exception ex)
            {
                lmessages.Add(ex.Message);
                lmessages.Add(Messages.MessageTypes.error.GetDescription());

                return lmessages;
            }
        }
    }
}
