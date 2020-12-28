using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            

            this.Close();



        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(this.contact);
            }

            this.Close();

        }
    }
}
