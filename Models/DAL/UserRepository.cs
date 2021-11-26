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
    public class UserRepository : IUser
    {
        List<object> lmessages = new List<object>();
        private readonly AppDBContext entities;
        private IHttpContextAccessor httpContextAccessor;
        public UserRepository(AppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.entities = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        IEnumerable<Users> IUser.GetAllUser()
        {
            throw new NotImplementedException();
        }

        List<object> IUser.Authorize(Users users)
        {

            try
            {
                var DecryptPassword2 = Encryption.Decrypt("M?E5HI3AC5F2I9A0J0BF7CBJEC0FEH4");
                var res = entities.Users.Where(x => x.Username.Trim().ToLower() == users.Username.Trim().ToLower()
                                   && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (res != null)
                {
                    var DecryptPassword = Encryption.Decrypt(res.Password);
                    if (DecryptPassword.Trim().ToLower() == users.Password.Trim().ToLower())
                    {
                        httpContextAccessor.HttpContext.Session.SetObjectAsJson("UserDetails", res);
                        lmessages.Add(Messages.Login.Success.GetDescription());
                        lmessages.Add(Messages.MessageTypes.success.GetDescription());
                       
                    }
                    else
                    {
                        lmessages.Add(Messages.Login.Invalid.GetDescription());
                        lmessages.Add(Messages.MessageTypes.error.GetDescription());
                       
                    }

                }
                else
                {
                    lmessages.Add(Messages.Login.Invalid.GetDescription());
                    lmessages.Add(Messages.MessageTypes.error.GetDescription());
                   
                }

            }
            catch (Exception ex)
            {
                lmessages.Add(ex.Message);
                lmessages.Add(Messages.MessageTypes.error.GetDescription());
                
            }
            return lmessages;
        }
       
        public string GetUserThemeSettings(Users user)
        {
            var themeSettings = entities.ThemeSettings.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (themeSettings != null)
            {
                if (themeSettings.ThemeToggle == true)
                {
                    return themeSettings.ThemeWhite;
                }
                else
                    return themeSettings.ThemeDark;
            }
            else
                return "light light-sidebar theme-white";
        }
    }
}
