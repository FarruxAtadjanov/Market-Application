using Market_Application.IRepositories;
using Market_Application.Moduls;
using Market_Application.Servise;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Market_Application.Repository
{
    internal class ProductRepository : IProductRepository
    {
        public static IEnumerable<Product> result;

        #region AddProduct
        public void AddProduct(Product product)
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);
            IList<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            products.Add(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Type = product.Type,
                Purchased = product.Purchased
            });
            string jsonOut = JsonConvert.SerializeObject(products);
            File.WriteAllText(Constants.ProductsDbPath, jsonOut);
            Console.WriteLine("Mahsulot qo'shildi");
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
                                item.Price = double.Parse(newUpdateDate);
                                break;
                            case 3:
                                item.Type = newUpdateDate;
                                break;
                            case 4:
                                item.Purchased = double.Parse(newUpdateDate);
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
        public  IEnumerable<Product> SearchProduct(int searchCoise, string newWord)
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);
            IList<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            switch (searchCoise)
            {
                case 1:
                    result = products.Select(p => p).Where(p => p.Name.Equals(newWord)).ToList();
                    break;
                case 2:
                    result = products.Select(p => p).Where(p => p.Price.Equals(newWord)).ToList();
                    break;
                case 3:
                    result = products.Select(p => p).Where(p => p.Type.Equals(newWord)).ToList();
                    break;
                case 4:
                    result = products.Select(p => p).Where(p => p.Purchased.Equals(newWord)).ToList();
                    break;
                default:
                    Console.WriteLine("Bunday malumot bazadan topilmadi");
                    break;
            }
            return result;
        }
        #endregion

        #region Show Products
        public IList<Product> ShowProducts()
        {
            string json = File.ReadAllText(Constants.ProductsDbPath);
            return JsonConvert.DeserializeObject<IList<Product>>(json);
      
        }
        #endregion
    }
}
