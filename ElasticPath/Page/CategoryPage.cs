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
    class CategoryPage
    {
        private IWebElement categoryDiv;
        public string[] subCategories_frOnTheRoad;
        public string[] subCategories_duOnTheRoad;
        //public IWebElement div;
        private WebDriverBackedSelenium driver;
        QualityCheck quality;


        public CategoryPage(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            subCategories_duOnTheRoad = new string[4];
            subCategories_frOnTheRoad = new string[4];
            subCategories_frOnTheRoad[0] = "fr_Motorcycles";
            subCategories_frOnTheRoad[1] = "fr_Automotive";
            subCategories_frOnTheRoad[2] = "fr_Trucking";
            subCategories_frOnTheRoad[3] = "fr_Maps";
            subCategories_duOnTheRoad[0] = "du_Motorcycles";
            subCategories_duOnTheRoad[1] = "du_Automotive"; 
            subCategories_duOnTheRoad[2] = "du_Trucking";
            subCategories_duOnTheRoad[3] = "du_Maps";
            categoryDiv = driver.UnderlyingWebDriver.FindElement(By.Id("Side"));
            quality = new QualityCheck(test);
        }



        public void verifyCorrectPageIsDisplayed(String[] subCategories)
        {
      //      div = driver.UnderlyingWebDriver.FindElement(By.Id("side-menu"));
            //To Do: Need to set up validation
            
            foreach(string subCategory in subCategories)
            {
                quality.IsTextPresent(subCategory);
                //Assert.assertTrue("'One or more sub-categories are missing", div.getText().contains(subCategory));
            }
             
        }

        public void verifyNoSubCategoryExists()
        {


            //To Do: Will need to rework validations
            /*
            List<IWebElement> categoryImage = driver.UnderlyingWebDriver.FindElements(By.ClassName("category-image"));

            Assert.assertTrue("This is not the category page", categoryImage.size() > 0);
		    */
            quality.ElementNotPresent("side-menu");
                            

            //IWebElement div = driver.UnderlyingWebDriver.FindElement(By.Id("side-menu"));

           // Assert.assertTrue("There should be no sub-categories on this page" , div.getText().trim().length() <= 0);
             
        }

        public void clickOnSubCategory(string subCategory)
        {
            Thread.Sleep(3000);
            //quality.Click(subCategory);
            //driver.Click(subCategory);
            IWebElement subCategoryLink = driver.UnderlyingWebDriver.FindElement(By.LinkText(subCategory));
            subCategoryLink.Click();
        }


        public void verifyDutchText()
        {

            foreach (string item in subCategories_duOnTheRoad)
            {
                quality.IsTextPresent(item);
            }
            //To Do: Work on validations
            /*
            for(String subCategory : this.subCategories_duOnTheRoad){
               Assert.assertTrue("Dutch subCategory varification faild", this.categoryDiv.getText().contains(subCategory));	   
            }
             */
        }

        public void verifyFrenchText()
        {

            foreach (string item in subCategories_frOnTheRoad)
            {
                quality.IsTextPresent(item);
            }
            //To Do: Work on validations
            /*
            for(String subCategory : this.subCategories_frOnTheRoad){
                Assert.assertTrue("French subCategory varification faild", this.categoryDiv.getText().contains(subCategory));	   
           }
             */
        }


    }
}
