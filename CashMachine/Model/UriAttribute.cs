using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    public class UriAttribute:Attribute
    {
        public string Uri;
        public Pages PreviosPage;
        public UriAttribute(string uri,Pages prevPage)
        {
            this.Uri = uri;
            this.PreviosPage= prevPage;
        }
    }
}
