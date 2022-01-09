using Market_Application.Models;
using Market_Application.Moduls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Market_Application.Servise
{
    internal class Commerse
    {
        public static void SignIn()
        {

            Console.Write("Login >  ");
            string login = Console.ReadLine();
            Console.Write("Password >  ");
            string password = (string)HidePassword();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n");

            if (login != null && password != null)
            {
                string json = File.ReadAllText(Constants.UsersDbPath);
                IList<User> user = JsonConvert.DeserializeObject<IList<User>>(json);

                foreach (var item in user)
                {
                    if(item.Login == login && item.Password == password)
                    {
                        Menu.RunMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Login yoki parol xato qaytatdan urinib ko'ring");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu.Start();
                        
                        
                    }
                }
                
            }
        }
        public static void SignUp()
        {
            Console.Write("FirstName >  ");
            string fname = Console.ReadLine();
            Console.Write("SurName >  ");
            string sname = Console.ReadLine();
            Console.Write("Login >  ");
            string userLogin = Console.ReadLine();
            Console.Write("Password >  ");
            string userPassword = Console.ReadLine();
        }

        //passwordni yashirish
        public static object HidePassword()
        {
            string hidePassword = "";
            while (true)
            {
            place:
                try
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            return null;
                        case ConsoleKey.Enter:
                            return hidePassword;
                        case ConsoleKey.Backspace:
                            hidePassword = hidePassword.Substring(0, (hidePassword.Length - 1));
                            Console.Write("\b \b");
                            break;
                        default:
                            hidePassword += key.KeyChar;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("*");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }
                }
                catch
                {
                    goto place;
                }
            }
        }
    }
}
