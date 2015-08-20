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
    class CartPage
    {

        WebDriverBackedSelenium driver;
        //private IWebElement checkoutBtn;
        //private SeleniumPropertyManager properties;
        //private String browser;
        QualityCheck quality;

        public CartPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            /*
            checkoutBtn = driver.UnderlyingWebDriver.FindElement(By.Name("cartCheckout"));
             */
            quality = new QualityCheck(test);

        }

        	/*
	public CartPage()
    {

        SeleniumPropertyManager.getInstance(ref properties);
		browser = properties.getProperty();
	}
             */ 
	
	public void verifyCorrectPageIsDisplayed()
    {
        foreach (IWebElement form in driver.UnderlyingWebDriver.FindElements(By.Name("shoppingCart")))
        {
            
        }
		//List<IWebElement> formList = driver.UnderlyingWebDriver.FindElements(By.Name("shoppingCart"));
		//Assert.assertTrue("Shopping Cart page verification failed", formList.size() == 1);
	}
	
	public void clickCheckoutButton()
    {
        quality.Click("cartCheckout");
        //checkoutBtn = driver.UnderlyingWebDriver.FindElement(By.Name("cartCheckout"));
		//checkoutBtn.Click();
		//if(browser.Equals("internetexplorer"))
			//driver.UnderlyingWebDriver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");	
    }


    }
}
