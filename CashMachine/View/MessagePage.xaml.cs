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

namespace CashMachine
{
    /// <summary>
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        public MessagePage()
        {
            InitializeComponent();
            (App.Current.MainWindow as MainWindow).frDisplay.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }

        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData != null)
            {
                tbMessage.Text = (e.ExtraData as Model.DisplayMessage).Message;
                lbTitle.Content = (e.ExtraData as Model.DisplayMessage).Title;
            }
            
            (App.Current.MainWindow as MainWindow).frDisplay.NavigationService.LoadCompleted -= NavigationService_LoadCompleted;
            App.CurrentOperation = Model.Pages.SelectOperation;
        }
       
        
    }
}
