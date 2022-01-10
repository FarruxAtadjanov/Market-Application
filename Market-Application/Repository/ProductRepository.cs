using ConsoleTables;
using Market_Application.IRepositories;
using Market_Application.Moduls;
using Market_Application.Servise;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Market_Application.Repository
{
    internal class ProductRepository : IProductRepository
    {
        public  IEnumerable<Product> result;

        #region AddProduct
        public  void AddProduct(Product product)
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);
            IList<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            products.Add(new Product
            {
                Id = product.Id,
                Name = product.Name.ToLower(),
                Price = product.Price,
                Type = product.Type.ToLower(),

            });
            string jsonOut = JsonConvert.SerializeObject(products);
            File.WriteAllText(Constants.ProductsDbPath, jsonOut);
            Console.WriteLine("Mahsulot qo'shildi");

            Thread.Sleep(1500);
        }
        #endregion

        #region RemoveProduct
        public  void RemoveProduct(Product product)
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);

            IList<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            var collectedProduct = products.Where(p => p.Name == product.Name &&
                                                  p.Price == product.Price &&
                                                  p.Type == product.Type).ToList();

            foreach (var item in collectedProduct)
            {
                products.Remove(item);
            }
            string json2 = JsonConvert.SerializeObject(products);
            File.WriteAllText(Constants.ProductsDbPath, json2);
            Console.WriteLine("Mahsulot o'chirildi");
        }
        #endregion

        #region UpdateProduct
        public void UpdateProduct(Product product, int updateChoise, string newUpdateDate)
        {
            int check = 0;

            string json = File.ReadAllText(Constants.ProductsDbPath);
            IList<Product> products = JsonConvert.DeserializeObject <List<Product>>(json);          
            IList<Product> prod = new List<Product>();

            foreach (var item in products)
            {
                if (json is not null or "")
                {
                    if (item.Name == product.Name && item.Price == product.Price)
                    {
                        switch (updateChoise)
                        {
                            case 1:
                                item.Name = newUpdateDate;
                                break;
                            case 2:
                                item.Price = int.Parse(newUpdateDate);
                                break;
                            case 3:
                                item.Type = newUpdateDate;
                                break;                         
                        }
                        check++; 
                        prod.Add(item);
                    }
                    else prod.Add(item);
              
                }
            }
            string json3 = JsonConvert.SerializeObject(prod);
            File.WriteAllText(Constants.ProductsDbPath, json3);

            if (check > 0) Console.WriteLine("Muaffaqiyatli o'zgardi");
            else Console.WriteLine("O'zgarish amalga oshmadi");
        }
        #endregion


        #region Search Product
        public  void SearchProduct(int searchCoise, string newWord)
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);
            IList<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            switch (searchCoise)
            {
                case 1:
                    result = products.Select(p => p).Where(p => p.Name.Equals(newWord)).ToList();
                    break;
                case 2:
                    result = products.Select(p => p).Where(p => p.Price.Equals(int.Parse(newWord))).ToList();
                    break;
                case 3:
                    result = products.Select(p => p).Where(p => p.Type.Equals(newWord)).ToList();
                    break;
                default:
                    Console.WriteLine("Bunday malumot bazadan topilmadi");
                    break;
            }
            ConsoleTable table = new ConsoleTable("Id", "Name", "Price", "Type");
            foreach (var item in result)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Type);
            }
            Console.WriteLine(table);
           
        }
        #endregion

        #region Show Products
        public  void ShowProducts()
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);
            IList<Product> show = JsonConvert.DeserializeObject<List<Product>>(json);

            ConsoleTable table = new ConsoleTable("Id", "Name", "Price", "Type");
            foreach (var item in show)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Type);
            }
            Console.WriteLine(table);
            Thread.Sleep(2000);
            back:
            try
            {
                Console.WriteLine("Asosiy menuga qaytish uchun [1] ni bosing: ");
                Console.WriteLine("Chiqish uchun [0] ni bosing");
                int num = int.Parse(Console.ReadLine());
                if (num == 1)
                {
                    Menu.RunMainMenu();
                }
                else if (num == 2)
                {
                    Environment.Exit(0);
                }
            }
            catch
            {   Console.Clear(); 
                goto back;
            }
        }
        #endregion
    }
}
