using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokereskedés
{
    public interface Hanyag
    {
        double fÉrt(Mazda a);
        double fÉrt(Audi a);
        double fÉrt(Skoda a);
    }

    public class Benzin : Hanyag
    {
        private static Benzin? instance;
        private Benzin() { }
        public static Benzin Instance()
        {
            if (instance == null) instance = new Benzin();
            return instance;
        }
        public double fÉrt(Audi a) { return 1; }
        public double fÉrt(Mazda a) { return 2; }
        public double fÉrt(Skoda a) { return 3; }


    }
    public class Dízel : Hanyag
    {
        private static Dízel? instance;
        private Dízel() { }
        public static Dízel Instance()
        {
            if (instance == null) instance = new Dízel();
            return instance;
        }
        public double fÉrt(Audi a) { return 0.9; }
        public double fÉrt(Mazda a) { return 2; }
        public double fÉrt(Skoda a) { return 3.1; }


    }
    public class Elektromos : Hanyag
    {
        private static Elektromos? instance;
        private Elektromos() { }
        public static Elektromos Instance()
        {
            if (instance == null) instance = new Elektromos();
            return instance;
        }
        public double fÉrt(Audi a) { return 1.2; }
        public double fÉrt(Mazda a) { return 2.5; }
        public double fÉrt(Skoda a) { return 3.8; }


    }
    public class Hibrid : Hanyag
    {
        private static Hibrid? instance;
        private Hibrid() { }
        public static Hibrid Instance()
        {
            if (instance == null) instance = new Hibrid();
            return instance;
        }
        public double fÉrt(Audi a) { return 1.3; }
        public double fÉrt(Mazda a) { return 2.3; }
        public double fÉrt(Skoda a) { return 4; }


    }
}
