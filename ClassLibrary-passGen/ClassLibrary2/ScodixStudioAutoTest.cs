using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper;
using OpenQA.Selenium.Winium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Scodix.Testing.ScodixStudio
{
    [TestFixture]
    public class ARP
    {
        static WiniumDriver StationDriver = null;
        public ARP()
        {
            if (StationDriver == null)
            {
                DesktopOptions options = new DesktopOptions();
                options.ApplicationPath = @"C:\Program Files\ScodixStudio_ScodixStudio1.1.51\Scodix\Bin\ScodixRIPServer.exe";
                StationDriver = new WiniumDriver(@"C:\winium", options);
                // Wait.Wait1(10000);
            }
        }
        [OneTimeSetUp]
        public void CleanFolders()
        {

            StationDriver.FindElement(By.Name("Clear Succeeded")).Click();
            StationDriver.FindElement(By.Name("Yes")).Click();

            StationDriver.FindElement(By.Name("Clear Failed")).Click();
            StationDriver.FindElement(By.Name("Yes")).Click();

            StationDriver.FindElement(By.Name("Clear CMYK Objects")).Click();
            StationDriver.FindElement(By.Name("Yes")).Click();

        }

        [Test, Order(1)]
        public void EditArpOpenWindow()
        {
            Click.ClickByName(StationDriver, "New Job");
            //Click.ClickByName(StationDriver, "...");          


            // if (!StationDriver.FindElement(By.Name("CMYK Objects Registration")).Selected)
            // {
            //    Click.ClickByNameAndId(StationDriver, "CMYK Objects Registration", "");
            // }

            Click.ClickByNameAndId(StationDriver, "CMYK Objects Registration", "");

            Click.ClickById(StationDriver, "btnOpenFile");
            Click.doubleClickByName(StationDriver, "HSB-3009-01 -  B2, 700x500, NO OPA _UV.pdf");

            Click.ClickById(StationDriver, "BtnOpenCMYK");
            Click.doubleClickByName(StationDriver, "HSB-3009-01 - CMYK, B2, 700x500.pdf");

            Click.ClickById(StationDriver, "CmbPolymer");
            Click.doubleClickByName(StationDriver, "PS500");
            Click.ClickById(StationDriver, "RadioSense");
            // Click.ClickByNameAndId(StationDriver, "Enable Barcode", "");

            Click.ClickByName(StationDriver, "Generate");
            Click.ClickByName(StationDriver, "Save");    //added by Haim
            Wait.Wait1(25000);
            Click.ClickByName(StationDriver, "CMYK Objects Jobs");
            Wait.Wait1(25000);

            /*
            Click.ClickByCor(StationDriver, "Edit", 1300, 160);
            Wait.Wait1(3000);
            Assert.IsTrue(Element.ElementExistByName(StationDriver, "CMYK Objects Detection "));
            Click.ClickByName(StationDriver, "Cancel");
            */
        }

        /*

        [Test,Order(2)]
        public void AutomaticSearchLow()
        {
            Click.ClickByCor(StationDriver, "Edit", 1300, 160);
            Wait.Wait1(3000);
            Click.ClickByName(StationDriver, "Auto CMYK");
            Wait.Wait1(65000);
            Assert.IsTrue(StationDriver.FindElementByName("Cancel").Displayed);
            Click.ClickByName(StationDriver, "Cancel");
        }

        [Test,Order(3)]
        public void StopArpWhileSearching()
        {
            Click.ClickByCor(StationDriver, "Edit", 1300, 160);
            Wait.Wait1(3000);
            Click.ClickByName(StationDriver, "Auto CMYK");
            Click.ClickByName(StationDriver, "Stop CMYK");
            Click.ClickByName(StationDriver, "OK");
            Click.ClickByName(StationDriver, "Cancel");
        }

        [Test,Order(4)]
        public void DisableSaveButtonWhileSearching()
        {
            Click.ClickByCor(StationDriver, "Edit", 1300, 160);
            Wait.Wait1(3000);
            Click.ClickByName(StationDriver, "Auto CMYK");
            Assert.IsTrue(StationDriver.FindElementByName("Save CMYK").Enabled);
            Click.ClickByName(StationDriver, "Cancel");
        }

        [Test,Order(5)]
        public void AutoSearchLowToSucceeded()
        {
            Click.ClickByCor(StationDriver, "Edit", 1300, 160);
            Wait.Wait1(3000);
            Click.ClickByName(StationDriver, "Auto CMYK");
            Wait.Wait1(65000);
            Click.ClickByName(StationDriver, "Save CMYK");
            Click.ClickByName(StationDriver, "Succeeded Jobs");
            Assert.IsTrue(Element.ElementExistByName(StationDriver,"HSB-3009-01 -  B2, 700x500, NO OPA _UV"));          
        }

       */


        //[Test,Order(7)]
        //public void AbleToEditJob()
        //{
        //    Click.ClickByName(StationDriver, "Edit Job");
        //    Click.ClickByName(StationDriver, "Generate");
        //    Wait.Wait1(20000);
        //    Click.ClickByName(StationDriver, "ARP Jobs");
        //    Assert.IsTrue(Element.ElementExistByName(StationDriver, "HSB-3009-01 -  B2, 700x500, NO OPA _UV"));
        //}

        //[Test, Order(6)]
        //public void VisualizeAutoSearchArp()
        //{
        //    Click.ClickByName(StationDriver, "Edit ARP");
        //    //Click.ClickById(StationDriver, "CmbStrategy");
        //    ////Click.ClickByName(StationDriver, "Low precision");
        //    //Click.doubleClickByName(StationDriver, "Low precision");
        //    Click.ClickByName(StationDriver, "Visualize Auto Search ARP");
        //    Click.ClickByName(StationDriver, "Auto ARP");
        //    Assert.IsTrue(Element.ElementExistById(StationDriver, "TitleBar"));
        //    Click.ClickByName(StationDriver, "Stop ARP");
        //    Click.ClickByName(StationDriver, "OK");
        //    Click.ClickByName(StationDriver, "Cancel");
        //}

    }
}

