using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_contact_indexing_system
{
    internal class Contact
    {
        private string _name;
        private string _email;
        private string _phone;
        private static int _id = 0;
      
        public string Name {
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    Console.WriteLine("Invalid Name");
                    return;
                }
                _name = value;

            }
            get
            {
                return _name;
            }
        }
    

    public string Email
        {
            set
            {
                if (value.Length < 5 || !value.Contains('@') || value.Contains(" "))
                {
                    Console.WriteLine("Invalid Email");
                    return;
                }
                _email = value;
            }

            get
            {
                return _email;
            }
        }


        public string Phone
        {
            set
            {
                if(value.Length !=11 || !value.All(char.IsDigit) || !value.StartsWith("01"))
                {
                    Console.WriteLine("Invalid Phone Number in Egypt");
                    return;
                }
                _phone = value;
            }
            get
            {
                return _phone;  
            }
        }
        public int Id { get; }
        public DateTime CreationDate { get; }
        public Contact(string name , string email , string phone )
        {
            Name = name;
            Email = email;
            Phone = phone;
            _id++;
            Id = _id;
            CreationDate = DateTime.Now;


  
        }



    }
}
