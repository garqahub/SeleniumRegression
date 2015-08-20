#region Using Statements
using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Web;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using Selenium;
using System.IO;
#endregion

namespace SeleniumRegression
{
    class ShippingAddressPage
    {
        WebDriverBackedSelenium driver;
        IWebElement newAddressOption;
        QualityCheck quality;

        public ShippingAddressPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            quality = new QualityCheck(test);
            /*
            newAddressOption = driver.UnderlyingWebDriver.FindElement(By.Id("newAddressRadio"));
             */ 

        }
        
        public void selectNewAddressOption()
        {
            newAddressOption = driver.UnderlyingWebDriver.FindElement(By.Id("newAddressRadio"));
            newAddressOption.Click();
        }
        
    }
}
