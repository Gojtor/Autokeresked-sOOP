using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokereskedés
{
    public class AutoNullException : Exception { }
    public abstract class Szerződés
    {
        public Autóker aker { get; private set; }
        public Autó autó { get; private set; }
        public Partner partner { get; private set; }
        public string dátum { get; private set; }
        public int ár { get; private set; }

        public Szerződés(Autóker aker, Autó autó, Partner partner, string dátum, int ár)
        {
            this.aker = aker;
            this.autó = autó;
            this.partner = partner;
            this.dátum = dátum;
            this.ár = ár;
        }

        public abstract string Type();
    }

    class Vétel : Szerződés 
    {
        public Vétel(Autóker aker, Autó autó, Partner partner, string dátum,int ár):base(aker,autó,partner,dátum,ár)
        {
            if(autó != null)
            {
                aker.autók.Add(autó);
            }
        }
        public override string Type()
        {
            return "vétel";
        }
    }
    class Adás : Szerződés
    {
        public Adás(Autóker aker, Autó autó, Partner partner, string dátum, int ár) : base(aker, autó, partner, dátum,ár)
        {
            if (autó != null)
            {
                aker.autók.Remove(autó);
            }
            else
            {
                throw new AutoNullException();
            }
        }
        public override string Type()
        {
            return "adás";
        }
    }

}
