using CoffeeShopIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopIdentity.Controllers
{
    interface IDAO
    {
        Item GetItem(int id);

        void UpdateQuantity(int Id, int quantity);

        List<Item> GetItemList();

        int GetListLength();

        List<Item> ItemSort(string column);

        void AddItem(Item item);

        void DeleteItem(int id);

        void EditItem(Item item);

        void Dispose();
    }
}
