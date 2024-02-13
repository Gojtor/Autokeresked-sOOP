using Autokereskedés;
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
        public void BeolvasAutókereskedésekTest()
        {
            List<Autóker> autókerek = new List<Autóker>();
            Program.BeolvasAutókereskedések("autokerInput.txt",autókerek);

            Assert.AreEqual(2,autókerek.Count);
        }
        [TestMethod]
        public void BeolvasAutókTest()
        {
            List<Autóker> autókerek = new List<Autóker>();
            Program.BeolvasAutókereskedések("autokerInput.txt", autókerek);
            List<Autó> autók = new List<Autó>();
            Program.BeolvasAutók("autokInput.txt", autók, autókerek);

            Assert.AreEqual(9,autók.Count);
            Assert.AreEqual(6, autókerek[0].autók.Count);
            Assert.AreEqual(6, autókerek[1].autók.Count);
        }
        [TestMethod]
        public void BeolvaPartnerekTest()
        {
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasPartnerek("partnerekInput.txt",partnerek);

            Assert.AreEqual(2,partnerek.Count);
        }
        [TestMethod]
        public void BeolvasSzerzõdésekTest()
        {
            List<Autóker> autókerek = new List<Autóker>();
            Program.BeolvasAutókereskedések("autokerInput.txt", autókerek);
            List<Autó> autók = new List<Autó>();
            Program.BeolvasAutók("autokInput.txt", autók, autókerek);
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasPartnerek("partnerekInput.txt", partnerek);

            Program.BeolvasSzerzõdések("szerzõdésekInput.txt", autókerek,autók,partnerek);

            Assert.AreEqual(8, autók.Count);
            Assert.AreEqual(7, autókerek[0].autók.Count);
            Assert.AreEqual(6, autókerek[1].autók.Count);
            Assert.AreEqual(2, partnerek.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(VanIlyenNevûAutokerException))]
        public void BeolvasUgyanolyanNévAutókereskedésekTest()
        {
            List<Autóker> autókerek = new List<Autóker>();
            Program.BeolvasAutókereskedések("autokerHibasInput.txt", autókerek);
        }
        */
        [TestMethod]
        public void BeolvasEgybenTest()
        {
            List<Autóker> autókerek = new List<Autóker>();
            List<Autó> autók = new List<Autó>();
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasEgyben("inputEgyben.txt", autókerek, autók, partnerek);

            Assert.AreEqual(2, autókerek.Count);

            Assert.AreEqual(2, partnerek.Count);

            Assert.AreEqual(8, autók.Count);
            Assert.AreEqual(7, autókerek[0].autók.Count);
            Assert.AreEqual(6, autókerek[1].autók.Count);
            Assert.AreEqual(2, partnerek.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(VanIlyenNevûAutokerException))]
        public void BeolvasUgyanolyanNévAutókereskedésekTest()
        {
            List<Autóker> autókerek = new List<Autóker>();
            List<Autó> autók = new List<Autó>();
            List<Partner> partnerek = new List<Partner>();
            Program.BeolvasEgyben("autokerHibasInput.txt", autókerek, autók, partnerek);
        }
    }
}