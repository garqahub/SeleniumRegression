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
    class HomePage
    {
        WebDriverBackedSelenium driver;
        private IWebElement wishlistLink, searchInputText, searchButton, categoryDiv;
        //private SeleniumPropertyManager properties;
        private string usStoreURL;
        private string ukStoreURL;
        private string beStoreURL;
        private string digitalStoreURL;
        string[] dutchCategories, frenchCategories;
        QualityCheck quality;

        //To Do: Feed URL's
        public HomePage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            usStoreURL = test.baseURL;
            ukStoreURL = test.baseURL; //prod doesn't have a separate address for foreign languages
            beStoreURL = test.baseURL;
            digitalStoreURL = test.baseURL;//prod doesn't have a separate address for foreign languages
            dutchCategories = new string[3];
            frenchCategories = new string[3];
            driver.Open(usStoreURL);

            quality = new QualityCheck(test);

            Thread.Sleep(2000);
            searchInputText = driver.UnderlyingWebDriver.FindElement(By.Id("searchbox"));
                //By.XPath("//div[@id='search']//input[@name='keyWords']"));
            searchButton = driver.UnderlyingWebDriver.FindElement(By.ClassName("searchbutton"));
                //By.XPath("//div[@id='search']//input[@value='search']"));
            wishlistLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("my cart"));
            //wishlistLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("wish list"));
            //categoryDiv = driver.UnderlyingWebDriver.FindElement(By.Id("wrapper"));
            categoryDiv = driver.UnderlyingWebDriver.FindElement(By.Id("checkin"));

 
            //Investigate reworking URL's
            /*
            properties = SeleniumPropertyManager.getInstance();
            usStoreURL = properties.getProperty("selenium.session.baseurl.us");
            ukStoreURL = properties.getProperty("selenium.session.baseurl.uk");
            beStoreURL = properties.getProperty("selenium.session.baseurl.be");
            digitalStoreURL = properties.getProperty("selenium.session.baseurl.digital");
             */ 
            
        }



	public void openUSHomePage()
    {
		driver.Open(usStoreURL);
	}
	
	public void openUKHomePage()
    {
		driver.Open(ukStoreURL);
        quality.Select("languageSelect", "United Kingdom - English");
	}
	
	public void openBEHomePage()
    {
        driver.Open(beStoreURL);
        quality.Select("languageSelect", "Belgique - français");
	}
	
	public void openDigitalHomePage()
    {
		driver.Open(digitalStoreURL);
	}

    public void deleteCookies()
    {
        driver.UnderlyingWebDriver.Manage().Cookies.DeleteAllCookies();
        driver.Refresh();
        //searchInputText = driver.UnderlyingWebDriver.FindElement(
   // By.XPath("//div[@id='search']//input[@name='keyWords']"));
       // searchButton = driver.UnderlyingWebDriver.FindElement(
         //   By.XPath("//div[@id='search']//input[@value='search']"));
      //  wishlistLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("wish list"));
        //categoryDiv = driver.UnderlyingWebDriver.FindElement(By.Id("wrapper"));
    }
	
	public void verifyCorrectPageIsDisplayed_US() 
    {
		//Rework verification
        /* 
		List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.XPath("//img[@src='/storefront/template-resources/images/fp-cat-ico-digital-cameras.jpg']"));
		Assert.assertTrue("Home page verification failed", divList.Count > 0);
		
		IWebElement div = driver.FindElement(By.id("tabs10"));
		Assert.assertTrue("'Category name is not present", div.Text.Contains("On the Road"));
         */ 
	}
	
	public void verifyCorrectPageIsDisplayed_UK() 
    {
		
        /*
		List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.XPath("//img[@src='/storefront/template-resources/images/fp-cat-ico-digital-cameras.jpg']"));
		Assert.assertTrue("Home page verification failed", divList.Count > 0);
		
		IWebElement div = driver.UnderlyingWebDriver.FindElement(By.Id("tabs10"));
		Assert.assertTrue("'Category name is not present", div.Text.Contains("uk_On the Road"));
         */ 
	}
	
	public void verifyCorrectPageIsDisplayed_BE() 
    {   
		/*
		List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.XPath("//img[@src='/storefront/template-resources/images/fp-cat-ico-digital-cameras.jpg']"));
		Assert.assertTrue("Home page verification failed", divList.size() > 0);
		
		IWebElement div = driver.UnderlyingWebDriver.FindElement(By.Id("tabs10"));
		Assert.assertTrue("'Category name is not present", div.Text.Contains("du_On the Road"));
         */ 
	}
	
	/**
	 * Browse to specified category on top menu.
	 **/
	public void browseToCategoryOnTopMenu(string category) 
    {
        quality.Click("primary-devices");
        Thread.Sleep(1000);
        //quality.Highlight("primary-explore");
        //driver.Click("primary-device");
        //driver.WaitForFrameToLoad("menu-devices","1000");
        Thread.Sleep(1000);
		driver.UnderlyingWebDriver.FindElement(By.PartialLinkText(category)).Click();
	}

	/**
	 * Go directly to a page in store.
	 **/
	public void jumpToPage(string path) 
    {
		driver.Open(path);
	}

		
	/**
	 * Browse to a random category on the top menu.

	public void browseToRandomCategoryOnTopMenu() {
		Random random = new Random();

		String[] exclusions = properties.getPropertyAsArray("test.category.configurable", ",");
		Number numCat = browser.getXpathCount("//div[@id='tabs10']/ul/li");

		int rInt = random.nextInt(numCat) + 1;
		String cat = browser.getText("//div[@id='tabs10']/ul/li[${rInt}]/a/span");

		// Repick a category if category exists in exclusion list
		while(exclusions.any { cat == it.toString() }) {
			rInt = (rInt-1) % numCat;
			cat = browser.getText("//div[@id='tabs10']/ul/li[${rInt}]/a/span");
		}

		browser.clickAndWait("//div[@id='tabs10']/ul/li[${rInt}]/a/span");
	}
	**/

	/**
	 * Do a product search with given search term and category filter.
	 **/
	public void doAProductSearchWithCategory(string term, string category) 
    {
        //This may need further identification
		driver.Select("//div[@id='search']//select[@name='categoryId']",category);
		doAProductSearch(term);
	}	
		

	/**
	 * Do a product search with given search term using default category filter.
	 **/
	public void doAProductSearch(string term) 
    {
		searchInputText.SendKeys(term);
		searchButton.Click();
	}

	public void signOutOfCurrentCustomerSession() 
    {
		IWebElement clickHereIfNotMeLink = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='notme']/a"));
		if( clickHereIfNotMeLink.Displayed) 
        {
			clickHereIfNotMeLink.Click();
		}
	}


	
	
//	public void goToProductPage(String productcode){
//		driver.get(baseURL+"prod"+productcode+".html");
//	}
	
	/**
	* Browser to my wishlist page.
	**/
   public void clickOnMyWishList() {
	   //wishlistLink.Click();
   }

//   public void clickToLogin() {
//	   accountLink.click();
//   }
   
//   public void switchToFrench(){
//	   frenchLink.click();
//   }
   
   
   
   public void verifyDutchText()
   {
	   dutchCategories[0] = "du_On the Road";
       dutchCategories[1] = "fr_Maps";
       dutchCategories[2] = "du_Into Sport";
	   foreach (string dutchCategory in dutchCategories)
       {
           quality.IsTextPresent(dutchCategory);
           
           /*
		   Assert.assertTrue("Dutch category varification faild", this.categoryDiv.Text.Contains(dutchCategory));
            */ 
	   }
   }
   
   public void verifyFrenchText(){
	   frenchCategories[0] = "fr_On the Road"; 
       frenchCategories[1] = "fr_Maps";
       frenchCategories[2] = "fr_Into Sport";
	   foreach(string frenchCategory in frenchCategories)
       {
           quality.IsTextPresent(frenchCategory);
           /*
		   Assert.assertTrue("French category varification faild", this.categoryDiv.Text.Contains(frenchCategory));	   
            */ 
	   }
   }

//   
//   public void waitTimeouts(String loopcount) {
//	   int count = Integer.parseInt(loopcount)
//	   while (count>0){
//		   browser.pause(properties.getProperty("selenium.session.timeout"))
//		   browser.logIllegalState("warn", "paused "+count)
//		   count--
//	   }  
//   }

    }
}
