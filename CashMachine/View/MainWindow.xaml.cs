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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.CurrentOperation = Pages.Welcome;
            Navigate(App.CurrentOperation);
            frDisplay.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        /// <summary>
        /// Уходим на предидущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentOperation = App.CurrentOperation.GetPrevPage();
            Navigate(App.CurrentOperation);
        }
        /// <summary>
        /// Выполняем текущее действие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntEnter_Click(object sender, RoutedEventArgs e)
        {
            Navigate(App.CurrentOperation);
        }
        /// <summary>
        /// Осуществляет переход на указанную страницу
        /// </summary>
        /// <param name="uri"></param>
        private void Navigate(Model.Pages page)
        {
            if (page.Equals(Pages.Exit))
                this.Close();
                frDisplay.Navigate(new Uri(page.GetUri(), UriKind.RelativeOrAbsolute));

        }
   

    }
}
