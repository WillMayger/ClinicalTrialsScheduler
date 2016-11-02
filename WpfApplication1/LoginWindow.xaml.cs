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

            string filePath = User.fileLocationStatic;

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(filePath);
                file.Directory.Create(); // If the directory already exists, this method does nothing.
                System.IO.File.WriteAllText(file.FullName, "<Users></Users>");
            }

            filePath = Patient.fileLocation;

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.FileInfo fileN = new System.IO.FileInfo(filePath);
                fileN.Directory.Create(); // If the directory already exists, this method does nothing.
                System.IO.File.WriteAllText(fileN.FullName, "<Patient></Patient>");
            }
            
        }

        public void LoginWindowClose()
        {
            Close();
        }

        public void OnClickLogin(Object sender, EventArgs e)
        {
            string userEmail = emailInput.Text;
            string userPassword = passwordInput.Password;

            int count = User.UserCount();

            if (count == 0 && userEmail == "admin" && userPassword == "NHadmins1!")
            {
                OnSuccessfulLogin();
                return;
            }

            if (!User.UserEmailExists(userEmail))
            {
                string invalidCredentials = "Your username is inccorect, please try again.";
                MessageBox.Show(invalidCredentials, "ERROR!");

                return;
            }

            User attUser = new User(userEmail, userPassword);

            User realUser = User.LoadUser(userEmail);

            bool authenticated = Auth.AuthenticateUser(realUser.hash, attUser.salt, userPassword);

            if (authenticated)
            {
                OnSuccessfulLogin();
            }
            else
            {
                string invalidCredentials = "Your password is inccorect, please try again.";
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
