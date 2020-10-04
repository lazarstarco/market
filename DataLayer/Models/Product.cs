using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Product
    {
        private int code;
        private string name;
        private string expirationDate;
        private int price;

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public int Price { get => price; set => price = value; }
    }
}
