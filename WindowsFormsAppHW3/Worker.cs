using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppHW3
{
    public class Worker
    {
        public Worker() { }

        public Worker(string name, string surname, string dadName, DateTime birthDay, int phone, string address, string street, int home, int apartment)
        {
            Name = name;
            Surname = surname;
            DadName = dadName;
            BirthDay = birthDay;
            Phone = phone;
            Address = address;
            Street = street;
            Home = home;
            Apartment = apartment;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string DadName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
        public int Apartment { get; set; }
    }
}
