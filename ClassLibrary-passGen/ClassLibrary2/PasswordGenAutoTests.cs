using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PasswordGenAutoTest
{
    [TestFixture]
    public class PassGenTester
    {
        private string logPath = string.Empty;
        static WiniumDriver StationDriver = null;
        public PassGenTester()
        {
            if (StationDriver == null)
            {
                DesktopOptions options = new DesktopOptions();
                
                options.ApplicationPath = @"C:\Users\ramy.g\source\repos\WpfApp1\WpfApp1\bin\Debug\WpfApp1.exe";
                
                StationDriver = new WiniumDriver(@"C:\winium", options);
                Thread.Sleep(100);
            }
        }
        
        [Test, Order(1)]
        public void checkTest1()
        {
            StationDriver.FindElement(By.Id("SerialNamber_Tb")).SendKeys("8462");
            StationDriver.FindElement(By.Id("WindowsProductID_Tb")).SendKeys("6425");
            StationDriver.FindElement(By.Id("CSEname_Tb")).SendKeys("Giorgini");
            StationDriver.FindElement(By.Id("SCEilName_Tb")).SendKeys("Anton");
            StationDriver.FindElement(By.Id("ServiceCallNum_Tb")).SendKeys("052546885");
            StationDriver.FindElement(By.Id("CustomerName_Tb")).SendKeys("D'iantoni Kappazo");
            StationDriver.FindElement(By.Id("Ultra101_Rb")).Click();
            StationDriver.FindElement(By.Id("Foiler_Cb")).Click();
            StationDriver.FindElement(By.Id("FoilerNumber_Tb")).SendKeys("64852");
            StationDriver.FindElement(By.Id("CnC_Cb")).Click();
            StationDriver.FindElement(By.Id("OptionalPolymer_Cb")).Click();
            StationDriver.FindElement(By.Id("OptionalPolymer_Tb")).SendKeys("4");
            StationDriver.FindElement(By.Id("Crystal_Cb")).Click();
            StationDriver.FindElement(By.Id("Brail_Cb")).Click();
            StationDriver.FindElement(By.Id("Barcode_Cb")).Click();
            StationDriver.FindElement(By.Id("W2P_Rb")).Click();
            StationDriver.FindElement(By.Id("Win10_Cb")).Click();
            StationDriver.FindElement(By.Id("GetPasswordButton")).Click();
            Thread.Sleep(5000);
            StationDriver.FindElement(By.Id("2")).Click();


        }

        [Test, Order(2)]
        public void checkTest2()
        {
            StationDriver.FindElement(By.Id("SerialNamber_Tb")).SendKeys("8462");
            StationDriver.FindElement(By.Id("WindowsProductID_Tb")).SendKeys("6425");
            StationDriver.FindElement(By.Id("CSEname_Tb")).SendKeys("Giorgini");
            StationDriver.FindElement(By.Id("Ultra101_Rb")).Click();
            StationDriver.FindElement(By.Id("Foiler_Cb")).Click();
            StationDriver.FindElement(By.Id("FoilerNumber_Tb")).SendKeys("64852");
            StationDriver.FindElement(By.Id("CnC_Cb")).Click();
            
            
            StationDriver.FindElement(By.Id("Barcode_Cb")).Click();
            StationDriver.FindElement(By.Id("W2P_Rb")).Click();
            StationDriver.FindElement(By.Id("Win10_Cb")).Click();
            StationDriver.FindElement(By.Id("GetPasswordButton")).Click();
            Thread.Sleep(5000);
            StationDriver.FindElement(By.Id("2")).Click();


        }

        [Test, Order(3)]
        public void checkTest3()
        {

            StationDriver.FindElement(By.Id("SerialNamber_Tb")).SendKeys("64888975");
            StationDriver.FindElement(By.Id("WindowsProductID_Tb")).SendKeys("11456879");
            ;
            StationDriver.FindElement(By.Id("Ultra2Pro_Rb")).Click();
            
            StationDriver.FindElement(By.Id("OptionalPolymer_Tb")).SendKeys("654987231");
     
            StationDriver.FindElement(By.Id("Brail_Cb")).Click();
            
            StationDriver.FindElement(By.Id("Station_Rb")).Click();
         
            StationDriver.FindElement(By.Id("GetPasswordButton")).Click();
            Thread.Sleep(5000);
            StationDriver.FindElement(By.Id("2")).Click();
        }




    }
}
