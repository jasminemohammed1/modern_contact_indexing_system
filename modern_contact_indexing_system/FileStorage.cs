using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modern_contact_indexing_system
{
    internal class FileStorage : IStorage
    {
        private const string FileName = "contacts.json";
        public void Save(List<Contact> contacts) {
            string json = JsonSerializer.Serialize(contacts , new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);

        }
        public List<Contact> LoadContacts()
        {
            if (!File.Exists(FileName))
            {
                return new List<Contact>();
            }
            string json = File.ReadAllText(FileName);
            var contacts = JsonSerializer.Deserialize<List<Contact>>(json,
         new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Contact>();

            
            if (contacts.Count > 0)
                Contact.SetIdCounter(contacts.Max(c => c.Id));

            return contacts;

        }

    }
}
