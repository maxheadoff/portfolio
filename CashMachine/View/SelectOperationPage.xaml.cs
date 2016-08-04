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
    /// Логика взаимодействия для SelectOperationPage.xaml
    /// </summary>
    public partial class SelectOperationPage : Page
    {
        public SelectOperationPage()
        {
            InitializeComponent();
        }

        private void btnGetCard_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentOperation = Pages.Welcome;
            (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)); 
        }

        private void btnPushMoney_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentOperation = Pages.PushMoney; // "PushMoneyPage.xaml";
            (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)); 
        }

        private void btnGetBalance_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentOperation = Pages.Message;
            (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)
                   , new DisplayMessage("Операция успешно завершена"
                       , string.Format("Текущее состояние счета:{0} рублей", App.Machine.GetBalance().ToString()))); 
        }

        private void btnPullMoney_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentOperation = Pages.PullMoney; 
            (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)); 
        }
    }
}
