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
#endregion

namespace SeleniumRegression
{
    class BillingAddressPage
    {
        WebDriverBackedSelenium driver;
        //private IWebElement continueButton;
        IWebElement radioButton;
        List<IWebElement> addressTable;
        //ParentTest test;
        QualityCheck quality;

        public BillingAddressPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            //continueButton = driver.UnderlyingWebDriver.FindElement(By.ClassName("checkout-button"));
            addressTable = new List<IWebElement>();
            quality = new QualityCheck(test);
        }
 
	
	
	public void verifyCorrectPageIsDisplayed() 
    {
        foreach (IWebElement address in driver.UnderlyingWebDriver.FindElements(By.Id("choose-address")))
        {
            addressTable.Add(address);
        }
		//addressTable = driver.UnderlyingWebDriver.FindElements(By.Id("choose-address"));
        //find way to validate address
		//Assert.assertTrue("Billing Address page validation failed", addressTable.size() > 0);
	}
	public void chooseFirstAddress()
    {
		radioButton = driver.UnderlyingWebDriver.FindElement(By.XPath("//table[@id='choose-address']/tbody/tr/td/input"));
		radioButton.Click();
	}
	
	public void clickContinueButton()
    {
        quality.Click("checkout-button");
        //continueButton = driver.UnderlyingWebDriver.FindElement(By.ClassName("checkout-button"));
		//this.continueButton.Click();
	}

    }
}
