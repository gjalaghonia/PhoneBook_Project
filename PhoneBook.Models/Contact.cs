using System;

namespace PhoneBook.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return ID == (obj as Contact).ID;
        }
    }
}
