using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    [AttributeUsage(AttributeTargets.All)]
    public class MoneyCostAttribute : Attribute
    {
        public double Value;
        public string ImageResource;

        public MoneyCostAttribute(double value,string imageResource)
        {
            this.Value = value;
            this.ImageResource = imageResource;
        }

    }
}
