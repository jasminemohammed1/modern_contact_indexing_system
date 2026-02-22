using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_contact_indexing_system
{
    internal interface IStorage
    {
        void Save(List<Contact> contacts);
        List<Contact> LoadContacts();
        

        
    }
}
