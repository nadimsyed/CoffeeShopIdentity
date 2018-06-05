using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CoffeeShopIdentity.Models;

namespace CoffeeShopIdentity.Controllers
{
    public class ItemDAO : IDAO
    {
        private CoffeeShopEntities db;

        public ItemDAO()
        {
            db = new CoffeeShopEntities();
        }

        public Item GetItem(int Id)
        {
            return db.Items.Find(Id);
        }

        public void UpdateQuantity(int Id, int quantity)
        {
            db.Items.Find(Id).Quantity = quantity;
            db.SaveChanges();
        }

        public List<Item> GetItemList()
        {
            return db.Items.ToList();
        }

        public int GetListLength()
        {
            int counter = 0;
            foreach (Item item in db.Items)
            {
                counter++;
            }
            return counter;
        }

        public List<Item> ItemSort(string column)
        {
            List<Item> Sorted = new List<Item>();
            //LINQ Query
            if (column == "Name")
            {
                Sorted = (from b in db.Items
                          orderby b.Name
                          select b).ToList();
            }
            else if (column == "Description")
            {
                Sorted = (from b in db.Items
                          orderby b.Description
                          select b).ToList();
            }
            else if (column == "Price")
            {
                Sorted = (from b in db.Items
                          orderby b.Price
                          select b).ToList();
            }

            return Sorted;
        }

        public void AddItem(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
        }

        public void EditItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}