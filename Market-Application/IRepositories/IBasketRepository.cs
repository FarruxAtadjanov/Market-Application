using Market_Application.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Application.IRepositories
{
    internal interface IBasketRepository
    {
        void AddToBasket(Product product);

        bool RemoveFromBasket(Product product);

        IList<Product> GetBasket();

        void ClearBasket();
    }
}
