using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokereskedés
{
    public abstract class Autó
    {
        private static readonly double[,] faktorok = new double[3,4]{ { 1.0,0.9,1.2,1.3},{ 2.0, 2.0, 2.5, 2.3 },{ 3.0, 3.1, 3.8, 4.0 } };
        public string id { get; private set; }
        public int gyév { get; private set; }
        public int újár { get; private set; }
        public Hanyag hanyag { get; private set; }

        public Autó(string id, int gyév, int újár, Hanyag hanyag)
        {
            this.id = id;
            this.gyév = gyév;
            this.újár = újár;
            this.hanyag = hanyag;
        }

        public abstract double Faktor(Hanyag hanyag);
        public double Érték() 
        {
            return Math.Floor(újár * (100 - (DateTime.Now.Year - gyév)) / (100.0 * this.Faktor(hanyag)));
        }
    }

    public class Audi : Autó
    {
        public Audi(string id, int gyév, int újár, Hanyag hanyag):base(id,gyév,újár,hanyag) { }
        public override double Faktor(Hanyag hanyag)
        {
            return hanyag.fÉrt(this);
        }
        public override string ToString()
        {
            return "audi";
        }
    }
    public class Skoda : Autó
    {
        public Skoda(string id, int gyév, int újár, Hanyag hanyag) : base(id, gyév, újár, hanyag) { }
        public override double Faktor(Hanyag hanyag)
        {
            return hanyag.fÉrt(this);
        }
        public override string ToString()
        {
            return "skoda";
        }
    }
    public class Mazda : Autó
    {
        public Mazda(string id, int gyév, int újár, Hanyag hanyag) : base(id, gyév, újár, hanyag) { }
        public override double Faktor(Hanyag hanyag)
        {
            return hanyag.fÉrt(this);
        }
        public override string ToString()
        {
            return "mazda";
        }
    }
}
