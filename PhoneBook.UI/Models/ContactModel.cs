using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PhoneBook.UI.Models
{
    public class ContactModel
    {
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        
        
    }
}
