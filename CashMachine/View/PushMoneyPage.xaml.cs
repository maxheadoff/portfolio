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
    /// Логика взаимодействия для PushMoneyPage.xaml
    /// </summary>
    public partial class PushMoneyPage : Page
    {
        public PushMoneyPage()
        {
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            lbAviableMoneyCosts.MouseDoubleClick += (s, e) =>
            {
                var item = lbAviableMoneyCosts.SelectedValue;
                if (item!=null)
                    lbPile.Items.Add(item);
            };
            lbPile.MouseDoubleClick += (s, e) =>
                {
                    var item = lbPile.SelectedValue;
                    if (item != null)
                        lbPile.Items.Remove(item);
                };

            foreach(Model.MoneyCost cost in Enum.GetValues(Model.MoneyCost.Fifty.GetType()))
            {
                lbAviableMoneyCosts.Items.Add(new Cut(cost));
            }
        }

        private void btnCommit_Click(Object sender, RoutedEventArgs a)
        {
            Dictionary<Guid,Model.MoneyCost> pile=new Dictionary<Guid,Model.MoneyCost>();
            foreach(Cut cut in lbPile.Items)
                pile.Add(Guid.NewGuid(), cut.cost);
            try
            {
                App.Machine.PushMoney(pile);
                App.CurrentOperation = Pages.Message;
                (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)
                    , new DisplayMessage("Операция успешно завершена"
                        ,string.Format("Текущее состояние счета:{0} рублей",App.Machine.GetBalance().ToString()))); 
            }
            catch (IndexOutOfRangeException)
            {
                App.CurrentOperation = Pages.Message;
                (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)
                    ,new DisplayMessage("Операция не выполнена", "Банкомат переполнен")); 
            }
        }
        
    }
}
