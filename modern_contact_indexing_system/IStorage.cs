

namespace modern_contact_indexing_system
{
    internal interface IStorage
    {
        void Save(List<Contact> contacts);
        List<Contact> LoadContacts();
        

        
    }
}
