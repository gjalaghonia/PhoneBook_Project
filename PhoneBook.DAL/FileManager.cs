using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using PhoneBook.Models;
###

namespace PhoneBook.DAL
{
    public static class FileManager
    {
        /// <summary>
        /// Reads and returns Contact lists from File
        /// </summary>
        /// <param name="filePath">file path from where should read</param>
        /// <returns>returns cobntact list from file</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IEnumerable<Contact> LoadContacts(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            var contacts = new List<Contact>();

            using (var reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                while (reader.PeekChar() != -1)
                {
                    Contact contact = new()
                    {
                        ID = reader.ReadInt32(),
                        FirstName = reader.ReadString(),
                        LastName = reader.ReadString(),
                        Email = reader.ReadString(),
                        Phone = reader.ReadString(),
                    };
                    contacts.Add(contact);
                }
            }
            VolidateIDs(contacts);

            return contacts;
        }

        /// <summary>
        /// saves contact list into the file ( binary mode).
        /// before save should check if ID unique or no.
        /// </summary>
        /// <param name="filePath">filepath where should save</param>
        /// <param name="contacts">contact list</param>
        /// <exception cref="NotImplementedException"></exception>
        public static void SaveContacts(string filePath, IEnumerable<Contact> contacts)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (contacts == null) throw new ArgumentNullException(nameof(contacts));

            VolidateIDs(contacts);

            using (var writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                foreach (var item in contacts)
                {
                    writer.Write(item.ID);
                    writer.Write(GetValue(item.FirstName));
                    writer.Write(GetValue(item.LastName));
                    writer.Write(GetValue(item.Email));
                    writer.Write(GetValue(item.Phone));
                }
            }
        }

        private static string GetValue(string value) => value ?? string.Empty;

        private static void VolidateIDs(IEnumerable<Contact> contacts)
        {
            HashSet<int> ids = new();
            foreach (var contact in contacts)
            {
                if (!ids.Add(contact.ID))
                {
                    throw new ArgumentException($"ID {contact.ID} is not unique.");
                }
            }
        }
    }
}
