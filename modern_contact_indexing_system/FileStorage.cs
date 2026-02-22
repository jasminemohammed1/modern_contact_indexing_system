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
            string json = JsonSerializer.Serialize(contacts);
            File.WriteAllText(FileName, json);

        }
        public List<Contact> LoadContacts()
        {
            if (!File.Exists(FileName))
            {
                return new List<Contact>();
            }
            string json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<Contact>>(json)
                   ?? new List<Contact>();

        }

    }
}
