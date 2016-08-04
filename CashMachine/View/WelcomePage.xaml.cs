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
using CashMachine.Model;

namespace CashMachine
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            App.Machine = null;
        }

        private void btnInsertCard_Click(object sender, RoutedEventArgs e)
        {
            App.Machine = new Model.CashMachine(Properties.Settings.Default.cashCapacity);
            App.CurrentOperation = Pages.SelectOperation; // "SelectOperationPage.xaml";
            btnInsertCard.Content = "Карта вставлена, нажмите ввод...";
            btnInsertCard.IsEnabled = false;
        }
    }
}
