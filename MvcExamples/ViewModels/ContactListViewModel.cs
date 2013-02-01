using System.Collections.Generic;

namespace MvcExamples.ViewModels
{
    public class ContactListViewModel
    {
        public List<ContactViewModel> Contacts { get; set; }

        public ContactListViewModel()
        {
            Contacts = new List<ContactViewModel>();
        }

        public void RemoveEmptyItems()
        {
            Contacts.RemoveAll(x => x.IsEmpty);
        }
    }
}