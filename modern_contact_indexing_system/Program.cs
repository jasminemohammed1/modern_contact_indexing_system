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
