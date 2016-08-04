using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    /// <summary>
    /// банкомат 
    /// </summary>
    public interface ICashMachine
    {
        /// <summary>
        /// Взять деньги купюрами предпочитаемого наминала
        /// </summary>
        /// <param name="item">MoneyCost</param>
        /// <returns></returns>
         Dictionary<Guid,MoneyCost> PullMoney(MoneyCost cost,double sum,out bool result);
        /// <summary>
        /// Вложить "пачку" денег
        /// </summary>
        /// <param name="pile">List MoneyCost  пачка</param>
        void PushMoney(Dictionary<Guid,MoneyCost> pile);
        /// <summary>
        /// Возвращает список доступных купюр
        /// </summary>
        /// <returns>List MoneyCost </returns>
        List<MoneyCost> GetAviableMoneyCosts();

        /// <summary>
        /// Возвращает баланс
        /// </summary>
        /// <returns></returns>
        double GetBalance(); 

    }

    
}
