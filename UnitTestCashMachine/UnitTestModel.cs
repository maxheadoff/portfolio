using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashMachine.Model;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestCashMachine
{
    [TestClass]
    public class UnitTestModel
    {
        [TestMethod]
        public void TestCreate()
        {
            ICashMachine cm = new CashMachine.Model.CashMachine(1);
            Assert.AreEqual(cm.GetBalance(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPush()
        {
            ICashMachine cm = new CashMachine.Model.CashMachine(1);
            Dictionary<Guid,MoneyCost> inp=new Dictionary<Guid,MoneyCost>();
            inp.Add(Guid.Empty,MoneyCost.Ten); // кладем в банкомат десятку
            cm.PushMoney(inp);
            double sum=10;  // здесь хардкодим, чтобы не получить зависимость теста от реализации модели проекта
            Assert.AreEqual(cm.GetBalance(), sum);
            inp = new Dictionary<Guid, MoneyCost>();
            inp.Add(Guid.NewGuid(), MoneyCost.Fifty);
            cm.PushMoney(inp);  // здесь валится исключение
  
        }

        [TestMethod]
        public void TestPushAndPull()
        {
            ICashMachine cm = new CashMachine.Model.CashMachine(9);
            Dictionary<Guid, MoneyCost> inp = new Dictionary<Guid, MoneyCost>();
            double sum = 10;  // здесь хардкодим опять, чтобы не получить зависимость теста от реализации модели проекта
            double value = 0; // снимаемая сумма
            inp.Add(Guid.Empty, MoneyCost.Ten); // кладем в банкомат пачку
            sum += 10;
            inp.Add(Guid.NewGuid(), MoneyCost.Ten);
            sum += 10;
            inp.Add(Guid.NewGuid(), MoneyCost.Ten);
            sum += 50;
            inp.Add(Guid.NewGuid(), MoneyCost.Fifty);
            sum += 50;
            inp.Add(Guid.NewGuid(), MoneyCost.Fifty);
            sum += 100;
            inp.Add(Guid.NewGuid(), MoneyCost.Hundred);
            sum += 500;
            inp.Add(Guid.NewGuid(), MoneyCost.FiveHundred);
            sum += 1000;
            inp.Add(Guid.NewGuid(), MoneyCost.Thousand);
            sum += 5000;
            inp.Add(Guid.NewGuid(), MoneyCost.FiveThousand);
            cm.PushMoney(inp);
            Assert.AreEqual(cm.GetBalance(), sum);
            bool res;
            value = 20;
            var pile= cm.PullMoney(MoneyCost.Ten, value, out res);
            sum -= value;
            Assert.AreEqual(res, true);
            Assert.AreEqual(cm.GetBalance(), sum);
            Assert.AreEqual(pile.Count(), 2);
            value = 60;
            pile = cm.PullMoney(MoneyCost.Ten, value, out res);
            sum -= value;
            Assert.AreEqual(res, true);
            Assert.AreEqual(cm.GetBalance(), sum);
            Assert.AreEqual(pile.Count(), 2);
            value = 600;
            pile = cm.PullMoney(MoneyCost.Hundred, value, out res);
            sum -= value;
            Assert.AreEqual(res, true);
            Assert.AreEqual(cm.GetBalance(), sum);
            Assert.AreEqual(pile.Count(), 2);
            Assert.AreEqual(pile.First(a => a.Value == MoneyCost.Hundred).Value, MoneyCost.Hundred);
            value = 1050;
            pile = cm.PullMoney(MoneyCost.FiveThousand, value, out res);
            sum -= value;
            Assert.AreEqual(res, true);
            Assert.AreEqual(cm.GetBalance(), sum);
            Assert.AreEqual(pile.Count(), 2);
            Assert.AreEqual(pile.First(a => a.Value == MoneyCost.Fifty).Value, MoneyCost.Fifty);
            Assert.AreEqual(pile.First(a => a.Value == MoneyCost.Thousand).Value, MoneyCost.Thousand);
        }

        [TestMethod]
        public void TestFailPull()
        {
            ICashMachine cm = new CashMachine.Model.CashMachine(8);
            Dictionary<Guid, MoneyCost> inp = new Dictionary<Guid, MoneyCost>();
            inp.Add(Guid.Empty, MoneyCost.Ten); // кладем в банкомат пачку
            inp.Add(Guid.NewGuid(), MoneyCost.Ten);
            double sum = 20;
            cm.PushMoney(inp);
            bool res;
            cm.PullMoney(MoneyCost.Ten, 40,out res); // не выйдет!
            Assert.AreNotEqual(res, true);
            Assert.AreEqual(cm.GetBalance(), sum);
            cm.PullMoney(MoneyCost.Ten, 15, out res); // да что ты!
            Assert.AreNotEqual(res, true);
            Assert.AreEqual(cm.GetBalance(), sum);
        }
        /// <summary>
        /// Тестируем метод GetAviableMoneyCosts();
        /// </summary>
        [TestMethod]
        public void TestAviableCuts() 
        {
            ICashMachine cm = new CashMachine.Model.CashMachine(8);
            Dictionary<Guid, MoneyCost> inp = new Dictionary<Guid, MoneyCost>();
            inp.Add(Guid.Empty, MoneyCost.Ten); // кладем в банкомат пачку
            inp.Add(Guid.NewGuid(), MoneyCost.Ten);
            inp.Add(Guid.NewGuid(), MoneyCost.Thousand);
            cm.PushMoney(inp);
            var res = cm.GetAviableMoneyCosts();
            Assert.AreEqual(res.Count, 2);
            Assert.AreEqual(res.First(a => a == MoneyCost.Ten), MoneyCost.Ten);
            Assert.AreEqual(res.First(a => a == MoneyCost.Thousand), MoneyCost.Thousand);
        }
        /// <summary>
        /// Тестируем DisplayMessage , что бы "не нарушать отчетности"
        /// </summary>
        [TestMethod]
        public void TestDisplayMessage()
        {
            
            DisplayMessage dm = new DisplayMessage("title", "message");
            Assert.AreEqual(dm.Title, "title");
            Assert.AreEqual(dm.Message, "message");
        }
        
    }
}
