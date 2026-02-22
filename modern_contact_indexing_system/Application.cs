
namespace modern_contact_indexing_system
{
    internal class Application
    {
        private readonly ContactManager _manager;

        public Application(ContactManager manger)
        {
            _manager = manger;
        }

        public void Run()
        {
            Console.WriteLine("Welcome To Modern Contact System");
            while(true)
            {
                Menue.Show();
                string choice = Console.ReadLine() ?? " ";
                switch(choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        EditContactName();
                        break;
                    case "3":
                        EditContactPhone();
                        break;
                    case "4":
                        DeleteByName();
                        break;
                    case "5":
                        DeleteById();
                        break;
                    case "6":
                        _manager.ListAllContacts();
                        break;
                    case "7":
                        ViewById();
                        break;

                    case "8":
                        SearchForMatchingContacts();
                        break;

                    case "9":
                        _manager.Save();
                        break;

                    case "10":
                        _manager.Save();
                        Console.WriteLine("Exiting...");
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }

        }
        private void AddContact()
        {
            Console.WriteLine("Enter The Contact Name: ");
            string name = Console.ReadLine() ?? " ";
            Console.WriteLine("Enter The Contact Phone: ");
            string phone = Console.ReadLine() ?? " ";
            Console.WriteLine("Enter The Contact Email: ");
            string email = Console.ReadLine() ?? " ";
            _manager.AddContact(new Contact(name, email, phone));
        }
        private void EditContactName()
        {
            Console.WriteLine("Enter Contact Name To Edit: ");
            string contactName = Console.ReadLine() ?? " ";
            Console.WriteLine("Enter The Contact New Name: ");
            string newContactName = Console.ReadLine() ?? " ";
            _manager.EditContactNamebyName(contactName, newContactName);
        }

        private void EditContactPhone()
        {
            Console.WriteLine("Enter Name To Edit Phone: ");
            string Name = Console.ReadLine() ?? " ";
            Console.WriteLine("Enter The New Phone: ");
            string newPhone = Console.ReadLine() ?? " ";
            _manager.EditContactPhoneByName(Name, newPhone);
        }
        private void DeleteByName()
        {
            Console.WriteLine("Enter Name To Delete");
            string nameToDelete = Console.ReadLine() ?? " ";
            _manager.DeleteContactByName(nameToDelete);
        }
        private void DeleteById()
        {
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                _manager.DeleteContactById(id);
            }
            else
            {
                Console.WriteLine("InValid Id.");
            }

        }
        private void ViewById()
        {
            Console.WriteLine("Enter Id To view: ");
            if (int.TryParse(Console.ReadLine(), out int idToView))
            {
                Contact? contact = _manager[idToView];
                if (contact != null)
                {
                    Console.WriteLine(contact);

                }
                else
                {
                    Console.WriteLine("Contact Not Found.");
                }

            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        private void SearchForMatchingContacts()
        {
            Console.WriteLine("Enter A Name To Search for Matching Contacts: ");
            string searchName = Console.ReadLine() ?? " ";
            var results = _manager.DisplayMatchingContactsByName(searchName);
            if (results.Count == 0) Console.WriteLine("No matching contacts found.");
            else results.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Phone: {c.Phone}, Email: {c.Email}, Created: {c.CreationDate}"));
        }
    }
}
