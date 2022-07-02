using PhoneBook.DAL;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook.App
{
    public partial class Form1 : Form
    {
        private readonly FileManager _fileManager;

        public Form1()
        {
            InitializeComponent();
            _fileManager = new FileManager();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                    ID = 1,
                    FirstName = "Levan",
                    LastName = "Azariashvili",
                    Email = "Levani22azar@gmail.com",
                },
                new Contact
                {
                    ID = 2,
                    FirstName = "Gega",
                    LastName = "Azariashvili",
                    Email = "Gega.Azariashvili@gmail.com",
                },
            };

            _fileManager.SaveContacts(@"C:\Users\Guram\Desktop\TEST\binary.dat", contacts);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            IEnumerable<Contact> contacts = _fileManager.LoadContacts(@"C:\Users\Guram\Desktop\TEST\binary.dat");
        }
    }
}
