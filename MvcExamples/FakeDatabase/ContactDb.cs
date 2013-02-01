using System.Collections.Generic;
using System.Linq;

namespace MvcExamples.FakeDatabase
{
    public class ContactDb
    {
        private static IList<Contact> _contacts;

        public ContactDb()
        {
            _contacts = new List<Contact>
                {
                    new Contact
                        {
                            Id = 1,
                            Email = "test@person.com",
                            Name = "Test Person"
                        }
                };
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _contacts.Max(x => x.Id) + 1;
            _contacts.Add(contact);
        }

        public void RemoveContact(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);

            if(contact == null) return;

            _contacts.Remove(contact);
        }

        public void Update(IEnumerable<Contact> contacts)
        {
            var maxId = _contacts.Any() ? _contacts.Max(x => x.Id) + 1 : 0;
            
            foreach (var item in contacts.Where(x => x.Id == 0))
            {
                item.Id = maxId;
                maxId++;
            }

            _contacts = contacts.ToList();
        }

        public IEnumerable<Contact> Contacts { get { return _contacts; } } 
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}