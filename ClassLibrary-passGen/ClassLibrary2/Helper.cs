using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;

namespace Helper
{
    public class Click
    {
        public static void ClickByName(WiniumDriver _driver, string element)
        {
            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    _driver.FindElementByName(element).Click();
                    //Thread.Sleep(100);
                    break;
                }
                catch (Exception e)
                {
                    Thread.Sleep(100);
                }
            }
        }

        public static void ClickByNamePartialName(WiniumDriver _driver, string element)
        {
            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    _driver.FindElementByPartialLinkText(element).Click();
                    //Thread.Sleep(100);
                    break;
                }
                catch (Exception e)
                {
                    Thread.Sleep(100);
                }
            }
        }


        public static void Click2(WiniumDriver _driver, string element, string element1)
        {
            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    _driver.FindElementByName(element).FindElement(By.Name(element1)).Click();
                    Thread.Sleep(100);
                    break;
                }
                catch (Exception e)
                {
                    Thread.Sleep(1000);
                }
            }

        }

        public static void ClickByClassName(WiniumDriver _driver, string element, string element1)
        {
            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    _driver.FindElementByClassName(element).FindElement(By.Name(element1)).Click();
                    Thread.Sleep(100);
                    break;
                }
                catch (Exception e)
                {
                    Thread.Sleep(1000);
                }
            }

        }

        public static int ClickEnable(WiniumDriver _driver, string elementName)
        {
            try
            {
                _driver.FindElementByName(elementName).Click();
                return 0;
            }

            catch
            {
                return 1;
            }

        }

        public static int ClickIsEnableByClass(WiniumDriver _driver, string elementName, string classname)
        {
            try
            {
                _driver.FindElementByClassName(classname).FindElement(By.Name(elementName)).Click();
                return 0;
            }

            catch
            {
                return 1;
            }

        }

        public static void doubleClickByName(WiniumDriver _driver, string element1)
        {
            Thread.Sleep(100);
            Actions action = new Actions(_driver);
            var element = _driver.FindElement(By.Name(element1));
            Thread.Sleep(1000);

            //Double click
            action.DoubleClick(element).Perform();
        }

        public static void doubleClickById(WiniumDriver _driver, string element1)
        {
            Thread.Sleep(100);
            Actions action = new Actions(_driver);
            var element = _driver.FindElement(By.Id(element1));
            Thread.Sleep(20000);

            //Double click
            action.DoubleClick(element).Perform();
        }

        public static void ClickLeft(WiniumDriver _driver, string a)
        {
            Actions action1 = new Actions(_driver);
            var element1 = _driver.FindElement(By.Name(a));
            action1.ContextClick(element1).SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown).SendKeys(Keys.Return).Build().Perform();
        }

        public static void DoubleClickByClass(WiniumDriver driver, string classname, string elemenetname)
        {
            Thread.Sleep(10000);
            Actions action = new Actions(driver);
            var element = driver.FindElement(By.ClassName(classname)).FindElement(By.Name(elemenetname));
            Thread.Sleep(20000);

            //Double click
            action.DoubleClick(element).Perform();
        }

        public static void ClickById(WiniumDriver _driver, string id)
        {
            _driver.FindElementById(id).Click();
        }

        public static void ClickByClassNameAndId(WiniumDriver _driver, string classname, string id)
        {
            _driver.FindElementByClassName(classname).FindElement(By.Id(id)).Click();
        }

        public static void ClickByNameAndId(WiniumDriver _driver, string elementname, string elementid)
        {
            _driver.FindElementByName(elementname).FindElement(By.Id(elementid)).Click();
        }

        public static void PressEnterById(WiniumDriver _driver, string id)
        {
            _driver.FindElement(By.Id(id)).SendKeys(Keys.Return);
        }

        public static void ClickByCor(WiniumDriver _driver, string elementname, int x, int y)
        {
            var element = _driver.FindElement(By.Name(elementname));
            new Actions(_driver).MoveToElement(element).MoveByOffset(x, y).Click().Perform();
        }

        public static void ClickByXpath(WiniumDriver _driver, string xpath)
        {
            _driver.FindElement(By.XPath(xpath)).Click();
        }

        public static void DoubleClickByCordinate(WiniumDriver _driver, string element1, int x, int y)
        {
            var element = _driver.FindElement(By.Id(element1));
            new Actions(_driver).MoveToElement(element).MoveByOffset(x, y).DoubleClick().Perform();
        }

    }
}

