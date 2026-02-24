using modern_contact_indexing_system.Storage;

namespace modern_contact_indexing_system.Services
{
    internal class ContactManager
    {
        private List<Contact> _contacts { get; set; }
        private readonly IStorage _storage;


        public ContactManager(IStorage storage)
        {
            _storage = storage;
            _contacts = _storage.LoadContacts();
            
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

        

        public void ListAllContacts()
        {
            foreach(Contact contact in _contacts)
            {
                ViewContact(contact);
            }
        }

       
        public void EditContactById(int id , string NewName , string NewPhone , string NewEmail)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contact.Name = NewName;
                contact.Phone = NewPhone;
                contact.Email = NewEmail;
                return;

            }
            Console.WriteLine("This Contact doesnot exists");

        }

        public List<Contact> DisplayMatchingContactsByName(string name)
        {
            return _contacts
                .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Contact> FilterByDate(DateTime date)
        {
            return _contacts.Where(c => c.CreationDate.Date == date.Date).ToList();
        }


        public void Save()
        {
            _storage.Save(_contacts);
            Console.WriteLine("Contacts Saved Sucessfully");

        }



    }
}
