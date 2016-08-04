using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashMachine.Model;
using CashMachine;

namespace UnitTestCashMachine
{
    /// <summary>
    ///  Не имея цели достигнуть 100%-ного покрытия, всё-же потестим кое-что
    /// </summary>
    [TestClass]
    public class UnitTestViews
    {
        [TestMethod]
        public void TestUriAttribute()
        {
            Pages pages;
            pages = Pages.Message;
            Assert.AreEqual(pages.GetUri(), Pages.Message.GetUri());
            Assert.AreNotEqual(pages.GetUri(), Pages.PullMoney.GetUri());
            pages = Pages.Exit;
            Assert.AreEqual(pages.GetUri(), string.Empty);
            Assert.AreEqual(Pages.Message.GetPrevPage(), Pages.SelectOperation);
        }
        [TestMethod]
        public void TestValueAtrribute()
        {
            MoneyCost cost = MoneyCost.Hundred;
            Assert.AreEqual(cost.GetValue(), 100);
            Assert.AreNotEqual(MoneyCost.FiveHundred.GetValue(), MoneyCost.FiveThousand.GetValue());
            Assert.AreEqual(MoneyCost.Ten.GetValue(), 10);
        }

    }
}
