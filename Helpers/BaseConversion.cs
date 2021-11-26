using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Helpers
{
    public class BaseConversion
    {
        public static string Convert(int from, int to, string s)
        {
            int int_ = 0;
            if (string.IsNullOrEmpty(s))
            {
                return "Error: Nothing in Input String";
            }
            if (to == 2)
            {
                int_ = 1;
            }
            s = s.ToUpper();
            if (from < 2 || from > 36 || to < 2 || to > 36)
            {
                return "Base requested outside range";
            }
            int length = s.Length;
            int[] arr_ = new int[length];
            int int_2 = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    arr_[int_2++] = (int)(s[i] - '0');
                }
                else
                {
                    if (s[i] < 'A' || s[i] > 'Z')
                    {
                        return "Error: Input string must only contain any of 0-9 or A-Z";
                    }
                    arr_[int_2++] = (int)('\n' + (s[i] - 'A'));
                }
            }
            int[] arr_2 = arr_;
            for (int j = 0; j < arr_2.Length; j++)
            {
                int int_3 = arr_2[j];
                if (int_3 >= from)
                {
                    return "Error: Not a valid number for this input base";
                }
            }
            int int_4 = length * (from / to + 1);
            int[] arr_3 = new int[int_4 + 10];
            int[] arr_4 = new int[int_4 + 10];
            arr_3[0] = 1;
            for (int k = 0; k < length; k++)
            {
                for (int l = 0; l < int_4; l++)
                {
                    arr_4[l] += arr_3[l] * arr_[k];
                    int int_5 = arr_4[l];
                    int int_6 = l;
                    do
                    {
                        int int_7 = int_5 / to;
                        arr_4[int_6] = int_5 - int_7 * to;
                        int_6++;
                        arr_4[int_6] += int_7;
                        int_5 = arr_4[int_6];
                    }
                    while (int_5 >= to);
                }
                for (int m = 0; m < int_4; m++)
                {
                    arr_3[m] *= from;
                }
                for (int n = 0; n < int_4; n++)
                {
                    int int_8 = arr_3[n];
                    int int_9 = n;
                    do
                    {
                        int int_10 = int_8 / to;
                        arr_3[int_9] = int_8 - int_10 * to;
                        int_9++;
                        arr_3[int_9] += int_10;
                        int_8 = arr_3[int_9];
                    }
                    while (int_8 >= to);
                }
            }
            string str_ = string.Empty;
            bool bool_ = false;
            for (int int_11 = int_4; int_11 >= 0; int_11--)
            {
                if (arr_4[int_11] != 0)
                {
                    bool_ = true;
                }
                if (bool_)
                {
                    if (arr_4[int_11] < 10)
                    {
                        str_ += (char)(arr_4[int_11] + 48);
                    }
                    else
                    {
                        str_ += (char)(arr_4[int_11] + 65 - 10);
                    }
                }
            }
            if (string.IsNullOrEmpty(str_))
            {
                return "0";
            }
            if (int_ == 1)
            {
                str_ = "0" + str_;
            }
            return str_;
        }
        public string FormatNumber(decimal Number)
        {
            string res;
            if (Number >= 0)
            {
                res = string.Format("{0:n2}", Number);//.Remove(0, 2);
            }
            else
            {
                res = string.Format("{0:n2}", Number);//.Remove(0, 2);
                res = res.Remove(res.Length - 1, 1);
            }
            return res;
        }
        public decimal truncateDecimalNumber(decimal number, int digits)
        {
            string temp = number.ToString();
            string[] split = temp.Split(new char[] { '.' });
            string strNumber;
            if (split.Length > 1)
            {
                strNumber = split[1];
                strNumber = strNumber[0].ToString() + strNumber[1].ToString() + strNumber[2].ToString() + strNumber[3].ToString();
                strNumber = split[0] + "." + strNumber;
            }
            else
            {
                strNumber = split[0];
            }
            decimal Num = decimal.Parse(strNumber);
            return Num;

        }
        public decimal millionConversion(string nNum)
        {
            decimal num = 0;
            //if(nNum!=null)
            //num=decimal.Parse(nNum, NumberStyles.Number ^ NumberStyles.AllowThousands);
            if (nNum != "")
                num = decimal.Parse(nNum) / 1000000;
            num = Math.Round(num, 3);

            //Adding Comma in million figure
            //string res = string.Format("{0:C}", num.ToString()).Remove(0, 1);
            //num = Convert.ToDecimal(res.ToString());
            //string res = string.Format("{0:#,###,###.##}", num.ToString());
            return num;
        }
    }
}
