using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_contact_indexing_system
{
    internal class ContactManager
    {
        private List<Contact> _contacts { get; set; }


        public ContactManager()
        {
            _contacts = new List<Contact>();
        }

        public void ViewContact(Contact contact)
        {
            Console.WriteLine($"ContactId: {contact.Id},ContactName: {contact.Name},ContactCreationDate:{contact.CreationDate},ContactPhone:{contact.Phone},ContactEmail:{contact.Email} ");
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public Contact? this[string name]
        {
            get
            {
                foreach (Contact contact in _contacts)
                {
                    if (contact.Name == name)
                    {
                        return contact;
                    }
                }
                return null;

            }

        }

        public Contact ?this[int id]
        {
            get
            {
                foreach (Contact contact in _contacts)
                {
                    if (contact.Id == id)
                    {
                        return contact;
                    }
                }
                return null;
            }



        }

        public void DeleteContactById(int IdToDelete)
        {
            Contact ? contact = _contacts.FirstOrDefault(c => c.Id == IdToDelete);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public void DeleteContactByName(string NameToDelete)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.Name == NameToDelete);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public void ListAllContacts()
        {
            foreach(Contact contact in _contacts)
            {
                ViewContact(contact);
            }
        }

        public void EditContactPhoneByName(string NameToBeEdited , string NewPhone)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.Name == NameToBeEdited);
            if (contact != null) {
                contact.Phone = NewPhone;
                return;
                
            }
            Console.WriteLine("This Contact doesnot exists");



        }

        public void EditContactNamebyName(string NameToBeEdited , string NewName)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.Name == NameToBeEdited);
            if (contact != null)
            {
                contact.Name = NewName;
                return;

            }
            Console.WriteLine("This Contact doesnot exists");

        }


    }
}
