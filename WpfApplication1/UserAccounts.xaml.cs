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
using ClinicalTrialsSchedulerClassLibrary;

namespace NHSApplication
{
    /// <summary>
    /// Interaction logic for UserAccounts.xaml
    /// </summary>
    public partial class UserAccounts : Window
    {
        public UserAccounts()
        {
            InitializeComponent();
        }

        private void HomeScreenOnClick(object sender, RoutedEventArgs e)
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            Close();
        }

        private void OnCreateNewUser(object sender, RoutedEventArgs e)
        {
            string email = textBoxNUEmail.Text;
            string pass = passwordBoxNU.Password;
            string passConfirm = passwordBoxNUConfirm.Password;

            if (pass != passConfirm)
            {
                string invalidCredentials = "The passwords do not match.";
                MessageBox.Show(invalidCredentials, "ERROR!");
                return;
            }

            User nu = new User(email, pass);
            nu.CreateNewUser();

            MessageBox.Show("New User has been created", "Success!");
        }

        private void OnDeleteUser(object sender, RoutedEventArgs e)
        {
            string email = textBoxDUEmail.Text;

            bool success = User.DeleteUser(email);

            if (success)
            {
                MessageBox.Show("User has been deleted", "Success!");
            }
            else
            {
                MessageBox.Show("User does not exist", "Error!");
            }

        }

    }

}
