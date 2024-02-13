using Autokereskedés;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;

namespace AutokerTest
{
    [TestClass]
    public class OtherTest
    {
        [TestMethod]
        public void AutokerKonstruktorTest(){
            Autóker testKer = new Autóker("Test Kereskedés");
            Assert.AreEqual("Test Kereskedés",testKer.név);
            Assert.AreEqual(0, testKer.autók.Count);
            Assert.AreEqual(0, testKer.szerződések.Count);

        }
        [TestMethod]
        public void AutoÉrtékTest()
        {
            Autó testAutó = new Audi("testkocsi1", 2002, 2000, Dízel.Instance());
            Assert.AreEqual(1755, testAutó.Érték());
        }
        [TestMethod]
        public void AutoFaktorTest()
        {
            Autó testAudi1 = new Audi("testkocsi1", 2002, 2000000, Dízel.Instance());
            Autó testAudi2 = new Audi("testkocsi2", 2002, 2000000, Benzin.Instance());
            Autó testAudi3 = new Audi("testkocsi3", 2002, 2000000, Hibrid.Instance());
            Autó testAudi4 = new Audi("testkocsi4", 2002, 2000000, Elektromos.Instance());
            Autó testMazda1 = new Mazda("testkocsi5", 2002, 2000000, Dízel.Instance());
            Autó testMazda2 = new Mazda("testkocsi6", 2002, 2000000, Benzin.Instance());
            Autó testMazda3 = new Mazda("testkocsi7", 2002, 2000000, Hibrid.Instance());
            Autó testMazda4 = new Mazda("testkocsi8", 2002, 2000000, Elektromos.Instance());
            Autó testSkoda1 = new Skoda("testkocsi9", 2002, 2000000, Dízel.Instance());
            Autó testSkoda2 = new Skoda("testkocsi10", 2002, 2000000, Benzin.Instance());
            Autó testSkoda3 = new Skoda("testkocsi11", 2002, 2000000, Hibrid.Instance());
            Autó testSkoda4 = new Skoda("testkocsi12", 2002, 2000000, Elektromos.Instance());

            Assert.AreEqual(1755555, testAudi1.Érték());
            Assert.AreEqual(0.9, testAudi1.Faktor(testAudi1.hanyag));
            Assert.AreEqual(1.0, testAudi2.Faktor(testAudi2.hanyag));
            Assert.AreEqual(1.3, testAudi3.Faktor(testAudi3.hanyag));
            Assert.AreEqual(1.2, testAudi4.Faktor(testAudi4.hanyag));
            Assert.AreEqual(2.0, testMazda1.Faktor(testMazda1.hanyag));
            Assert.AreEqual(2.0, testMazda2.Faktor(testMazda2.hanyag));
            Assert.AreEqual(2.3, testMazda3.Faktor(testMazda3.hanyag));
            Assert.AreEqual(2.5, testMazda4.Faktor(testMazda4.hanyag));
            Assert.AreEqual(3.1, testSkoda1.Faktor(testSkoda1.hanyag));
            Assert.AreEqual(3.0, testSkoda2.Faktor(testSkoda2.hanyag));
            Assert.AreEqual(4.0, testSkoda3.Faktor(testSkoda3.hanyag));
            Assert.AreEqual(3.8, testSkoda4.Faktor(testSkoda4.hanyag));
        }
        [TestMethod]
        public void EladAutoTest()
        {
            Partner testPartner = new Partner("Test Partner");
            Autó testAutó = new Audi("testkocsi1", 2002, 2000000, Dízel.Instance());
            Autóker testKer = new Autóker("Test Kereskedés");
            testKer.autók.Add(testAutó);
            Assert.AreEqual(1, testKer.autók.Count);
            Assert.AreEqual(0, testKer.szerződések.Count);

            testKer.Elad(testKer.autók[0], testPartner, "testDátum",500);

            Assert.AreEqual(0, testKer.autók.Count);
            Assert.AreEqual(1, testKer.szerződések.Count);
            Assert.AreEqual("testkocsi1", testKer.szerződések[0].autó.id);
            Assert.AreEqual(testPartner, testKer.szerződések[0].partner);
            Assert.AreEqual("testDátum", testKer.szerződések[0].dátum);
            Assert.AreEqual(500, testKer.szerződések[0].ár);
        }
        [TestMethod]
        public void VeszAutoTest()
        {
            Partner testPartner = new Partner("Test Partner");
            Autóker testKer = new Autóker("Test Kereskedés");
            Autó testAutó=new Audi("testkocsi1", 2002, 2000000, Dízel.Instance()); 

            Assert.AreEqual(0, testKer.autók.Count);
            Assert.AreEqual(0, testKer.szerződések.Count);

            testKer.Vesz(testAutó, testPartner, "testDátum", 500);

            Assert.AreEqual(1, testKer.autók.Count);
            Assert.AreEqual(1, testKer.szerződések.Count);
            Assert.AreEqual("testkocsi1", testKer.szerződések[0].autó.id);
            Assert.AreEqual(testPartner, testKer.szerződések[0].partner);
            Assert.AreEqual("testDátum", testKer.szerződések[0].dátum);
            Assert.AreEqual(500, testKer.szerződések[0].ár);
        }
    }
}
