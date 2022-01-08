using Market_Application.Enum;
using Market_Application.Moduls;
using System;
using Market_Application.IRepositories;
using System.Linq;
using System.IO;
using Market_Application.Servise;

namespace Market_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.Start();

 
        Back:
            string s = "* * * * * * * * * *";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {s}  {"1. SignIn"}  {s}\n  {s}  {"2. SignUp"}  {s}\n  {s}  {"3. Exit"}    {s}");
            Console.Write(" Select >  ");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    Commerse.SignIn();
                    break;

                case "2":
                    Commerse.SignUp();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    goto Back;
            }
         
            
        }
    }
}
