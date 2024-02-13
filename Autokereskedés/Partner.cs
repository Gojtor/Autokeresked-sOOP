using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokereskedés
{
    public class Partner
    {
        public string név { get; private set; }
        public Partner(string név)
        {
            this.név = név;
        }
    }
}
