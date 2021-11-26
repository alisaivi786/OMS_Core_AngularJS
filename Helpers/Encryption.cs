using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Helpers
{
    public class Encryption
    {
        private static string charToBase2_fixedLength7(char character)
        {
            string str_ = Convert.ToString(Convert.ToByte(character), 2);
            if (str_.Length < 7)
            {
                str_ = "0" + str_;
            }
            return str_;
        }
        private static char base2ToChar(string binaryString)
        {
            if (binaryString[0] == '0')
            {
                binaryString = binaryString.Remove(0, 1);
            }
            byte value = Convert.ToByte(binaryString, 2);
            return Convert.ToChar(value);
        }
        private static string encryptLevel1_encryptToBase2(string userInput)
        {
            string str_ = "";
            for (int i = 0; i < userInput.Length; i++)
            {
                str_ += charToBase2_fixedLength7(userInput[i]);
            }
            return str_;
        }
        private static string decryptLevel1_decryptFromBase2(string inputBinaryString)
        {
            string str_ = "";
            int int_ = 0;
            ArrayList arrayList = new ArrayList();
            int int_2 = inputBinaryString.Length / 7;
            for (int i = 0; i < int_2; i++)
            {
                arrayList.Add(inputBinaryString.Substring(int_, 7));
                int_ += 7;
            }
            for (int j = 0; j < arrayList.Count; j++)
            {
                string varLB0 = str_;
                char chr_ = base2ToChar((string)arrayList[j]);
                str_ = varLB0 + chr_.ToString();
            }
            return str_;
        }
        private static string jumbleUpBinaryString(string mainBinaryString, int randomDigit)
        {
            int i = 0;
            string str_ = charToBase2_fixedLength7(randomDigit.ToString()[0]);
            int int_ = randomDigit;
            string str_2 = str_.Substring(0, int_);
            for (i = int_; i < mainBinaryString.Length; i += int_)
            {
                mainBinaryString = mainBinaryString.Insert(i, str_2);
                i += str_2.Length;
            }
            mainBinaryString = str_ + mainBinaryString;
            return mainBinaryString;
        }
        private static string jumbleDownBinaryString(string mainBinaryString)
        {
            int int_ = 0;
            int i = 0;
            char chr_ = base2ToChar(mainBinaryString.Substring(0, 7));
            int_ = int.Parse(chr_.ToString());
            string str_ = charToBase2_fixedLength7(int_.ToString()[0]);
            string str_2 = str_.Substring(0, int_);
            mainBinaryString = mainBinaryString.Remove(0, 7);
            for (i = int_; i < mainBinaryString.Length; i += int_)
            {
                mainBinaryString = mainBinaryString.Remove(i, str_2.Length);
            }
            return mainBinaryString;
        }
        private static string binaryStringToBaseN(string binaryString)
        {
            int to = 0;
            Random random = new Random();
            to = random.Next(18, 36);
            string str = BaseConversion.Convert(2, to, binaryString);
            string str2 = BaseConversion.Convert(10, 36, to.ToString());
            return str2 + str;
        }
        private static string baseNToBinaryString(string baseNString)
        {
            int varJW0 = 36;
            int varJW1 = 10;
            char chr_ = baseNString[0];
            int from = int.Parse(BaseConversion.Convert(varJW0, varJW1, chr_.ToString()));
            baseNString = baseNString.Remove(0, 1);
            return BaseConversion.Convert(from, 2, baseNString);
        }
        private static string encryptLevel2(string userInput)
        {
            Random random = new Random();
            int randomDigit = random.Next(3, 6);
            string str_ = encryptLevel1_encryptToBase2(userInput);
            str_ = jumbleUpBinaryString(str_, randomDigit);
            return binaryStringToBaseN(str_);
        }
        private static string decryptLevel2(string encryptedString)
        {
            string str_ = baseNToBinaryString(encryptedString);
            str_ = jumbleDownBinaryString(str_);
            return decryptLevel1_decryptFromBase2(str_);
        }
        public static string Encrypt(string UserPassword)
        {
            string str_ = encryptLevel2(UserPassword);
            return str_.Insert(1, "?");
        }
        public static string Decrypt(string EncryptedUserPassword)
        {
            if (EncryptedUserPassword[1] == '?')
            {
                EncryptedUserPassword = EncryptedUserPassword.Remove(1, 1);
                return decryptLevel2(EncryptedUserPassword);
            }
            return "Error: Input was not in proper format";
        }
    }
}
