using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    public class LimitedDictionary<TKey,TValue> : Dictionary<TKey,TValue>
    {
        int maxCapacity = 1;

        public LimitedDictionary(int maxCapacity):base(maxCapacity)
        {
            this.maxCapacity = maxCapacity;
        }

        /// <summary>
        /// т.к. невозможно перегрузить метод add, добавляем метод с нужной нам функциональностью
        /// а именно:
        /// проверяем на максимальную вместительную способность словаря
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddLimited(TKey key, TValue value)
        {
            if (this.Count<maxCapacity)
                this.Add(key, value);
            else
                throw new IndexOutOfRangeException("Превышено ограничение размера LimitedDictionary");
        }

    }
}
