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
    class CreateAddressPage
    {

        private IWebElement firstName;
        private IWebElement lastName;
        private IWebElement addressLine1;
        private IWebElement addressLine2;
        private IWebElement city;
        private IWebElement state;
        private IWebElement country;
        private IWebElement zip;
        private IWebElement phone;
        private IWebElement preferredShippingAddressChkBox;
        WebDriverBackedSelenium driver;
        bool duringCheckout;
        QualityCheck quality;
        Address address;
        Customer customer;

        public CreateAddressPage(Customer consumer, WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            this.customer = consumer;
            address = new Address(customer);
            customer.setAddress(address);
            quality = new QualityCheck(test);
        }

        public void assignElements()
        {
            Thread.Sleep(1000);

            if (duringCheckout)
            {
               
                firstName = driver.UnderlyingWebDriver.FindElement(By.Name("firstName"));
                lastName = driver.UnderlyingWebDriver.FindElement(By.Name("lastName"));
                addressLine1 = driver.UnderlyingWebDriver.FindElement(By.Name("street1"));
                addressLine2 = driver.UnderlyingWebDriver.FindElement(By.Name("street2"));
                city = driver.UnderlyingWebDriver.FindElement(By.Name("city"));
                state = driver.UnderlyingWebDriver.FindElement(By.Name("stateProvince"));
                country = driver.UnderlyingWebDriver.FindElement(By.Name("country"));
                zip = driver.UnderlyingWebDriver.FindElement(By.Name("zipPostalCode"));
                phone = driver.UnderlyingWebDriver.FindElement(By.Name("phoneNumber"));
            }
            else
            {
                Thread.Sleep(1000);
                firstName = driver.UnderlyingWebDriver.FindElement(By.Name("firstName"));
                lastName = driver.UnderlyingWebDriver.FindElement(By.Name("lastName"));
                addressLine1 = driver.UnderlyingWebDriver.FindElement(By.Name("street1"));
                addressLine2 = driver.UnderlyingWebDriver.FindElement(By.Name("street2"));
                city = driver.UnderlyingWebDriver.FindElement(By.Name("city"));
                state = driver.UnderlyingWebDriver.FindElement(By.Name("stateProvince"));
                country = driver.UnderlyingWebDriver.FindElement(By.Name("country"));
                zip = driver.UnderlyingWebDriver.FindElement(By.Name("zipPostalCode"));
                phone = driver.UnderlyingWebDriver.FindElement(By.Name("phoneNumber"));
                //preferredShippingAddressChkBox = driver.UnderlyingWebDriver.FindElement(By.XPath("//input[@name='preferredShippingAddress']"));
            }
        }
        public void verifyCorrectPageIsDisplayed_US_UK(bool duringCheckout)
        {
            this.duringCheckout = duringCheckout;
            this.assignElements();
            //To Do:Validation
            /*
            if (duringCheckout)
            {
                IWebElement addressForm = driver.UnderlyingWebDriver.FindElement(By.Name("checkoutAddressFormBean"));
                Assert.assertTrue("'Where is this order being shipped to?' text is not present on create-address.ep", addressForm.getText().contains("Where is this order being shipped to?"));
            }
            else
            {
                IWebElement addressForm = driver.UnderlyingWebDriver.FindElement(By.Name("address"));
                Assert.assertTrue("'Create New Address' text is not present on create-address.ep", addressForm.getText().contains("Create New Address"));
            }
             */ 
        }

        public void verifyCorrectPageIsDisplayed_BE(bool duringCheckout)
        {
            this.duringCheckout = duringCheckout;
            this.assignElements();
            //todo:validation
            /*
            if (duringCheckout)
            {
                WebElement addressForm = driver.findElement(By.name("checkoutAddressFormBean"));
                Assert.assertTrue("'l_OÃ¹ envoyer la commande?' text is not present on create-address.ep", addressForm.getText().contains("l_OÃ¹ envoyer la commande?"));
            }
            else
            {
                WebElement addressForm = driver.findElement(By.name("address"));
                Assert.assertTrue("'nl_Entrer une nouvelle adresse' text is not present on create-address.ep", addressForm.getText().contains("nl_Entrer une nouvelle adresse"));
            }
             */ 
        }

        public void enterFirstName(String firstName)
        {
            this.firstName.Clear();
            this.firstName.SendKeys(firstName);
            address.setFirstName(firstName);
        }

        public void enterLastName(String lastName)
        {
            this.lastName.Clear();
            this.lastName.SendKeys(lastName);
            address.setLastName(lastName);
        }

        public void enterAddressLine1(String addressLine1)
        {
            this.addressLine1.Clear();
            this.addressLine1.SendKeys(addressLine1);
            address.setAddressLine1(addressLine1);
        }

        public void enterAddressLine2(String addressLine2)
        {
            this.addressLine2.Clear();
            this.addressLine2.SendKeys(addressLine2);
            address.setAddressLine2(addressLine2);
        }

        public void enterCity(String city)
        {
            this.city.Clear();
            this.city.SendKeys(city);
            address.setCity(city);
        }

        public void selectCountry(String countryselect)
        {
            quality.Select("country" , countryselect);
 
            address.setCountry(countryselect);
        }

        public void selectState(string stateselect)
        {
            quality.Select("stateProvince", stateselect);

            address.setState(stateselect);
        }

        public void enterZip(string zip)
        {
            this.zip.Clear();
            this.zip.SendKeys(zip);
            address.setZip(zip);
        }

        public void enterPhone(string phone)
        {
            this.phone.Clear();
            this.phone.SendKeys(phone);
            address.setPhone(phone);
        }

        public void checkPreferredBillingAddressBox()
        {

            //driver.Check("defaultShippingAddressUID");
            /*
            address.setPreferredBillingAddress(true);
            address.setPreferredBillingAddress_img("https://us.garmin.com:8443/storefront/template-resources/images/ico-checkmark.gif");
            if (!this.preferredShippingAddressChkBox.Selected)
            {
                this.preferredShippingAddressChkBox.Click();
            }
             */ 
        }

        public void unCheckPreferredBillingAddressBox()
        {
            address.setPreferredBillingAddress(false);
            address.setPreferredBillingAddress_img("--");
            if (this.preferredShippingAddressChkBox.Selected)
            {
                this.preferredShippingAddressChkBox.Click();
            }
        }

        public void clickAddUpdateAddressBtn_US_UK()
        {
            IWebElement saveAndContinueOrAddOrEditBtn = null;
            if (duringCheckout)
            {
                saveAndContinueOrAddOrEditBtn = driver.UnderlyingWebDriver.FindElement(By.Name("save & continue"));
            }
            else if (!duringCheckout)
            {
                saveAndContinueOrAddOrEditBtn = driver.UnderlyingWebDriver.FindElement(By.Name("submit"));
            }
            else
            {
                saveAndContinueOrAddOrEditBtn = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='   Update Address    ']"));
            }
            saveAndContinueOrAddOrEditBtn.Click();
        }

        public void clickAddAddressBtn_BE()
        {
            IWebElement saveAndContinueOrAddOrEditBtn = null;
            if (duringCheckout)
            {
                saveAndContinueOrAddOrEditBtn = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='nl_Valider et continuer']"));
            }
            else if (!duringCheckout)
            {
                saveAndContinueOrAddOrEditBtn = driver.UnderlyingWebDriver.FindElement(By.Name("submit"));
            }
            else
            {
                saveAndContinueOrAddOrEditBtn = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@class='fieldset-footer']/input[@value='   nl_Mettre Ã  jour une adresse    ']"));
            }
            saveAndContinueOrAddOrEditBtn.Click();
        }

        private void addAddress()
        {

            this.enterAddressLine1(address.getAddressLine1());

            String addressLine_2 = address.getAddressLine2();

            if (addressLine_2 != null && addressLine_2.Length > 0)
                this.enterAddressLine2(addressLine_2);

            this.enterCity(address.getCity());
            this.selectCountry(address.getCountry());
            this.selectState(address.getState());
            this.enterZip(address.getZip());
            this.enterPhone(address.getPhone());
            //		this.clickAddAddressBtn();
        }

        public void addAddress_BE()
        {
            //		address.setFirstName(customer.getFirstName());
            //		address.setLastName(customer.getLastName());
            address.setAddressLine1("555 Belgium Street");
            address.setCity("Belgium City");
            address.setState("");
            address.setCountry("Belgium");
            address.setZip("BE001");
            address.setPhone("32-555-123-4567");
            this.addAddress();
            this.clickAddAddressBtn_BE();
        }

        public void addAddress_US()
        {
            this.addAddress();
            this.clickAddUpdateAddressBtn_US_UK();
        }

        public void addAddress_UK()
        {
            //		address.setFirstName(customer.getFirstName());
            //		address.setLastName(customer.getLastName());
            address.setAddressLine1("555 London Street");
            address.setCity("London");
            address.setState("CI");
            address.setCountry("United Kingdom");
            address.setZip("UK001");
            address.setPhone("44-20-555-1234");
            this.addAddress();
            this.clickAddUpdateAddressBtn_US_UK();
        }

    }
}
