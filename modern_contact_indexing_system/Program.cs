using modern_contact_indexing_system.App;
using modern_contact_indexing_system.Services;
using modern_contact_indexing_system.Storage;

namespace modern_contact_indexing_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStorage stoage = new FileStorage();
            ContactManager manager = new ContactManager(stoage);
            Application App = new Application(manager);
            App.Run();



        }
    }
}
