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
    /// Логика взаимодействия для PullMoneyPage.xaml
    /// </summary>
    public partial class PullMoneyPage : Page
    {
        public PullMoneyPage()
        {
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            var items=App.Machine.GetAviableMoneyCosts();
            if (items.Count>0)
            {
                foreach (MoneyCost cost in items)
                    lbAviableCuts.Items.Add(new Model.Cut(cost) );
                if (lbAviableCuts.Items.Count > 0)
                    lbAviableCuts.SelectedIndex = 0;
            }
            else
            {
                ShowResult(new DisplayMessage("Операция прервана", "Операция недоступна"));
            }
        }

        private void btnGetMoney_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            if (!double.TryParse(tbSum.Text, out sum))
            {
                ShowResult(new DisplayMessage("Операция прервана", "Неверно указана сумма"));
                return;
            }
            try
            {
                var obj = lbAviableCuts.SelectedItem;
                if (obj != null)
                {
                    MoneyCost cost = ((Model.Cut)obj).cost;
                    lbTakeMoney.Content = "Заберите деньги(Двойной шелчек):";
                    bool result;
                    var cuts=App.Machine.PullMoney(cost, sum,out result);
                    if(!result)
                    {
                        ShowResult(new DisplayMessage("Операция прервана", "Операция недоступна"));
                        return;
                    }
                    foreach (KeyValuePair<Guid, MoneyCost> item in cuts)
                        lbTakedCuts.Items.Add(new Model.Cut(item.Value));
                    lbTakedCuts.MouseDoubleClick += (s, ev) =>
                        {
                            ShowResult(new DisplayMessage("Операция успешно завершена", string.Format("Доступные средства: {0} рублей"
                                , App.Machine.GetBalance().ToString())));
                        };
                }
                else
                    ShowResult(new DisplayMessage("Операция прервана", "Операция недоступна"));
            }
            catch (Exception ex) { ShowResult(new DisplayMessage("Операция прервана", "Данная сумма недоступна")); }
        }

        private void ShowResult(DisplayMessage message)
        {
            App.CurrentOperation = Pages.Message;
            (App.Current.MainWindow as MainWindow).frDisplay.Navigate(new Uri(App.CurrentOperation.GetUri(), UriKind.RelativeOrAbsolute)
            , message);
        }
    }
}
