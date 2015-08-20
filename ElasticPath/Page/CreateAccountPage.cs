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
    class CreateAccountPage
    {
        WebDriverBackedSelenium driver;
        IWebElement name, emailAddress, userName, password, passwordConfirmation, createAccountBtn;
        Customer customer;
        List<string> windowSet;
        List<string> windowIterator;
        IWebElement newAccountDiv;
        QualityCheck quality;
        ConnectUtility utility;

        public CreateAccountPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            customer = new Customer();
            windowSet = new List<string>();
            /*
            name = driver.UnderlyingWebDriver.FindElement(By.Id("name"));
            userName = driver.UnderlyingWebDriver.FindElement(By.Id("username"));
            emailAddress = driver.UnderlyingWebDriver.FindElement(By.Id("email"));
            phone = driver.UnderlyingWebDriver.FindElement(By.Id("phoneNumber"));
            password = driver.UnderlyingWebDriver.FindElement(By.Id("password"));
            passwordConfirmation = driver.UnderlyingWebDriver.FindElement(By.Id("passwordMatch"));
            createAccountBtn = driver.UnderlyingWebDriver.FindElement(By.Id("submitBtn"));
            continueBtn_BE = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='nl_Continuer']"));
             */
            quality = new QualityCheck(test);
            utility = new ConnectUtility(test);
        }


        //	@FindBy(xpath = "//div[@class='fieldset-footer']/input[@value='Continue']")
        //	private WebElement continueBtn;
        //	@FindBy(id = "GAuth-content")
        //	private WebElement newAccountDiv;


        //	WebDriver popup;

        public void verifyCorrectPageIsDisplayed_US_UK()
        {
            
            foreach (string window in driver.UnderlyingWebDriver.WindowHandles)
            {
                windowSet.Add(window);
            }
            
            windowIterator = windowSet;
            for (int i = 0; i < windowIterator.Count; i++)
            {
                
                driver.UnderlyingWebDriver.SwitchTo().Window(windowIterator[i]);
                if (driver.UnderlyingWebDriver.Title.Contains("Create An Account"))
                {
                    break;
                }
            }


            newAccountDiv = driver.UnderlyingWebDriver.FindElement(By.Id("GAuth-content"));
            string divText = newAccountDiv.Text;
            //todo: validation
            /*
            string pageText = "Please complete the fields below:";
            Assert.assertTrue("'" + pageText + "' text is not present create account page", divText.contains(pageText));
             */
            name = driver.UnderlyingWebDriver.FindElement(By.Id("name"));
            userName = driver.UnderlyingWebDriver.FindElement(By.Id("username"));
            emailAddress = driver.UnderlyingWebDriver.FindElement(By.Id("email"));
            //phone = driver.UnderlyingWebDriver.FindElement(By.Id("phoneNumber"));
            password = driver.UnderlyingWebDriver.FindElement(By.Id("password"));
            passwordConfirmation = driver.UnderlyingWebDriver.FindElement(By.Id("passwordMatch"));
            createAccountBtn = driver.UnderlyingWebDriver.FindElement(By.Id("submitBtn"));
            //continueBtn_BE = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='nl_Continuer']"));
        }

        public void verifyCorrectPageIsDisplayed_BE()
        {
            newAccountDiv = driver.UnderlyingWebDriver.FindElement(By.Id("GAuth-content"));
            string divText = newAccountDiv.Text;
            //To Do: Validations
            /*
            string pageText = "nl_Souscrivez au bulletin de Electronics";
            Assert.assertTrue("'" + pageText + "' text is not present on checkout-create-account.ep", divText.contains(pageText));
             */ 
        }

        public void enterName(String name)
        {
            quality.Type("id=name", name);
            //this.name.Clear();
            //this.name.SendKeys(name);
            //customer.setName(name);
        }

        //	public void enterLastName(String lname){
        //		this.lastName.clear();
        //		this.lastName.sendKeys(lname);
        //		customer.setLastName(lname);
        //	}

        public void enterEmailAddress(string emailAddress)
        {
            quality.Type("id=email", emailAddress);
            //this.emailAddress.Clear();
            //this.emailAddress.SendKeys(emailAddress);
            //customer.setEmailAddress(emailAddress);
        }

        public void enterUserName(string userName)
        {
            quality.Type("id=username", userName);
            //this.userName.Clear();
            //this.userName.SendKeys(userName);
            //customer.setUserName(userName);
        }

        public void enterPhone(string phone)
        {
            //this.phone.Clear();
            //this.phone.SendKeys(phone);
            customer.setPhone(phone);
        }

        //	public void clickSubscriptionCheckBox(){
        //		this.toBeNotified.click();
        //	}

        public void enterPassword(string password)
        {
            this.password = driver.UnderlyingWebDriver.FindElement(By.Id("password"));
            this.password.Clear();
            this.password.SendKeys(password);
            customer.setPassword(password);
        }

        public void enterPasswordConfirmation(string cfmPassword)
        {
            this.passwordConfirmation = driver.UnderlyingWebDriver.FindElement(By.Id("passwordMatch"));
            this.passwordConfirmation.Clear();
            this.passwordConfirmation.SendKeys(cfmPassword);
            customer.setConfirmPassword(cfmPassword);
        }

        //	public void clickContinueButton_US_UK(){
        //		this.continueBtn.click();
        //	}

        public void clickCreateAccountButton_US_UK()
        {
            string url = driver.UnderlyingWebDriver.Url;
            
            this.createAccountBtn.Click();
            //windowSet.Clear();
            Thread.Sleep(1000);
            foreach (string window in driver.UnderlyingWebDriver.WindowHandles)
            {
                windowSet.Add(window);
            }

            windowIterator = windowSet;
            for (int i = 0; i < windowIterator.Count; i++)
            {

                driver.UnderlyingWebDriver.SwitchTo().Window(windowIterator[i]);
                if (driver.UnderlyingWebDriver.Title.Contains("Store"))
                {
                    break;
                }
            }
           // driver.OpenWindow(url, "newwindow");
            //driver.SelectWindow("newwindow");
            //string[] windows = driver.GetAllWindowTitles();
            /*
            foreach (string window in windows)
            {
                driver.UnderlyingWebDriver.SwitchTo().Window(window);
                if (driver.UnderlyingWebDriver.Title.Contains("Digital cameras, digital camcorders, and telescopes - Electronics - Elastic Path Demo"))
                {
                    break;
                }
            }
            */
        }

        public void clickContinueButton_BE()
        {
            //this.continueBtn_BE.Click();
        }

        //	public void checkSubscriptionBox(){
        //		customer.setSubscription(true);
        //		if(!this.toBeNotified.isSelected())
        //			this.toBeNotified.click();
        //	}
        //	
        //	public void uncheckSubscriptionBox(){
        //		customer.setSubscription(false);
        //		if(this.toBeNotified.isSelected())
        //			this.toBeNotified.click();
        //	}
        //	
        //	public void verifySubscriptionIsChecked(){
        //		Assert.assertTrue("Subscription box is not checked", this.toBeNotified.isSelected());
        //	}
        //	
        //	public void verifySubscriptionIsNotChecked(){
        //		Assert.assertFalse("Subscription box is checked", this.toBeNotified.isSelected());
        //	}

        private void addCustomerInfo()
        {

            this.enterName(customer.getName());
            //		this.enterLastName(customer.getLastName());
            this.enterEmailAddress(customer.getEmailAddress());
            //		this.enterPhone(customer.getPhone());
            this.enterUserName(customer.getUserName());

            //		if(customer.isSubscription()){
            //			this.checkSubscriptionBox();
            //		}else{
            //			this.uncheckSubscriptionBox();
            //		}
            //		
            this.enterPassword(customer.getPassword());
            this.enterPasswordConfirmation(customer.getConfirmPassword());
        }

        public void addCustomerInfo_BE()
        {
            customer.setName("BE_Joe BE_Smith");
            //		customer.setLastName("BE_Smith");
            customer.setPhone("32-555-123-4567");
            this.addCustomerInfo();
            this.clickContinueButton_BE();
        }

        public void addCustomerInfo_US()
        {
            this.addCustomerInfo();
            this.clickCreateAccountButton_US_UK();
        }

        public void addCustomerInfo_UK()
        {
            customer.setName("UK_Joe UK_Smith");
            //		customer.setLastName("UK_Smith");
            customer.setPhone("44-20-555-1234");
            this.addCustomerInfo();
            this.clickCreateAccountButton_US_UK();
        }

        public Customer getCustomer()
        {
            return this.customer;
        }

        public void setCustomerInfo_UK()
        {
            customer.setName("UK_Joe UK_Smith");
            //		customer.setLastName("UK_Smith");
            customer.setPhone("44-20-555-1234");
        }

        public void setCustomerInfo_BE()
        {
            customer.setName("BE_Joe BE_Smith");
            //		customer.setLastName("BE_Smith");
            customer.setPhone("32-555-123-4567");
        }

    }
}
