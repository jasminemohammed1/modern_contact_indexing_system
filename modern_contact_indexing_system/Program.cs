namespace modern_contact_indexing_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStorage stoage = new FileStorage();
            ContactManager manager = new ContactManager(stoage);
            Console.WriteLine("Welcome To Modern Contact System");
            while(true)
            {
                Console.WriteLine("======== The Main Menue ========");
                Console.WriteLine("1. Add Contact.");
                Console.WriteLine("2. Edit Contact Name.");
                Console.WriteLine("3. Edit Contact Phone.");
                Console.WriteLine("4. Delete Contact By Name.");
                Console.WriteLine("5. Delete Contact By Id. ");
                Console.WriteLine("6. List All Contacts. ");
                Console.WriteLine("7. View Contact By Id.");
                Console.WriteLine("8. Search For Matching Contacts.");
                Console.WriteLine("9. Save.");
                Console.WriteLine("10. Exit. ");
                Console.WriteLine("Choose Your Option (1,2,3,..) ");

                string choice = Console.ReadLine() ??" ";
                switch(choice) {
                    case "1":
                        Console.WriteLine("Enter The Contact Name: ");
                        string name = Console.ReadLine() ?? " ";
                        Console.WriteLine("Enter The Contact Phone: ");
                        string phone = Console.ReadLine() ?? " ";
                        Console.WriteLine("Enter The Contact Email: ");
                        string email = Console.ReadLine() ?? " ";   
                        manager.AddContact(new Contact(name,  email , phone));
                        break;

                    case "2":

                        Console.WriteLine("Enter Contact Name To Edit: ");
                        string contactName = Console.ReadLine() ?? " ";
                        Console.WriteLine("Enter The Contact New Name: ");
                        string newContactName = Console.ReadLine() ?? " ";  
                        manager.EditContactNamebyName(contactName, newContactName);
                        break;

                    case "3":
                        Console.WriteLine("Enter Name To Edit Phone: ");
                        string Name = Console.ReadLine() ?? " ";
                        Console.WriteLine("Enter The New Phone: ");
                        string newPhone = Console.ReadLine() ?? " ";    
                        manager.EditContactPhoneByName( Name , newPhone);

                        break;

                    case "4":
                        Console.WriteLine("Enter Name To Delete");
                        string nameToDelete = Console.ReadLine() ?? " ";  
                        manager.DeleteContactByName(nameToDelete);
                        break;

                    case "5":
                        Console.WriteLine("Enter Id To Delete:");
                        int id;
                        if(int.TryParse(Console.ReadLine() ,out id ))
                        {
                            manager.DeleteContactById(id);
                        }
                        else
                        {
                            Console.WriteLine("InValid Id.");
                        }
                            break;

                    case "6":
                        manager.ListAllContacts();
                        break;
                    case "7":
                        Console.WriteLine("Enter Id To view: ");
                        if(int.TryParse(Console.ReadLine(), out int idToView))
                        {
                            Contact? contact = manager[idToView];
                            if(contact!=null)
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
                            break;

                    case "8":
                        Console.WriteLine("Enter A Name To Search for Matching Contacts: ");
                        string searchName = Console.ReadLine() ?? " ";
                        var results = manager.DisplayMatchingContactsByName(searchName);
                        if (results.Count == 0) Console.WriteLine("No matching contacts found.");
                        else results.ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Phone: {c.Phone}, Email: {c.Email}, Created: {c.CreationDate}"));
                        break;

                    case "9":
                        manager.Save();
                        break;

                    case "10":
                        manager.Save();
                        Console.WriteLine("Exiting...");
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid Option Try Again...");
                        break;

                }
            }

      
        }
    }
}
