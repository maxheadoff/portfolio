using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    /// <summary>
    /// Представляет сообщение, которое нужно вывести на дисплей банкомата
    /// </summary>
    public class DisplayMessage
    {
        public string Title {  get; private set; }
        public string Message {  get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="title">string заголовок</param>
        /// <param name="message">string текст сообщения</param>
        public DisplayMessage(string title, string message)
        {
            this.Title = title;
            this.Message = message;
        }
    }
}
