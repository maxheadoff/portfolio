using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Model;

namespace CashMachine
{
    public static class Extentions  
    {
        /// <summary>
        /// Расширяем перечисление методом
        /// </summary>
        /// <param name="value">значение перечисления</param>
        /// <returns></returns>
        public static double GetValue(this Enum value)
        {
            var attr = value.GetAttribute<MoneyCostAttribute>();
            return attr != null ? attr.Value : 0;
        }

        /// <summary>
        /// Расширяем перечисление методом возвращающим путь к изображению 
        /// </summary>
        /// <param name="value">значение перечисления</param>
        /// <returns></returns>
        public static string GetImageResource(this Enum value)
        {
            var attr = value.GetAttribute<MoneyCostAttribute>();
            return attr != null ? attr.ImageResource : "";
        }

        /// <summary>
        /// Возвращает атрибут указанного типа для enum-значения
        /// </summary>
        /// <typeparam name="T">Тип атрибута</typeparam>
        /// <param name="value">Значение enum</param>
        /// <returns>Атрибут указанного типа</returns>
        private static T GetAttribute<T>(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var attr = type.GetField(name).GetCustomAttributes(false).OfType<T>().SingleOrDefault();
            return attr;
        }

        /// <summary>
        /// Возвращает значение атрибута UriAttribute для enum-значения , либо пустую строку, если атрибут не указан
        /// </summary>
        /// <param name="value">Enum-значение</param>
        /// <returns>Значение атрибута UriAttribute для enum-значения , либо пустую строку, если атрибут не указан</returns>
        public static string GetUri(this Enum value)
        {
            var attribute = value.GetAttribute<UriAttribute>();
            return attribute != null ? attribute.Uri : "";
        }

        public static Pages GetPrevPage(this Enum value)
        {
            var attribute = value.GetAttribute<UriAttribute>();
            return attribute != null ? attribute.PreviosPage: Pages.Exit;
        }
    }
}
