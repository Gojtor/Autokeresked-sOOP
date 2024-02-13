using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokereskedés
{
    public class Autóker
    {
        public class AutokerNincsIlyenAutoException : Exception { }
        public class AutoMarTulajdonException : Exception { }
        public List<Autó> autók { get; private set; }
        public List<Szerződés> szerződések { get; private set; }
        public string név { get; private set; }
        public Autóker(string név)
        {
            this.autók = new List<Autó>();
            this.szerződések = new List<Szerződés>();
            this.név = név;
        }
        public Autóker(List<Autó> autók,string név)
        {
            this.autók = autók;
            this.szerződések = new List<Szerződés>();
            this.név = név;
        }

        public void Vesz(Autó a,Partner p,string dátum,int ár)
        {
            if (!autók.Contains(a))
            {
                if (a != null)
                {
                    szerződések.Add(new Vétel(this,a,p,dátum,ár));
                }
                else
                {
                    throw new AutoNullException();
                }
            }
            else
            {
                //Console.WriteLine("Ez a kocsi már az autókereskedés tulajdonában van!");
                throw new AutoMarTulajdonException();
            }
        }
        public void Elad(Autó a, Partner p,string dátum,int ár)
        {
            if (autók.Contains(a))
            {
                //autók.Remove(a);
                szerződések.Add(new Adás(this, a, p,dátum,ár));
            }
            else
            {
                //Console.WriteLine("Az autókereskedésnek nincs ilyen autója!");
                throw new AutokerNincsIlyenAutoException();
            }
        }
        public int audikÖssz()
        {
            double sum = 0;
            foreach(Autó auto in autók)
            {
                if (auto.ToString()=="audi")
                {
                    sum += auto.Érték();
                }
            }
            return (int)sum;
        }
        public bool fiatalabbSkoda(int év)
        {
            foreach (Autó autó in autók)
            {
                if (autó.gyév>év && autó.ToString()=="skoda")
                {
                    return true;
                }
            }
            return false;
        }
        public int nyereség()
        {
            int vételSum = 0;
            int adásSum = 0;
            foreach(Szerződés szerződés in szerződések)
            {
                if (szerződés.Type()=="vétel")
                {
                    vételSum += szerződés.ár;
                }
                else
                {
                    adásSum += szerződés.ár;
                }
            }
            return adásSum-vételSum;
        }
        public int hanySzerzodes(Partner p)
        {
            int sum=0;
            foreach (Szerződés szerződés in szerződések)
            {
                if (szerződés.partner==p)
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
