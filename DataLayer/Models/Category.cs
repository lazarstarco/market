using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Category
    {
        private int code;
        private string name;

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
    }
}
