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
    class Header
    {
        WebDriverBackedSelenium driver;
        //IWebElement headerDiv;
        //private IWebElement accountLink_US_UK;
        private IWebElement accountLink_BE;
        //private IWebElement cartLink;
        private string[] en_headerText_CustomerNotLoggedIn, du_headerText_CustomerNotLoggedIn,
            fr_headerText_CustomerNotLoggedIn, en_headerText_CustomerLoggedIn;
        //private SeleniumPropertyManager properties;
        //private string browser;
        string[] du_headerText_CustomerLoggedIn;
        string[] fr_headerText_CustomerLoggedIn;
        QualityCheck quality;

        //To Do: Rework verification
        public Header(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            /*
            headerDiv = driver.UnderlyingWebDriver.FindElement(By.LinkText("my account"));
            accountLink_US_UK = driver.UnderlyingWebDriver.FindElement(By.LinkText("nl_Votre compte"));
            accountLink_BE = driver.UnderlyingWebDriver.FindElement
                (By.XPath("//div[@id='account']/div/a[contains(@href, 'view-cart.ep')]"));
             */
            en_headerText_CustomerLoggedIn = new string[3];
            en_headerText_CustomerNotLoggedIn = new string[3];
            fr_headerText_CustomerLoggedIn = new string[3];
            fr_headerText_CustomerNotLoggedIn = new string[3];
            du_headerText_CustomerLoggedIn = new string[4];
            du_headerText_CustomerNotLoggedIn = new string[3];
            en_headerText_CustomerNotLoggedIn[0] = "items in my cart";
            en_headerText_CustomerNotLoggedIn[1] = "my account"; 
            en_headerText_CustomerNotLoggedIn[2] = "wish list";
            du_headerText_CustomerNotLoggedIn[0] = "nl_articles dans votre panier";
            du_headerText_CustomerNotLoggedIn[1] = "nl_Votre compte";
            du_headerText_CustomerNotLoggedIn[2] = "nl_Vos envies cadeaux";
            fr_headerText_CustomerNotLoggedIn[0] = "articles dans votre panier";
            fr_headerText_CustomerNotLoggedIn[1] = "Votre compte";
            fr_headerText_CustomerNotLoggedIn[2] = "Vos envies cadeaux";
            en_headerText_CustomerLoggedIn[0] = "items in my cart";
            en_headerText_CustomerLoggedIn[1] = "my account";
            en_headerText_CustomerLoggedIn[2] = "wish list";
            //properties = SeleniumPropertyManager.getInstance(properties); //These will be set up separately
            //browser = properties.getProperty();
            quality = new QualityCheck(test);
        }
        public void verifyDutchText_CustomerNotLoggedIn()
        {
            foreach (string header in this.du_headerText_CustomerNotLoggedIn)
            {
                quality.IsTextPresent(header);
                /*
                Assert.assertTrue("Dutch header varification faild", this.headerDiv.getText().contains(header));
                 */ 
            }
        }
        public void verifyFrenchText_CustomerNotLoggedIn()
        {
            foreach (string header in this.fr_headerText_CustomerNotLoggedIn)
            {
                quality.IsTextPresent(header);
                /*
                Assert.assertTrue("French header varification faild", this.headerDiv.Text.Contains(header));
                 */ 
            }
        }
        public void verifyDutchText_CustomerLoggedIn(String userName)
        {
            du_headerText_CustomerLoggedIn[0] = "Fermer la session";
            du_headerText_CustomerLoggedIn[1] = "Joe's Compte";
            du_headerText_CustomerLoggedIn[2] = "mon panier";
            foreach (string header in du_headerText_CustomerLoggedIn)
            {
                quality.IsTextPresent(header);
                /*
                Assert.assertTrue("Dutch header varification faild", this.headerDiv.Text.Contains(header));
                 */ 
            }
        }
        public void verifyFrenchText_CustomerLoggedIn(String userName)
        {
            fr_headerText_CustomerLoggedIn[0] = "Fermer la session";
            fr_headerText_CustomerLoggedIn[1] = "Joe's Compte";
            fr_headerText_CustomerLoggedIn[2] = "mon panier";
            foreach (string header in fr_headerText_CustomerLoggedIn)
            {
                quality.IsTextPresent(userName);
                /*
                Assert.assertTrue("French header varification faild", this.headerDiv.Text.Contains(header));
                 */ 
            }
        } /** * Browser to my account page. **/
        public void clickOnMyAccountLink_US_UK()
        {
            if (driver.IsElementPresent("link=Sign Out"))
            {
                driver.Click("link=Sign Out");
            }
            quality.Highlight("link=Sign In");
            driver.Click("link=Sign In");
            //accountLink_US_UK = driver.UnderlyingWebDriver.FindElement(By.LinkText("Sign In"));
            //accountLink_US_UK.Click();
            /*
            if (browser.Equals("internetexplorer"))
            {
                driver.Open("javascript:document.getElementById('overridelink').click()");
            }
             */ 
        }
        public void clickOnUserNameLink_US_UK(string userName)
        {
            IWebElement userNameLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("Joe's Account"));
            userNameLink.Click();
        }
        public void clickOnUserNameLink_BE(String userName)
        {
            IWebElement userNameLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("Joe's Compte"));
            userNameLink.Click();
        }
        public void clickOnMyAccountLink_BE()
        {
            accountLink_BE = driver.UnderlyingWebDriver.FindElement
                (By.XPath("//div[@id='account']/div/a[contains(@href, 'view-cart.ep')]"));
            accountLink_BE.Click();
            /*
            if (browser.Equals("internetexplorer"))
            {
                driver.Open("javascript:document.getElementById('overridelink').click()");
            }
             */ 
        }
        public void viewShoppingCart()
        {
            //cartLink.Click();
        }
    }
}
