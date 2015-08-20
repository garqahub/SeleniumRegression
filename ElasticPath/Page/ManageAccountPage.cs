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
    class ManageAccountPage
    {
        WebDriverBackedSelenium driver;
        private IWebElement /*addAddressBtn_US_UK,*/ addAddressBtn_BE, div;
        QualityCheck quality;

        public ManageAccountPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            quality = new QualityCheck(test);
            /*
            addAddressBtn_US_UK= driver.UnderlyingWebDriver.FindElement(By.XPath("//input[@value='Add Address']"));
            addAddressBtn_BE = driver.UnderlyingWebDriver.FindElement(By.XPath("//input[@value='nl_Ajouter Addresse']"));
             */ 
        }



	public void verifyCorrectPageIsDisplayed_US_UK() 
    {  //Add Validations
        Thread.Sleep(3000);
		div = driver.UnderlyingWebDriver.FindElement(By.PartialLinkText("Account"));

        /*
		Assert.assertTrue("'My Personal Info' text is not present on manage-account.ep", div.Text.Contains("My Personal Info"));
         */

        div.Click();
        driver.WaitForPageToLoad("3000");
        quality.IsTextPresent("Personal Information");
        quality.IsTextPresent("Order Information");
	}
	
	public void verifyCorrectPageIsDisplayed_BE() 
    {//add validation
		div = driver.UnderlyingWebDriver.FindElement(By.Id("account-personal-info"));
        /*
		Assert.assertTrue("'nl_Vos informations personnelles' text is not present on manage-account.ep", div.Text.Contains("nl_Vos informations personnelles"));
         */ 
	}
	
	public void clickAddAddressBtn_US_UK()
    {
        //addAddressBtn_US_UK = driver.UnderlyingWebDriver.FindElement(By.LinkText("Add Addresses"));
		//addAddressBtn_US_UK.Click();
        driver.Click("link=Add Addresses");
	}
	
	public void clickAddAddressBtn_BE()
    {
        addAddressBtn_BE = driver.UnderlyingWebDriver.FindElement(By.LinkText("Ajouter une adresses"));
		addAddressBtn_BE.Click();
	}
	
	public void verifyMyAddressBook(List<Address> addressList)
    {
		
		//Collections.reverse(addressList);
		/*
		IWebElement myAddressBook = driver.UnderlyingWebDriver.FindElement(By.Name("defaultShippingAddressUID"));
		int addressRows = myAddressBook.FindElements(By.TagName("tr")).Count;
		myAddressBook = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='account-address-book']/fieldset/table/tbody/tr"));
		int addressColumns = myAddressBook.FindElements(By.TagName("td")).Count;
		
		
		for(int i = 0; i < addressList.Count; i++){
			
			Address _address = addressList[i];
			
			String name = _address.getFirstName() + " " + _address.getLastName();
			string[] address = {"",name, _address.getAddressLine1(), _address.getCity(), _address.getState(), _address.getZip(), _address.getPreferredBillingAddress_img()};
			
			for(int x = 0; x < addressColumns; x++){
					//add validations
					
					if(x != 0)
                    {
						if(x == 6 && !address[x].Equals("--")){
							IWebElement img = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='account-address-book']/fieldset/table/tbody/tr["+(i+1)+"]/td["+(x+1)+"]/img"));
                            /*
							Assert.assertEquals("Preferred address image verification failed",address[x], img.GetAttribute("src"));
                             */ 
                        /*
						}else{
							string columnText = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='account-address-book']/fieldset/table/tbody/tr["+(i+1)+"]/td["+(x+1)+"]")).Text;
                            /*
							System.out.println("columnText .... " + columnText);
							System.out.println("listText .... " + address[x]);
							Assert.assertEquals("'My Address Book' is not displaying correct address",address[x], columnText);
                             */ 
					//	}
			//	}
            
			//}
		//}
	}


    }
}
