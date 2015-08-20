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
    class SignInPage
    {
        WebDriverBackedSelenium driver;
        //private IWebElement accountDiv, registerButton, registerButton_BE;
        QualityCheck quality;

        public SignInPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            quality = new QualityCheck(test);
            /*
            accountDiv = driver.UnderlyingWebDriver.FindElement(By.Id("login-state-default"));
            registerButton = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='Register']"));
            registerButton_BE = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='nl_Registre']"));
             */ 

        }


        public void verifyCorrectPageIsDisplayed_US_UK()
        {
            Thread.Sleep(2000);
            IWebElement iframe = driver.UnderlyingWebDriver.FindElement(By.Id("gauth-widget-frame"));
            driver.UnderlyingWebDriver.SwitchTo().Frame(iframe);
            IWebElement signInDiv = driver.UnderlyingWebDriver.FindElement(By.Id("login-state-default"));
            quality.IsTextPresent("Garmin Account Sign In");
       
        }

        public void verifyCorrectPageIsDisplayed_BE()
        {

            IWebElement iframe = driver.UnderlyingWebDriver.FindElement(By.Id("gauth-widget-frame"));
            driver.UnderlyingWebDriver.SwitchTo().Frame(iframe);
            IWebElement signInDiv = driver.UnderlyingWebDriver.FindElement(By.Id("login-state-default"));
            /*
            Assert.assertTrue("'nl_Vous AVEZ un compte' text is not present on checkout-create-account.ep", accountDiv.getText().contains("nl_Vous AVEZ un compte"));
             */
        }

        public void clickOnRegisterButton_US_UK()
        {

           //registerButton.Click();
        }

        public void clickCreateNewAccountLink()
        {
            //driver.Refresh();
            //driver.SelectFrame("gauth-widget-frame");
            driver.WaitForPageToLoad("30000");
            //		this.waitForLinkToAppear("login-state-default");
            driver.Click("id=lnkCreateAccount");
            //		driver.switchTo().window(driver.getWindowHandle());

        }

        public void clickOnRegisterButton_BE()
        {
            //registerButton_BE.Click();
        }

        public void waitForLinkToAppear(String elementId)
        {
            int count = 0;

            while (driver.UnderlyingWebDriver.FindElements(By.Id(elementId)).Count <= 0)
            {

                try
                {

                    Thread.Sleep(1000);

                }
                catch (Exception)
                {//change error messages.
                    //e.printStackTrace();  
                }

                if (count == 5)
                {
                    break;
                }
                count++;
            }
        }



    }
}
