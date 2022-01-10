using Market_Application.Models;
using Market_Application.Moduls;
using Market_Application.Repository;
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
                IList<User> users = JsonConvert.DeserializeObject<IList<User>>(json);

                var user = users.FirstOrDefault(p => p.Login == login && p.Password == password);
                {
                    if(user.Login == login && user.Password == password)
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
            User user = new User();
            UserRepository userRepository = new UserRepository();

            Console.Write("Ismingizni kiriting >  ");
            user.FirstName = Console.ReadLine();
            Console.Write("Familiyangizni kiriting >  ");
            user.LastName = Console.ReadLine();
            Console.Write("Login >  ");
            user.Login = Console.ReadLine();
            Console.Write("Password >  ");
            user.Password = Console.ReadLine();
            userRepository.Create(user);
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
