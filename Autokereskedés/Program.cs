using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Autokereskedés
{
    class AutokerNotFoundException : Exception { }
    class SzerzodesTypeNotValidException : Exception { }
    class AutoAlreadyExistsException : Exception { }
    class AutoTypeNotValidException : Exception { }
    public class VanIlyenNevűAutokerException : Exception { }
    public class Program
    {
        private static List<Autóker> autokereskedések;
        private static List<Autó> autók;
        private static List<Partner> partnerek;
        static void Main(string[] args)
        {
            autokereskedések = new List<Autóker>();
            autók = new List<Autó>();
            partnerek = new List<Partner>();
            #region ManualTesting
            /*
            Autó vrumm1 = new Audi("kicsikocsi1",2002,2000000,Dízel.Instance());
            Autó vrumm2 = new Skoda("kicsikocsi2", 2003, 2000000,Benzin.Instance());
            Autó vrumm3 = new Mazda("kicsikocsi3", 2004, 2000000, Benzin.Instance());
            Autó vrumm4 = new Audi("kicsikocsi4", 2002, 2000000, Dízel.Instance());
            Autó vrumm5 = new Audi("kicsikocsi5", 2002, 2000000, Dízel.Instance());
            Autó vrumm6 = new Audi("kicsikocsi6", 2002, 2000000, Dízel.Instance());

            Autóker CsorbaBt = new Autóker(new List<Autó>() { vrumm1, vrumm2, vrumm3, vrumm4 },"Csorba Bt.");

            Partner jozsi = new Partner("Józsi bá");

            CsorbaBt.Vesz(vrumm5,jozsi,"ma", 2000);
            CsorbaBt.Vesz(vrumm6,jozsi,"ma", 2000);
            CsorbaBt.Elad(vrumm6, new Partner("Piroska"),"ma", 10000);
            

            Console.WriteLine("A "+CsorbaBt.autók[0].id+" értéke : "+CsorbaBt.autók[0].Érték() + " Ft. Vételi ára volt: " + CsorbaBt.szerződések[0].ár+" Ft");
            Console.WriteLine($"A CsorbaBt kereskedésben árult Audik értéke összesen: {CsorbaBt.audikÖssz()} Ft");
            Console.WriteLine(CsorbaBt.fiatalabbSkoda(2002) ? "Volt" : "Nem volt");
            Console.WriteLine("A kereskedés nyeresége: "+CsorbaBt.nyereség());
            Console.WriteLine("A kereskedés hány szerződést kötött Józsi bácsival: "+CsorbaBt.hanySzerzodes(jozsi));
            
            BeolvasAutókereskedések("autokerInput.txt",autokereskedések);
            BeolvasAutók("autokInput.txt", autók,autokereskedések);
            BeolvasPartnerek("partnerekInput.txt",partnerek);
            BeolvasSzerződések("szerződésekInput.txt",autokereskedések,autók,partnerek);
            */
            BeolvasEgyben("inputEgyben.txt", autokereskedések, autók, partnerek);
            Console.WriteLine("A " + autokereskedések[0].autók[0].id + " értéke : " + autokereskedések[0].autók[0].Érték() + " Ft. Vételi ára volt: " + autokereskedések[0].szerződések[0].ár + " Ft");
            Console.WriteLine($"A CsorbaBt kereskedésben árult Audik értéke összesen: {autokereskedések[0].audikÖssz()} Ft");
            Console.WriteLine(autokereskedések[0].fiatalabbSkoda(2002) ? "Volt" : "Nem volt");
            Console.WriteLine("A kereskedés nyeresége: " + autokereskedések[0].nyereség());
            Console.WriteLine("A kereskedés hány szerződést kötött Józsi bácsival: " + autokereskedések[0].hanySzerzodes(partnerek[0]));
            #endregion

        }
        #region FileBeolvasásMetódusai

        public static void BeolvasEgyben(string fileName, List<Autóker> autokerek, List<Autó> autok, List<Partner> partnerek)
        {
            try
            {
                Infile x = new Infile(fileName);
                while (x.ReadInputFile())
                {
                    switch (x.fileLine[0])
                    {
                        case "autókereskedés":
                            string autokerNev = x.fileLine[1];
                            if (autokerek.Find(y => y.név == autokerNev) != null)
                            {
                                throw new VanIlyenNevűAutokerException();
                            }
                            else
                            {
                                autokerek.Add(CreateAutóker(x.fileLine[1]));
                            }
                            break;
                        case "autó":
                            Autó auto = CreateAutó(x.fileLine.Skip(1).ToArray());
                            if (x.fileLine.Length == 7)
                            {
                                string autokerNév = x.fileLine[6];
                                try
                                {
                                    autokerek.Find(y => y.név == autokerNév)?.autók.Add(auto);
                                }
                                catch
                                {
                                    throw new AutokerNotFoundException();
                                }
                            }
                            else
                            {
                                if (!autok.Contains(auto))
                                {
                                    autok.Add(auto);
                                }
                                else
                                {
                                    throw new AutoAlreadyExistsException();
                                }
                            }
                            break;
                        case "partner":
                            partnerek.Add(CreatePartner(x.fileLine[1]));
                            break;
                        case "szerződés":
                            Autó a = autok.Find(y => y.id == x.fileLine[3])!;
                            Szerződés sz = CreateSzerződés(x.fileLine.Skip(1).ToArray(), autokerek, autok, partnerek);
                            try
                            {
                                string autokerNév = x.fileLine[2];
                                if(a != null)
                                {
                                    autokerek.Find(y => y.név == autokerNév)?.szerződések.Add(sz);
                                }
                            }
                            catch
                            {
                                throw new AutokerNotFoundException();
                            }
                            break;
                    }
                }
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        Console.WriteLine("File not found!");
                    }
            }
            
   
        #region KülönFájlBeolvasás
        /*
        public static void BeolvasAutókereskedések(string fileName, List<Autóker> autokerek)
        {
            try
            {
                Infile x = new Infile(fileName);
                PopulateAutokerek(x,autokerek);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }
        public static void BeolvasAutók(string fileName, List<Autó> autók, List<Autóker> autokerek)
        {
            try
            {
                Infile x = new Infile(fileName);
                PopulateAutok(x,autók,autokerek);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }
        public static void BeolvasPartnerek(string fileName, List<Partner> partnerek)
        {
            try
            {
                Infile x = new Infile(fileName);
                PopulatePartnerek(x,partnerek);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }
        public static void BeolvasSzerződések(string fileName, List<Autóker> autokerek, List<Autó> autok, List<Partner> partners)
        {
            try
            {
                Infile x = new Infile(fileName);
                PopulateSzerződések(x,autokerek,autok,partners);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }
        private static void PopulateAutokerek(in Infile x, List<Autóker> autokerek)
        {
            while (x.ReadInputFile())
            {
                string autokerNev = x.fileLine[0];
                if (autokerek.Find(y => y.név == autokerNev) != null)
                {
                    throw new VanIlyenNevűAutokerException();
                }
                else
                {
                    autokerek.Add(CreateAutóker(x.fileLine[0]));
                }
            }
        }
        private static void PopulateAutok(in Infile x, List<Autó> autók, List<Autóker> autokerek)
        {
            while (x.ReadInputFile())
            {
                Autó auto = CreateAutó(x.fileLine);
                if (x.fileLine.Length == 6)
                {
                    string autokerNév = x.fileLine[5];
                    try
                    {
                        autokerek.Find(y => y.név == autokerNév)?.autók.Add(auto);
                    }
                    catch
                    {
                        throw new AutokerNotFoundException();
                    }
                }
                else
                {
                    if (!autók.Contains(auto))
                    {
                        autók.Add(auto);
                    }
                    else
                    {
                        throw new AutoAlreadyExistsException();
                    }
                }
            }
        }
        private static void PopulatePartnerek(in Infile x, List<Partner> partnerek)
        {
            while (x.ReadInputFile())
            {
                partnerek.Add(CreatePartner(x.fileLine[0]));
            }
        }
        private static void PopulateSzerződések(in Infile x, List<Autóker> autokerek, List<Autó> autok, List<Partner> partners)
        {
            while (x.ReadInputFile())
            {
                Szerződés sz = CreateSzerződés(x.fileLine,autokerek,autok,partners);
                try
                {
                    string autokerNév = x.fileLine[1];
                    autokerek.Find(y => y.név == autokerNév)?.szerződések.Add(sz);
                }
                catch
                {
                    throw new AutokerNotFoundException();
                }
            }
        }
        */
        #endregion
        private static Autóker CreateAutóker(string név)
        {
                return new Autóker(név);
        }
        private static Autó CreateAutó(string[] input)
        {
            Hanyag hanyag;
            switch (input[4])
            {
                case "Dízel":
                    hanyag = Dízel.Instance();
                    break;
                case "Benzin":
                    hanyag = Benzin.Instance();
                    break;
                case "Hibrid":
                    hanyag = Hibrid.Instance();
                    break;
                case "Elektromos":
                    hanyag = Elektromos.Instance();
                    break;
                default:
                    hanyag = Benzin.Instance();
                    break;
            }
            if (input[0] == "audi")
            {
                return new Audi(input[1], int.Parse(input[2]), int.Parse(input[3]), hanyag);
            }
            else if (input[0] == "skoda")
            {
                return new Skoda(input[1], int.Parse(input[2]), int.Parse(input[3]), hanyag);
            }
            else if (input[0] == "mazda")
            {
                return new Mazda(input[1], int.Parse(input[2]), int.Parse(input[3]), hanyag);
            }
            else
            {
                throw new AutoTypeNotValidException();
            }
        }
        private static Partner CreatePartner(string név)
        {
            return new Partner(név);
        }
        private static Szerződés CreateSzerződés(string[] input, List<Autóker> autokerek, List<Autó> autok,List<Partner> partners)
        {
                if (input[0] == "vétel")
                {
                    Autó a = autok.Find(y => y.id == input[2])!;
                    autok.Remove(a);
                    return new Vétel(autokerek.Find(y => y.név == input[1])!, a, partners.Find(x => x.név == input[3])!, input[4], int.Parse(input[5]));
                }
                else if (input[0] == "adás")
                {
                    return new Adás(autokerek.Find(y => y.név == input[1])!, autokerek.Find(y => y.név == input[1])?.autók.Find(y => y.id == input[2])!, partners.Find(x => x.név == input[3])!, input[4], int.Parse(input[5]));
                }
                else
                {
                    throw new SzerzodesTypeNotValidException();
                }
        }
        #endregion
    }
}