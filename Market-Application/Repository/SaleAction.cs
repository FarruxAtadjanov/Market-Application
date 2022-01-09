using Market_Application.IRepositories;
using Market_Application.Moduls;
using Market_Application.Servise;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Application.Repository
{
    internal class SaleAction : ISaleAction
    {
             
        public void AddProduct()
        {
            IList<Product> produkts = new List<Product>();

            while (true)
            {
                start:
                Console.Clear();
                string json = File.ReadAllText(Constants.ProductsDbPath);
                IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(json);
               
                int count = 0;
                Console.WriteLine("\t\t\t<*** Do'konimizdagi bor mahsulotlar ro'yxati ***>");
                foreach (var item in products)
                {
                    count++;
                    item.Id = count;
                    Console.WriteLine($"{item.Id} {item.Name} {item.Price} {item.Type}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Olmoqchi bo'lgan mahsulotingiz raqamini kiriting");
                Console.Write("> ");
                int choiceproduct = int.Parse(Console.ReadLine());

                Console.WriteLine("Miqdori");
                Console.Write("> ");
                int choiceweight = int.Parse(Console.ReadLine());

                foreach (var item in products)
                {
                    if (item.Id == choiceproduct)
                    {
                        produkts.Add(new Product()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price * choiceweight,
                            Type = item.Type,
                        });
                    }
                }
                Console.WriteLine("Yana mahsulot sotib olasizmi? [y / n]");
                Console.Write("> ");
                char stopOrContinue = char.Parse(Console.ReadLine());
                
                if (stopOrContinue == 'y' || stopOrContinue == 'Y') goto start;
                else
                {
                    string json1 = JsonConvert.SerializeObject(produkts);
                    File.WriteAllText(Constants.PurchasedDbPath, json1);

                    string json2 = File.ReadAllText(Constants.PurchasedDbPath);
                    IList<Product> resultProducts = JsonConvert.DeserializeObject<IList<Product>>(json2);
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Siz sotib olgan mahsulotlar ro'yxati ");
                    int resultPrice = 0;
                    foreach (var item in resultProducts)
                    {
                        resultPrice += item.Price;
                        Console.WriteLine($"{item.Name}  ---  {item.Price}  ---  {item.Type}");
                    }
                    Console.WriteLine($"\t\t\t\t\t\t Jami summa : {resultPrice}");

                    Console.WriteLine("Asosiy menuga qaytasizmi? [y / n]");
                    Console.Write("> ");
                    string sel = Console.ReadLine();
                    if (sel == "y" || sel == "Y")
                    {
                        Menu.RunMainMenu();
                    }
                    else if (sel == "n" || sel == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("Xaridingiz uchun raxmat !!!");
                        Environment.Exit(0);
                    }
                    break;

                }

            }

        }    
    }
}
