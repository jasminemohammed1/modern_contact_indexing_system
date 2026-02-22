using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_contact_indexing_system
{
    internal  static class Menue
    {
        public static void Show()
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

        }
    }
}
