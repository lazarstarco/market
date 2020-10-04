using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Item
    {
        private string code;
        private int quantity;
        private int userCode;
        private int productCode;
        public string Code { get => code; set => code = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int UserCode { get => userCode; set => userCode = value; }
        public int ProductCode { get => productCode; set => productCode = value; }

        override public string ToString()
        {
            return "Employee " + userCode + "; Product code " + productCode + " x " + quantity
                + "; Date " + code.Substring(0, 4) + "/" + code.Substring(4, 2) + "/" + code.Substring(6, 2);
        }
    }
}
