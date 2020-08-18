using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserAuth
{
    class modelUserAuth
    {
        public string password;
        public int addPoints;

        public string checkPasswordLenght()
        {
            int lenght= password.Length;

            if (password.Length <= 6)
            {
                return "password is too short";
            }
            else if (password.Length >= 25)
            {
               return "password is too long";
            }
            else
            {
                addPoints = addPoints + 1;
                return "password's lenght ok";
            }
        }

        //public string PasswordLow()
        //{
        //    bool isOnlyLower = password.Count(c => Char.IsLower(c)) == password.Length;
            
        //    if (isOnlyLower == true)
        //    {
        //        return "password shouldn't contain only lower chars";
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        //public string PasswordUpp()
        //{
        //    bool isOnlyUpper = password.Count(c => Char.IsUpper(c)) == password.Length;

        //    if (isOnlyUpper == true)
        //    {
        //        return "password only contains upper chars";
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public void PasswordAddPoints()
        {
            bool isOnlyLower = password.Count(c => Char.IsLower(c)) == password.Length;
            bool isOnlyUpper = password.Count(c => Char.IsUpper(c)) == password.Length;
            bool isDigitPresent = password.Count(c => Char.IsDigit(c)) != 0 &&
                                         password.Count(c => Char.IsDigit(c)) < password.Length;
            bool containsUpp= password.Count(c => Char.IsUpper(c)) != 0 &&
                                         password.Count(c => Char.IsUpper(c)) < password.Length;
            bool containsLow= password.Count(c => Char.IsLower(c)) != 0 &&
                                         password.Count(c => Char.IsLower(c)) < password.Length;

            if (isOnlyLower == false)
            {
                addPoints = addPoints + 1;
            }
            if (isOnlyUpper == false)
            {
                addPoints = addPoints + 1;
            }
            if (isDigitPresent == true)
            {
                addPoints = addPoints + 1;
            }

            if (isOnlyLower==false && isOnlyUpper==false && isDigitPresent == true)
            {
                addPoints = addPoints + 2;
            }

            if (containsUpp == true || containsLow == true)
            {
                addPoints = addPoints + 1;
            }
            if (containsLow == true&& containsUpp==true)
            {
                addPoints = addPoints + 2;
            }
        }
        public string EvaluatePasswordStrenght()
        {

            PasswordAddPoints();
            if(addPoints ==8)
            {
                return "strong password";
            }
            else if(addPoints>=5)
            {
                return "medium password";
            }
            else
            {
                return "weak password. Please check the password suggestion option";
            }
        }
        public string SugestPasswordV1()
        {
            var newPass = password;

            if (newPass.Contains("a"))
            {
                newPass=newPass.Replace('a', '@');
            }
            if (newPass.Contains("e"))
            {
                newPass = newPass.Replace('e', '3');
            }
            if (newPass.Contains("i"))
            {
                newPass = newPass.Replace('i', '!');
            }
            if (newPass.Contains("o"))
            {
                newPass = newPass.Replace('o', '0');
            }
            if (newPass.Contains("s"))
            {
                newPass = newPass.Replace('s', '$');
            }
            if (newPass.Contains("t"))
            {
                newPass = newPass.Replace('t', '7');
            }
            Random r = new Random();
            int randomnum = r.Next(10, 1000);

            newPass = newPass + randomnum;
            return newPass;
        }
        public string SugestPasswordV2()
        {
            char[] Passarray = password.ToCharArray();
            for (int i = 0; i < password.Length; i = i + 2)
            {
                Passarray[i] = char.ToUpper(password[i]);
            }
            string newPass = new string(Passarray);

            Random r = new Random();
            int randomnum = r.Next(10, 1000);

            newPass = newPass + randomnum;
            return newPass;
        }

            
        

      
    }


}
