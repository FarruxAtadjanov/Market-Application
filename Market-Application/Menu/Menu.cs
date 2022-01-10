using ConsoleTables;
using Market_Application.Moduls;
using Market_Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Market_Application.Servise 
{
    internal class Menu
    {      
        public static void Start()
        {
            Title = "Welcome!";          
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(prom);
        Back:
            string s = "* * * * * * * * * *";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {s} \t\t {"1. Kirish"} \t\t {s}\n  {s} \t\t {"2. Ro'yxatdan o'tish"} \t {s}\n  {s}  \t\t {"3. Chiqish"}   \t\t {s}");
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


        public static void RunMainMenu()
        {
            RunMainMenu:
            Console.Clear();
            ProductRepository productRepository = new ProductRepository();
            SaleAction saleAction = new SaleAction();



            string prompt = prom;
            string[] options = { "1. Barcha mahsulotlarni ko'rish", "2. Mahsulot qo'shish", "3. Mahsulot qidirish", "4. Mahsulot yangilash","5. Sotib olish" ,"6. Chiqish" };
            Console.WriteLine(prompt);
            foreach (var item in options)
            {
                Console.WriteLine(item);
            }
            int selected = int.Parse(Console.ReadLine());

            Product product = new Product();
            ProductRepository repository = new ProductRepository();

            switch (selected)
            {
                case 1:
                    productRepository.ShowProducts();
                    break;
                case 2:

                    Console.Write("Mahsulot nomini kiriting: ");
                    product.Name = Console.ReadLine().ToLower();
                    Console.Write("Mahsulot turini kiriting: ");
                    product.Type = Console.ReadLine().ToLower();
                    Console.Write("Mahsulot narxini kiriting: ");
                    product.Price = int.Parse(Console.ReadLine());

                    repository.AddProduct(product);
                    goto RunMainMenu;
                case 3:
                    Console.Clear();
                    Console.WriteLine(prompt);
                    Console.WriteLine("Qaysi bo'lim bo'yicha qidirmoqchisiz? ");
                    Console.WriteLine("1. Nomi bo'yicha\n2. Narxi bo'yicha\n3. Turi bo'yicha");
                    Console.Write("> ");
                    int selectedSearch = int.Parse(Console.ReadLine());
                    if (selectedSearch == 1)
                    {
                        Console.Write("Nomini kiriting: ");
                        string searchWord = Console.ReadLine().ToLower();
                        repository.SearchProduct(selectedSearch, searchWord);
                    }
                    else if (selectedSearch == 2)
                    {
                        Console.Write("Narxini kiriting: ");
                        string searchWord = Console.ReadLine();
                        repository.SearchProduct(selectedSearch, searchWord);
                    }
                    else if(selectedSearch == 3)
                    {
                        Console.Write("Turini kiriting: ");
                        string searchWord = Console.ReadLine().ToLower();
                        repository.SearchProduct(selectedSearch, searchWord);
                    }
                    
                    Console.WriteLine("Asosiy menuga qaytasizmi? [y / n] ");
                    string s = Console.ReadLine();
                    if (s == "y" || s == "Y") goto RunMainMenu;
                    else if (s == "N" || s == "n") Environment.Exit(0);                   
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine(prompt);
                    Console.Write("O'zgartirmoqchi bo'lgan mahsulot nomini kiriting: ");
                    product.Name = Console.ReadLine();
                    Console.Write("O'zgartirmoqchi bo'lgan mahsulot narxini kiriting:");
                    product.Price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Qaysi bo'lim bo'yicha o'zgartirmoqchisiz? ");
                    Console.WriteLine("1. Nomi bo'yicha\n2. Narxi bo'yicha\n3. Turi bo'yicha");
                    Console.Write("> ");
                    int se = int.Parse(Console.ReadLine());
                    if (se == 1)
                    {
                        Console.Write("Nomini kiriting: ");
                        string searchWord = Console.ReadLine().ToLower();
                        repository.UpdateProduct(product,se, searchWord);
                    }
                    else if (se == 2)
                    {
                        Console.Write("Narxini kiriting: ");
                        string searchWord = Console.ReadLine();
                        repository.UpdateProduct(product,se, searchWord);
                    }
                    else if (se == 3)
                    {
                        Console.Write("Turini kiriting: ");
                        string searchWord = Console.ReadLine().ToLower();
                        repository.UpdateProduct(product,se, searchWord);
                    }

                    Console.WriteLine("Asosiy menuga qaytasizmi? [y / n] ");
                    string x = Console.ReadLine();
                    if (x == "y" || x == "Y") goto RunMainMenu;
                    else if (x == "N" || x == "n") Environment.Exit(0);
                    break;
                case 5:
                    saleAction.AddProduct();
                    break;
                case 6:
                    WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                
            }
        }


        static string prom = @"
 __      __       .__                                  __          
/  \    /  \ ____ |  |   ____  ____   _____   ____   _/  |_  ____  
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \  \   __\/  _ \ 
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   |  | (  <_> )
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >  |__|  \____/ 
       \/       \/          \/            \/     \/                
          _____                              .__                   
         /     \ _____     _________  _______|__| ____             
        /  \ /  \\__  \   / ___\__  \ \___   /  |/    \            
       /    Y    \/ __ \_/ /_/  > __ \_/    /|  |   |  \           
       \____|__  (____  /\___  (____  /_____ \__|___|  /           
               \/     \//_____/     \/      \/       \/            
                      
".ToString();

    }
}
