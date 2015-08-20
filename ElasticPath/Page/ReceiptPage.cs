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
    class ReceiptPage
    {
        WebDriverBackedSelenium driver;
        QualityCheck quality;

        public ReceiptPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            quality = new QualityCheck(test);
        }

        public void verifyCorrectPageIsDisplayed()
        {
            quality.Highlight("id=checkout-review-order-details");
            /*
            List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.Id("checkout-review-order-details"));
            Assert.assertTrue("Receipt page verification failed", divList.Count > 0);
             * 
             */
        }

        public void verifyOrderNumberExists()
        {
            //Need to address and capture once off of production
            //IWebElement orderTableCell = driver.UnderlyingWebDriver.FindElement(By.XPath("//tr[@id='order-number' and @class='order-details']/td[@id='number']"));													 
            /*
		Assert.assertTrue("There is no Order Number on receipt page", orderTableCell.Text.Trim().Length > 0);             
		System.out.println("Order number.......................... (" + orderTableCell.Text+")");			
             */
        }

    }
}
