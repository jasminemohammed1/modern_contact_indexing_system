using modern_contact_indexing_system.Services;
using modern_contact_indexing_system.UI;
using System.Xml.Linq;

namespace modern_contact_indexing_system.App
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
                        EditContactById();
                        break;
                    case "3":
                       DeleteById();
                        break;
                    case "4":
                       ViewById();
                        break;
                    case "5":
                        _manager.ListAllContacts();
                        break;
                    case "6":
                        SearchForMatchingContacts();
                        break;
                    case "7":
                        FilterContactsByDate();
                        break;

                    case "8":
                        _manager.Save();
                        break;

                    case "9":
                        ExitApplication();
                        break;

                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }

        }
        private void AddContact()
        {
            string name;
            do
            {
                Console.WriteLine("Enter Contact Name To Add:");
                name = Console.ReadLine() ?? " ";
                if(string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }

            } while (string.IsNullOrWhiteSpace(name));
            string phone;
            do
            {
                Console.WriteLine("Enter The Contact Phone: ");
                phone = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit))
                {
                    Console.WriteLine("Phone must contain digits only and cannot be empty.");
                    phone = "";
                }

            } while (string.IsNullOrWhiteSpace(phone));

            string email;
            do
            {
                Console.WriteLine("Enter The Contact Email: ");
                email = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                {
                    Console.WriteLine("Invalid email format.");
                    email = "";
                }

            } while (string.IsNullOrWhiteSpace(email));
            _manager.AddContact(new Contact(name, email, phone));
            Console.WriteLine("Contact Added Sucessfully.");
        }
        private void EditContactById()
        {
            Console.WriteLine("Enter Contact Id To Edit: ");
            int id;

            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer Id. ");
            }
            string newName;
            do {
                Console.WriteLine("Enter The new Name: ");
                newName = Console.ReadLine() ?? " ";
            }while(string.IsNullOrWhiteSpace(newName));    
            string newPhone;
            do
            {
                Console.WriteLine("Enter the new phone: ");
                newPhone = Console.ReadLine() ?? " ";
            } while (string.IsNullOrWhiteSpace(newPhone));

            string newEmail;
            do
            {
                Console.WriteLine("Enter the New Email: ");
                newEmail = Console.ReadLine() ?? " ";
            }
            while (string.IsNullOrWhiteSpace(newEmail));

            _manager.EditContactById(id, newName,  newPhone , newEmail);
            Console.WriteLine("Contact Edited Sucessfully.");
        }

       
        
        private void DeleteById()
        {
            int id;
            bool isParsed;
            do
            {
                Console.WriteLine("Please Enter Contact Id To delete: ");
                isParsed = int.TryParse(Console.ReadLine(), out id);
                if (!isParsed)
                {
                    Console.WriteLine("Invalid Id. Please enter a valid number.");
                }
            } while(!isParsed);
            
            
                _manager.DeleteContactById(id);
            Console.WriteLine("Contact Deleted Sucessfully.");
            
            

        }
        private void ViewById()
        {
            int Id;
            bool IsParsed;


            do
            {
                Console.WriteLine("Enter Id To view a contact: ");
                IsParsed = int.TryParse(Console.ReadLine(), out Id);
                if (!IsParsed)
                {
                    Console.WriteLine("Invalid Id. Please enter a valid id.");
                }
            }
            while (!IsParsed);
                Contact? contact = _manager[Id];
                if (contact != null)
                {
                    Console.WriteLine(contact);

                }
                else
                {
                    Console.WriteLine("Contact Not Found.");
                }

            
          
        }
        private void SearchForMatchingContacts()
        {
            string name;
            do
            {
                Console.WriteLine("Enter a Name To Search For Matching Contacts.");
                name = Console.ReadLine() ?? " ";

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }


            }
            while (string.IsNullOrWhiteSpace(name));
           
            var results = _manager.DisplayMatchingContactsByName(name);
            if (results.Count == 0) Console.WriteLine("No matching contacts found.");
            else results.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Phone: {c.Phone}, Email: {c.Email}, Created: {c.CreationDate}"));
        }
        private void ExitApplication()
        {
            string choice;

            do
            {
                Console.WriteLine("Do you want to save before exiting? (Y/N)");
                choice = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (choice == "Y")
                {
                    _manager.Save();
                    Console.WriteLine("Changes saved.");
                    break;
                }
                else if (choice == "N")
                {
                    Console.WriteLine("Exiting without saving.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                }

            } while (choice != "Y" && choice != "N");

            Console.WriteLine("Exiting...");
        }

        private void FilterContactsByDate()
        {
            DateTime date;
            bool isValid;

            do
            {
                Console.WriteLine("Enter Date (yyyy-MM-dd): ");
                isValid = DateTime.TryParse(Console.ReadLine(), out date);

                if (!isValid)
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }

            } while (!isValid);

            var results = _manager.FilterByDate(date);

            if (results.Count == 0)
            {
                Console.WriteLine("No contacts found on this date.");
            }
            else
            {
                results.ForEach(c =>
                    Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Phone: {c.Phone}, Email: {c.Email}, Created: {c.CreationDate}")
                );
            }
        }
    }
}
