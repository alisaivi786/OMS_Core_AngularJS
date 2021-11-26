using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Helpers
{
    public  static class Messages
    {
        public enum MessageTypes
        {
            [Description("success")] success,
            [Description("error")] error

        }
        public enum GeneralMessages
        {
            [Description("Added successfully.")] Added,
            [Description("Updated successfully.")] Updated,
            [Description("Deleted successfully.")] Deleted,
            [Description("Record Already Exist.")] Already,
            [Description("Fill The Form First.")] Error,
            [Description("Please at least one Record to List.")] AddtoList

        }

        public enum Login
        {
            [Description("Logged in successfully.")] Success,
            [Description("Invalid credentials.")] Invalid,
            [Description("Your account is not active.")] InActive
        }


    }
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
    }
}
