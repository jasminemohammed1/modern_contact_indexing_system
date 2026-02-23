namespace modern_contact_indexing_system.Storage
{
    internal interface IStorage
    {
        void Save(List<Contact> contacts);
        List<Contact> LoadContacts();
        

        
    }
}
