using OMS.Helpers;
using OMS.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Interface
{
    public interface IUser
    {
        IEnumerable<Users> GetAllUser();
        List<object> Authorize(Users users);
        string GetUserThemeSettings(Users user);
    }
}
