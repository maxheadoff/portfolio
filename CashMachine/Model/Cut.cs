using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CashMachine.Model
{
    /// <summary>
    /// Представляет купюру
    /// </summary>
    public class Cut
    {
        public MoneyCost cost { get; private set; }
        BitmapImage image;

        public BitmapImage Image
        {
            get { return image; }
            set { image = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Cut(MoneyCost cost)
        {
            this.cost = cost;
            Name = cost.GetImageResource();
            Uri uri = new Uri(cost.GetImageResource());
            try
            {
                image = new BitmapImage(uri);
            }
            catch { };
        }


    }
}
