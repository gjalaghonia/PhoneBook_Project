using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.DAL;
using PhoneBook.Models;

namespace PhoneBook.BL
{
    public class ContactManager
    {
        private readonly FileManager _fileManager;
        private List<Contact> _contacts;

        public ContactManager()
        {
            _fileManager = new FileManager();
        }

        public void LoadContacts(string filePath)
        {
            _contacts = _fileManager.LoadContacts(filePath).ToList();
        }

        public void SaveContacts(string filePath)
        {
            _fileManager.SaveContacts(filePath, _contacts);
        }

        //public void Test(Contact contact)
        //{
        //    if (_contacts.Contains(contact))
        //    {

        //    }
        //}

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
            _contacts.Add(contact);
        }

        public void Edit(Contact contact)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts[i].ID.Equals(contact.ID))
                {
                    _contacts[i] = contact;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts[i].ID.Equals(id))
                {
                    _contacts.RemoveAt(i);
                }
            }
        }

        public IEnumerable<Contact> Search(string text)
        {
            throw new NotImplementedException();
        }
    }
}
