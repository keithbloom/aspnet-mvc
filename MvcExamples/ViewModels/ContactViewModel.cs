using System.ComponentModel.DataAnnotations;

namespace MvcExamples.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$")]
        public string Email { get; set; }

        public bool DeleteMe { get; set; }

        public bool IsEmpty { get { return Id == 0 && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Email); } }
    }
}