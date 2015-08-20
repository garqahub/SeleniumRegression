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
    class BillingAndReviewPage
    {
        WebDriverBackedSelenium driver;
        //private IWebElement cardHolderName, cardType, cardNumber, cvvCode, expiryMonth, expiryYear, saveCreditCard, 
        IWebElement checkoutBtn;
        private List<IWebElement> divList;
        QualityCheck quality;

        public BillingAndReviewPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            //cardHolderName = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.cardHolderName"));
            //cardType = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.cardType"));
            //cvvCode = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.cvv2Code"));
            //expiryMonth = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.expiryMonth"));
            //expiryYear = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.expiryYear"));
            //saveCreditCard = driver.UnderlyingWebDriver.FindElement(By.Name("saveCreditCardForFutureUse"));
            //checkoutBtn = driver.UnderlyingWebDriver.FindElement(By.ClassName("checkout-button"));
            //cardNumber = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.unencryptedCardNumber"));

            divList = new List<IWebElement>();
            quality = new QualityCheck(test);
        }

        
	
	public void verifyCorrectPageIsDisplayed() 
    {

        foreach (IWebElement div in driver.UnderlyingWebDriver.FindElements(By.Id("checkout-review-billing")))
        {
            divList.Add(div);
        }
		//List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.Id("checkout-review-billing"));
		//To Do: Needs checking added
        //Assert.assertTrue("Billing and Review page verification failed", divList.size() > 0);
	}
	
	public void selectCreditCard(string creditCard)
    {
        quality.Select("paymentType", creditCard);
		
	}
	
	public void enterCardHolderName(string name)
    {
        quality.Type("cardHolderName", name);
        //cardHolderName = driver.UnderlyingWebDriver.FindElement(By.Name("cardHolderName"));
		//this.cardHolderName.SendKeys(name);
	}
	
	public void enterCardNumber(string number)
    {
        quality.Type("cardNumber", number);
        //cardNumber = driver.UnderlyingWebDriver.FindElement(By.Name("cardNumber"));
		//this.cardNumber.SendKeys(number);
	}
	
	public void enterCvvCode(string cvvCode)
    {
        quality.Type("cardCvv2", cvvCode);

        //this.cvvCode = driver.UnderlyingWebDriver.FindElement(By.Name("cardCvv2"));
		//this.cvvCode.SendKeys(cvvCode);
	}
	
	public void selectExpiryMonth(string month)
    {
        //expiryMonth = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.expiryMonth"));
        quality.Select("expMonth", month);
	}
	
	public void selectExpiryYear(string year)
    {
        //expiryYear = driver.UnderlyingWebDriver.FindElement(By.Id("orderPaymentFormBean.expiryYear"));
        quality.Select("expYear", year);

	}
	
	public void clickSaveCreditCardCheckBox()
    {
        //saveCreditCard = driver.UnderlyingWebDriver.FindElement(By.Name("saveCreditCardForFutureUse"));
		//this.saveCreditCard.Click();
	}
	
	public void clickCheckoutButton()
    {
        //driver.Click("name=submit_order");
        checkoutBtn = driver.UnderlyingWebDriver.FindElement(By.Name("submit order"));
		this.checkoutBtn.Click();
	}
	
	public void enterCreditCardInfo()
    {
		this.selectCreditCard("Visa");
		this.enterCardHolderName("Joe Smith");
		this.enterCardNumber("4111111111111111");
		this.enterCvvCode("111");
		this.selectExpiryMonth("05");
		this.selectExpiryYear("2020");
		this.clickSaveCreditCardCheckBox();
	}
	
	public void submitOrder(){
		this.enterCreditCardInfo();
		this.clickCheckoutButton();
	}

    }
}
