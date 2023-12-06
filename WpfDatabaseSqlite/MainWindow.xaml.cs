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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace WpfDatabaseSqlite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {
            using (DataContext context = new DataContext()) 
            {
                var name = NameTextbox.Text;
                var address = AddressTextbox.Text;

                if (name != null && address != null)
                {
                    context.Users.Add(new User() { Name = name, Address = address });
                    context.SaveChanges();
                }
            }
        }

        public void Read()
        {

            using (DataContext context = new DataContext())
            {
                DatabaseUsers= context.Users.ToList();
                Itemlist.ItemsSource = DatabaseUsers;
            }

        }

        public void UpdateDb()
        {
            using (DataContext context = new DataContext())
            {
                User selectedUser = Itemlist.SelectedItem as User;

                string name = NameTextbox.Text;
                string address = AddressTextbox.Text;

                if (name != null && address != null)
                {
                    User user = context.Users.Find(selectedUser.Id);
                    user.Name = name;
                    user.Address = address;

                    context.SaveChanges();
                }
            }
        }

        public void DeleteUser()
        {

            using (DataContext context = new DataContext())
            {
                User selectedUser = Itemlist.SelectedItem as User;

   
                if (selectedUser != null)
                {
                    User user = context.Users.Single(x=> x.Id == selectedUser.Id);
                 
                    context.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create();

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateDb();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser();
            Read();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Itemlist.Items.Clear();
        }
    }
}
