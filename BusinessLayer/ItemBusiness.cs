using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ItemBusiness
    {
        private ItemRepository itemRepository;

        public ItemBusiness()
        {
            itemRepository = new ItemRepository();
        }

        public List<Item> GetItems()
        {
            return itemRepository.GetItems();
        }

        public List<Item> GetItemsByCode(int code)
        {
            return itemRepository.GetItemsByCode(code);
        }
        public List<Item> GetItemsByDate(string date)
        {
            return itemRepository.GetItemsByDate(date);
        }
        public List<Item> GetItemsByCategory(int category)
        {
            return itemRepository.GetItemsByCategory(category);
        }
        public List<Item> GetItemsByProduct(int product)
        {
            return itemRepository.GetItemsByProduct(product);
        }

        public bool InsertItem(Item item)
        {
            int result = 0;
            if (item != null)
            {
                result = itemRepository.InsertItem(item);
            }
            return result > 0 ? true : false;
        }
    }
}
