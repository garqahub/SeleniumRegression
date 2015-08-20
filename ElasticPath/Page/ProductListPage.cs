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
    class ProductListPage
    {
        WebDriverBackedSelenium driver;
        //IWebElement price, shopByPriceFilter1, shopByPriceFilter2, shopByPriceFilter3, shopByBrandFilter1,
         //   shopByBrandFilter2, shopByBrandFilter3, shopByBrandFilter4, shopByBrandFilter5, productNameDiv,
        //    categoryDiv, sideMenuDiv;
        QualityCheck quality;

        public ProductListPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            quality = new QualityCheck(test);
            //price = driver.UnderlyingWebDriver.FindElement(By.Id("Sort lowest to highest")); //Unable to find.  Look to use Selenium commands
            /*
            shopByPriceFilter1 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[1]/li[1]/a"));
            shopByPriceFilter2 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[1]/li[3]/a"));
            shopByPriceFilter3 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[1]/li[3]/a"));
            shopByBrandFilter1 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[2]/li[1]/a"));
            shopByBrandFilter2 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[2]/li[2]/a"));
            shopByBrandFilter3 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[2]/li[3]/a"));
            shopByBrandFilter4 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[2]/li[4]/a"));
            shopByBrandFilter5 = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/ul[2]/li[5]/a"));
            productNameDiv = driver.UnderlyingWebDriver.FindElement(By.Id("product-grid-1"));
            categoryDiv = driver.UnderlyingWebDriver.FindElement(By.ClassName("category"));
            sideMenuDiv = driver.UnderlyingWebDriver.FindElement(By.XPath("//div[@id='side-menu']/h2/.."));
            */
        }

        public void verifyCorrectPageIsDisplayed()
        {
            /*
            List<IWebElement> divList = driver.UnderlyingWebDriver.FindElements(By.Id("product-grid-1"));
            Assert.assertTrue("Product List page verification failed", divList.Count > 0);
             */
        }

        public void clickProductLink(string productName)
        {
            Thread.Sleep(1000);
            IWebElement productLink = driver.UnderlyingWebDriver.FindElement(By.PartialLinkText(productName));
            productLink.Click();
        }

        public void verifyCurrency_US()
        {
            quality.IsTextPresent("$");
            /*
            Assert.assertTrue("Product List currency verification failed", price.Text.Contains("$"));
             */
        }

        public void verifyCurrency_UK()
        {
            quality.IsTextPresent("Â£");
            /*
            Assert.assertTrue("Product List currency verification failed", price.Text.Contains("Â£"));
             */
        }

        public void verifyCurrency_BE()
        {
            /*
            Assert.assertTrue("Product List currency verification failed", price.Text.Contains("â‚¬"));
             */
        }

        public void verifyShopByPriceFilter1(string priceRange)
        {
            /*
            Assert.assertTrue("Price Filter1 verification failed", shopByPriceFilter1.Text.Contains(priceRange));
             */
        }

        public void verifyShopByPriceFilter2(string priceRange)
        {
            /*
            Assert.assertTrue("Price Filter2 verification failed", shopByPriceFilter2.Text.Contains(priceRange));
             */
        }

        public void verifyShopByPriceFilter3(string priceRange)
        {
            /*
            Assert.assertTrue("Price Filter3 verification failed", shopByPriceFilter3.Text.Contains(priceRange));
             */
        }

        public void verifyShopByBrandFilter1(string brand)
        {
            /*
            Assert.assertTrue("Brand Filter1 verification failed", shopByBrandFilter1.getText().contains(brand));
             */
        }

        public void verifyShopByBrandFilter2(string brand)
        {
            /*
            Assert.assertTrue("Brankd Filter2 verification failed", shopByBrandFilter2.getText().contains(brand));
             */
        }

        public void verifyShopByBrandFilter3(string brand)
        {
            /*
            Assert.assertTrue("Brankd Filter3 verification failed", shopByBrandFilter3.getText().contains(brand));
             */
        }

        public void verifyShopByBrandFilter4(string brand)
        {
            /*
            Assert.assertTrue("Brankd Filter4 verification failed", shopByBrandFilter4.getText().contains(brand));
             */
        }

        public void verifyShopByBrandFilter5(string brand)
        {
            /*
            Assert.assertTrue("Brankd Filter5 verification failed", shopByBrandFilter5.getText().contains(brand));
             */
        }

        public void verifyDutchProductName(string productName)
        {
            /*
            Assert.assertTrue("Product Dutch name verification failed", productNameDiv.getText().contains(productName));
             */
        }

        public void verifyFrenchProductName(string productName)
        {
            /*
            Assert.assertTrue("Product French name verification failed", productNameDiv.getText().contains(productName));
             */
        }

        public void verifyDutchCategoryName(string categoryName)
        {
            /*
            Assert.assertTrue("Category Dutch name verification failed", categoryDiv.getText().equals(categoryName));
             */
        }

        public void verifyFrenchCategoryName(string categoryName)
        {
            /*
            Assert.assertTrue("Category French name verification failed", categoryDiv.getText().equals(categoryName));
             */
        }

        public void verifyDutchText(string categoryName, string productName)
        {
            this.verifyDutchCategoryName(categoryName);
            this.verifyDutchProductName(productName);

            string[] sideMenus = { "NL_RECHERCHER PAR PRIX", "NL_RECHERCHER PAR MARQUE" };
            foreach (string sideMenu in sideMenus)
            {
                /*
                Assert.assertTrue("Side-menu Dutch verification failed", sideMenuDiv.getText().toUpperCase().contains(sideMenu));
                 */
            }
        }

        public void verifyFrenchText(string categoryName, string productName)
        {
            this.verifyFrenchCategoryName(categoryName);
            this.verifyFrenchProductName(productName);

            string[] sideMenus = { "RECHERCHER PAR PRIX", "RECHERCHER PAR MARQUE" };
            foreach (string sideMenu in sideMenus)
            {
                quality.IsTextPresent(sideMenu);
                /*
                Assert.assertTrue("Side-menu French verification failed", sideMenuDiv.getText().toUpperCase().contains(sideMenu));
                 */
            }
        }



    }
}
