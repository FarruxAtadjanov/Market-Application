using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Application.Servise
{
    internal class Commerse
    {
        public static void SignIn()
        {
            Menu start = new Menu();

            Console.Write("Login >  ");
            string login = Console.ReadLine();
            Console.Write("Password >  ");
            string password = (string)HidePassword();

            start.RunMainMenu();



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
