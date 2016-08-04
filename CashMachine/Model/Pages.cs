using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    public enum Pages
    {
        
        Exit,
        
        [Uri("View\\WelcomePage.xaml",Pages.Exit)]
        Welcome,
        
        [Uri("View\\SelectOperationPage.xaml", Pages.Welcome)]
        SelectOperation,

        [Uri("View/PushMoneyPage.xaml", Pages.SelectOperation)]
        PushMoney,

        [Uri("View/PullMoneyPage.xaml", Pages.SelectOperation)]
        PullMoney,

        [Uri("View/GetBalancePage.xaml", Pages.SelectOperation)]
        GetBalance,
        [Uri("View/MessagePage.xaml", Pages.SelectOperation)]
        Message
    }
}
