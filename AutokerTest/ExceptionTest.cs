using Autokereskedés;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;

namespace AutokerTest
{
    [TestClass]
    public class ExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(Autóker.AutokerNincsIlyenAutoException))]
        public void AutókerElad_NincsAutoException()
        {
            Autóker testKer = new Autóker("testKer"); 
            Autó testAuto = new Audi("testkocsi1", 2002, 2000000, Dízel.Instance());
            testKer.Elad(testAuto,new Partner("Zoli"),"ma",100);
        }
        [TestMethod]
        [ExpectedException(typeof(Autóker.AutoMarTulajdonException))]
        public void AutókerVétel_NincsAutoException()
        {
            Autóker testKer = new Autóker("testKer");
            Autó testAuto = new Audi("testkocsi1", 2002, 2000000, Dízel.Instance());
            testKer.Vesz(testAuto, new Partner("Zoli"), "ma", 100);
            testKer.Vesz(testAuto, new Partner("Zoli"), "ma", 100);    
        }
        [TestMethod]
        [ExpectedException(typeof(AutoNullException))]
        public void NullAutoVétel() 
        {
            Autó nullAuto = null;
            Autóker testKer = new Autóker("testKer");
            testKer.Vesz(nullAuto, new Partner("Zoli"), "ma", 100);
        }
        [TestMethod]
        [ExpectedException(typeof(Autóker.AutokerNincsIlyenAutoException))]
        public void NullAutoElad()
        {
            Autó nullAuto = null;
            Autóker testKer = new Autóker("testKer");
            testKer.Elad(nullAuto, new Partner("Zoli"), "ma", 100);
        }

    }
}
