using Market_Application.Moduls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Application.IRepositories
{
    interface IProductRepository
    {
        public void AddProduct(Product product);

        public void RemoveProduct(Product product);

        public void UpdateProduct(Product product, int updateChoise, string newUpdateDate);

        public void SearchProduct(int searchCoise, string newWord);
    }
}
