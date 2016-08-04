using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    /// <summary>
    /// Реализация банкомата
    /// В хранилище хранятся все купюры как экземпляры , это полнее отражает суть банкомата, есть возможность расширить функционал определением, 
    /// например, уникального номера купюры
    /// </summary>
    public class CashMachine :ICashMachine
    {
        private int pileSize = 0; // Максимальное количество хранимых купюр
        private LimitedDictionary<Guid, MoneyCost> storage; // Общее хранилище купюр

        public CashMachine(int pileSize)
        {
            this.pileSize = pileSize;
            storage=new LimitedDictionary<Guid,MoneyCost>(this.pileSize);
        }

        #region Члены ICashMachine

        public Dictionary<Guid, MoneyCost> PullMoney(MoneyCost cost, double sum, out bool result)
        {
            double resSum = 0;
            bool isCutFound = false;
            Dictionary<Guid, MoneyCost> res = new Dictionary<Guid, MoneyCost>();
            result = true;
            while (resSum < sum)
            {
                var cut = getNextCut((sum - resSum), cost, out isCutFound);
                if (isCutFound)
                {
                    res.Add(cut.Key, cut.Value);
                    storage.Remove(cut.Key);
                    resSum += cut.Value.GetValue();
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (!result)
            {
                // Катимся назад, т.к. несмогли подобрать купюры под нужную сумм
                foreach (KeyValuePair<Guid, MoneyCost> item in res)
                    storage.Add(item.Key, item.Value);
                res.Clear();
                result = false;
            }
            return res;
        }
        
        public void PushMoney(Dictionary<Guid,MoneyCost> pile)
        {
            foreach (KeyValuePair<Guid,MoneyCost> cut in pile)
            {
                storage.AddLimited(cut.Key,cut.Value); // добавляем матодом, который проверяет вместительную способность хранилища
            }
        }

        public List<MoneyCost> GetAviableMoneyCosts()
        {
            List<MoneyCost> res = new List<MoneyCost>();
            var vario = storage.Distinct(new MoneyCostComparer());
            foreach (KeyValuePair<Guid, MoneyCost> item in vario)
                res.Add(item.Value);
            return res;
        }

        public double GetBalance()
        {

            //TODO - refactoring
            double res=0;
            foreach (MoneyCost cut in storage.Select((a) => a.Value))
            {
                res =res+ cut.GetValue();
            }
            return res;
        }

        #endregion

    
        /// <summary>
        /// Подбирает подходящую купюру к выдаче
        /// </summary>
        /// <param name="sum">double Сумма которую необходимо выдать</param>
        /// <param name="item">MoneyCost предпочитаемая купюра</param>
        /// <returns> пара ключ-значение купюра из хранилища </returns>
        private KeyValuePair<Guid, MoneyCost> getNextCut(double sum, MoneyCost cost,out bool result)
        {
            result = true;
            KeyValuePair<Guid, MoneyCost> res = new KeyValuePair<Guid, MoneyCost>(Guid.Empty, MoneyCost.Ten); 
            var items = storage.Where(a => a.Value.Equals(cost)); // ищем предпочитаемую купюру
            if (items.Count() > 0 & sum > cost.GetValue())
            {
                res = items.First();
            }
            else
            {
                items = storage.Where((a) => a.Value.GetValue() == sum);// ищем купюру, равную сумме
                if (items.Count() > 0)
                {
                    res = items.First();
                }
                else
                {
                    items = storage.Where((a) => a.Value.GetValue() < sum); // ищем купюру меньше суммы
                    if (items.Count() > 0)
                    {
                        res = items.First();
                    }
                    else
                        result = false;
                }
            }
            return res;
        }

        /// <summary>
        /// Применяется для реализации метода distinct , чтобы получить список доступных купюр
        /// </summary>
        class MoneyCostComparer : IEqualityComparer<KeyValuePair<Guid, MoneyCost>>
        {

            #region Члены IEqualityComparer<KeyValuePair<Guid,MoneyCost>>

            public bool Equals(KeyValuePair<Guid, MoneyCost> x, KeyValuePair<Guid, MoneyCost> y)
            {
                return x.Value.GetValue() == y.Value.GetValue();
            }

            public int GetHashCode(KeyValuePair<Guid, MoneyCost> obj)
            {
                return  Convert.ToInt32(obj.Value.GetValue()*100);
            }

            #endregion
        }
    }
}
