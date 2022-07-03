using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.DAL;
using PhoneBook.Models;

namespace PhoneBook.BL
{
    public class ContactManager
    {
        private List<Contact> _contacts;

        public void LoadContacts(string filePath)
        {
            _contacts = FileManager.LoadContacts(filePath).ToList();
        }

        public void SaveContacts(string filePath)
        {
            FileManager.SaveContacts(filePath, _contacts);
        }

        public Contact Get(int id)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts[i].ID.Equals(id))
                {
                    return _contacts[i];
                }
            }

            return null;
        }

        public void Add(Contact contact)
        {
            if (contact == null) 
                new ArgumentNullException(nameof(contact));
            VolidateIDs(contact);
            _contacts.Add(contact);
        }

        public void Edit(Contact contact)
        {
            if (contact == null) 
                new ArgumentNullException(nameof(contact));
            int index = _contacts.IndexOf(contact);
            if (index == -1)
                throw new ArgumentException($"The contact with ID: {contact.ID} not found");
            _contacts[index] = contact;
        }

        public void Delete(int id)
        {
            var contact = Get(id);
            if (contact == null)
                throw new ArgumentException($"The contact with ID: {contact.ID} not found");
            _contacts.Remove(contact);
        }

        public IEnumerable<Contact> Search(string text = "")
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            foreach (var contact in _contacts)
            {
                if (contact.FirstName.StartsWith(text) ||
                    contact.LastName.StartsWith(text) ||
                    contact.Email.StartsWith(text) ||
                    contact.Phone.Contains(text))
                {
                    yield return contact;
                }
            }

            //List<Contact> result = new List<Contact>();

            //foreach (var contact in _contacts)
            //{
            //    if (contact.FirstName.StartsWith(text) ||
            //        contact.LastName.StartsWith(text) ||
            //        contact.Email.StartsWith(text) ||
            //        contact.Phone.Contains(text))
            //    {
            //        result.Add(contact);
            //    }
            //}

            //return result;
        }

        private void VolidateIDs(Contact contact)
        {
            if (_contacts.Contains(contact)) 
                throw new ArgumentException($"The ID: {contact.ID} is already taken");

            //foreach (var item in _contacts)
            //{
            //    if (contact.Equals(contact)) throw new ArgumentException($"The ID: {contact.ID} is already taken");
            //}
        }
    }
}
