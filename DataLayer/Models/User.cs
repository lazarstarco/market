using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class User
    {
        private int code;
        private string name;
        private string surname;
        private string birthDate;
        private string eMail;

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string EMail { get => eMail; set => eMail = value; }
    }
}
