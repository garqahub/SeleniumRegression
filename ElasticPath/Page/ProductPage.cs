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
    class ProductPage
    {

        WebDriverBackedSelenium driver;
        IWebElement price, addToCartBtn, productSku;
        QualityCheck qualtiy;

        public ProductPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            /*
            price = driver.UnderlyingWebDriver.FindElement(By.Id("lowestPrice"));
            addToCartBtn = driver.UnderlyingWebDriver.FindElement(By.Id("addToCartSubmit"));
            productSku = driver.UnderlyingWebDriver.FindElement(By.Id("productSku"));
             */
            qualtiy = new QualityCheck(test);
        }


	public void verifyCorrectPageIsDisplayed()
    {
        /*
		List<IWebElement> formList = driver.UnderlyingWebDriver.FindElements(By.Id("skuSelectForm"));
		Assert.assertTrue("Product page verification failed", formList.Count == 1);
         */ 
	}
	
	public void selectProductSku(string sku)
    {
        //Rework - not valid process
        driver.WaitForPageToLoad("30000");
        Thread.Sleep(1000);
        price = driver.UnderlyingWebDriver.FindElement(By.Id("productcopy"));
        productSku = driver.UnderlyingWebDriver.FindElement(By.PartialLinkText("Versions"));
        productSku.Click();
		//new Select (this.productSku).selectByVisibleText(sku);
	}
	
	public void verifyCurrency_US()
    {
		waitForText(price);
        /*
		Assert.assertTrue("Product List currency verification failed", price.getText().contains("$"));
         */ 
	}
	
	public void verifyCurrency_UK()
    {
		this.waitForText(price);
        /*
		Assert.assertTrue("Product List currency verification failed", price.getText().contains("Â£"));
         */ 
	}
	
	public void verifyCurrency_BE()
    {
		this.waitForText(price);
        /*
		Assert.assertTrue("Product List currency verification failed", price.getText().contains("â‚¬"));
         */ 
	}
	
	public void clickAddToCartButton()
    {
        Thread.Sleep(1000);
        addToCartBtn = driver.UnderlyingWebDriver.FindElement(By.PartialLinkText("Add"));
		this.waitForButtonEnabled(addToCartBtn);
		addToCartBtn.Click();
	}

    public void waitForText(IWebElement webElement)
    {
        int count = 0;

        while (webElement.Text.Length <= 0)
        {

            try
            {

                Thread.Sleep(1000);

            }
            catch (Exception)
            {
                //e.printStackTrace();  //alter error handling here
            }

            if (count == 5)
            {
                break;
            }
            count++;
        }
    }
	
	public void waitForButtonEnabled(IWebElement webElement){
		  int count = 0;
		  
			while(!webElement.Enabled){
				
				try {
					
					Thread.Sleep(1000);
					
				}catch (Exception) 
                {
					//e.printStackTrace(); //alter error handling here 
			  }
				
				if(count == 5){
					break;
				}
				count++;
			}
		}


    }
}
