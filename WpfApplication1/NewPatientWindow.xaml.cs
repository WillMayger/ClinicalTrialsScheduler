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

namespace NHSApplication
{
    /// <summary>
    /// Interaction logic for NewPatientWindow.xaml
    /// </summary>
    public partial class NewPatientWindow : Window
    {
        public NewPatientWindow()
        {
            InitializeComponent();
        }

        private void HomeScreen()
        {
            MainWindow Home = new MainWindow();
            Home.Show();
            Close();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {

        }
    }
}
