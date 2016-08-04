using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    public enum MoneyCost
    {
        //pack://application:,,,/Subfolder/
        [MoneyCostAttribute(10, "pack://application:,,,/Resource/10R.jpg")]
        Ten = 10,
        [MoneyCostAttribute(50, "pack://application:,,,/Resource/50R.jpg")]
        Fifty = 50,
        [MoneyCostAttribute(100, "pack://application:,,,/Resource/100R.jpg")]
        Hundred = 100,
        [MoneyCostAttribute(500, "pack://application:,,,/Resource/500R.jpg")]
        FiveHundred = 500,
        [MoneyCostAttribute(1000, "pack://application:,,,/Resource/1000R.jpg")]
        Thousand = 1000,
        [MoneyCostAttribute(5000, "pack://application:,,,/Resource/5000R.jpg")]
        FiveThousand = 5000
    }
}
