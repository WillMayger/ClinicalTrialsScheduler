using NHSApplication;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void LoginWindowClose()
        {
            Close();
        }

        public void OnClickLogin(Object sender, EventArgs e)
        {
            string userEmail = emailInput.Text;
            string userPassword = passwordInput.Password;

            bool authenticated = Auth.AuthenticateUser(userEmail, userPassword);

            if (authenticated)
            {
                OnSuccessfulLogin();
            }
            else
            {
                string invalidCredentials = "Your username or password is inccorect, please try again.";
                MessageBox.Show(invalidCredentials, "ERROR!");
            }
            

        }

        private void OnSuccessfulLogin()
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            LoginWindowClose();
        }
    }
}
