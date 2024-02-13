using Autokeresked�s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;

namespace AutokerTest
{
    [TestClass]
    public class BeolvasTest
    {
        /*
        [TestMethod]
        public void BeolvasAut�keresked�sekTest()
        {
            List<Aut�ker> aut�kerek = new List<Aut�ker>();
            Program.BeolvasAut�keresked�sek("autokerInput.txt",aut�kerek);

            Assert.AreEqual(2,aut�kerek.Count);
        }
        [TestMethod]
        public void BeolvasAut�kTest()
        {
            List<Aut�ker> aut�kerek = new List<Aut�ker>();
            Program.BeolvasAut�keresked�sek("autokerInput.txt", aut�kerek);
            List<Aut�> aut�k = new List<Aut�>();
            Program.BeolvasAut�k("autokInput.txt", aut�k, aut�kerek);

            Assert.AreEqual(9,aut�k.Count);
            Assert.AreEqual(6, aut�kerek[0].aut�k.Count);
            Assert.AreEqual(6, aut�kerek[1].aut�k.Count);
        }
        [TestMethod]
        public void BeolvaPartnerekTest()
        {
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasPartnerek("partnerekInput.txt",partnerek);

            Assert.AreEqual(2,partnerek.Count);
        }
        [TestMethod]
        public void BeolvasSzerz�d�sekTest()
        {
            List<Aut�ker> aut�kerek = new List<Aut�ker>();
            Program.BeolvasAut�keresked�sek("autokerInput.txt", aut�kerek);
            List<Aut�> aut�k = new List<Aut�>();
            Program.BeolvasAut�k("autokInput.txt", aut�k, aut�kerek);
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasPartnerek("partnerekInput.txt", partnerek);

            Program.BeolvasSzerz�d�sek("szerz�d�sekInput.txt", aut�kerek,aut�k,partnerek);

            Assert.AreEqual(8, aut�k.Count);
            Assert.AreEqual(7, aut�kerek[0].aut�k.Count);
            Assert.AreEqual(6, aut�kerek[1].aut�k.Count);
            Assert.AreEqual(2, partnerek.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(VanIlyenNev�AutokerException))]
        public void BeolvasUgyanolyanN�vAut�keresked�sekTest()
        {
            List<Aut�ker> aut�kerek = new List<Aut�ker>();
            Program.BeolvasAut�keresked�sek("autokerHibasInput.txt", aut�kerek);
        }
        */
        [TestMethod]
        public void BeolvasEgybenTest()
        {
            List<Aut�ker> aut�kerek = new List<Aut�ker>();
            List<Aut�> aut�k = new List<Aut�>();
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasEgyben("inputEgyben.txt", aut�kerek, aut�k, partnerek);

            Assert.AreEqual(2, aut�kerek.Count);

            Assert.AreEqual(2, partnerek.Count);

            Assert.AreEqual(8, aut�k.Count);
            Assert.AreEqual(7, aut�kerek[0].aut�k.Count);
            Assert.AreEqual(6, aut�kerek[1].aut�k.Count);
            Assert.AreEqual(2, partnerek.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(VanIlyenNev�AutokerException))]
        public void BeolvasUgyanolyanN�vAut�keresked�sekTest()
        {
            List<Aut�ker> aut�kerek = new List<Aut�ker>();
            List<Aut�> aut�k = new List<Aut�>();
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasEgyben("autokerHibasInput.txt", aut�kerek, aut�k, partnerek);
        }
    }
}