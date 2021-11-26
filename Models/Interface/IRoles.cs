using OMS.Helpers;
using OMS.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Interface
{
    public interface IRoles
    {

        PageData<Roles> GetAllRoles(PageInfo pageInfo);
        Roles GetById(int id);
        List<object> SaveRole(Roles role);
        List<object> UpdateRole(Roles role);
        List<object> Delete(int id);
    }
}
