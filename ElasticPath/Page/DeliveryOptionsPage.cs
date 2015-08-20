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

    class DeliveryOptionsPage
    {
        WebDriverBackedSelenium driver;
        IWebElement continueBtn;
        QualityCheck quality;

        public DeliveryOptionsPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            /*
            continueBtn = driver.UnderlyingWebDriver.FindElement(By.ClassName("checkout-button"));
             */
            quality = new QualityCheck(test);
        }

      
	public void verifyCorrectPageIsDisplayed() 
    {
        //Todo: change up validations.
		/*
		List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.Id("checkout-delivery-options"));
		Assert.assertTrue("Delivery Options page verification failed", divList.size() > 0);
         */ 
	}
	
	public void clickContinueButton()
    {
        quality.IsTextPresent("My Order");
        continueBtn = driver.UnderlyingWebDriver.FindElement(By.Name("submit order"));
		continueBtn.Click();
	}

    }
}
