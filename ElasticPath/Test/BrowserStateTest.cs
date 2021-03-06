﻿#region Using Statements
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
    class BrowserStateTest : ParentTest
    {

        HomePage homePage;
        CategoryPage categoryPage;
        ProductListPage productListPage;
        ProductPage productPage;


        public BrowserStateTest(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            base.id = "Browser State Test";
            base.baseURL = url;
            base.selenium = webdriver;
            base.verificationErrors = verrors;


        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        [Test]
        public override void RunTest()
        {
            testBrowseStore_US();
            //testBrowseStore_UK();      //Navigation is different.  Will need to create new method to test.
            //testBrowseStore_BE();      //Deactivated due to confusion on what localization is being tested
            //testBrowseStore_Digital(); //Deactivated due to confusion on what localization is being tested

        }
        #endregion

        public void testBrowseStore_US()
        {
            homePage = new HomePage(selenium, this);
            categoryPage = new CategoryPage(selenium, this);
            productListPage = new ProductListPage(selenium, this);
            productPage = new ProductPage(selenium, this);

            homePage.openUSHomePage();
            //homePage.deleteCookies();
            homePage.verifyCorrectPageIsDisplayed_US();
            homePage.browseToCategoryOnTopMenu("On the Road");
            string[] subCategories_onTheRoad = { "Motorcycles", "Automotive", "Trucking" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheRoad);

            homePage.browseToCategoryOnTopMenu("On the Go");
            string[] subCategories_onTheGo = { "Track & Locate", "Apps", "Phones" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheGo);

            homePage.browseToCategoryOnTopMenu("On the Trail");
            string[] subCategories_onTheTrail = { "Basic Handhelds", "Mapping Handhelds", "Two Way Radio", "Dog Tracking" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheTrail);

            homePage.browseToCategoryOnTopMenu("Into Sport");
            string[] subCategories_intoSport = { "Running", "Cycling", "Golfing" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_intoSport);

            homePage.browseToCategoryOnTopMenu("On the Road");
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheRoad);
            categoryPage.clickOnSubCategory("Motorcycles");
            productListPage.verifyCorrectPageIsDisplayed();
            //productListPage.verifyShopByPriceFilter1("> $300");
            //productListPage.verifyShopByBrandFilter1("Prestige Series");
            productListPage.verifyCurrency_US();
            productListPage.clickProductLink("220");

            productPage.verifyCorrectPageIsDisplayed();
            productPage.selectProductSku("zumo 220, North America");
            productPage.verifyCurrency_US();

            homePage.browseToCategoryOnTopMenu("On the Road");
            categoryPage.clickOnSubCategory("Automotive");
            //productListPage.verifyShopByPriceFilter1("< $100");
            //productListPage.verifyShopByPriceFilter2("$100 - 200");
            //productListPage.verifyShopByBrandFilter1("Nuvi");
            productListPage.verifyShopByBrandFilter2("Prestige Series");
            productListPage.verifyShopByBrandFilter3("Essential Series");
            productListPage.verifyShopByBrandFilter4("Zumo");
            productListPage.verifyShopByBrandFilter5("Advanced Series");
        }


        public void testBrowseStore_UK()
        {

            homePage.openUKHomePage();
            homePage.deleteCookies();
            selenium.Select("languageSelect", "United Kingdom - English");
            homePage.verifyCorrectPageIsDisplayed_UK();
            homePage.browseToCategoryOnTopMenu("uk_On the Road");
            string[] subCategories_ukOnTheRoad = { "uk_Motorcycles", "uk_Automotive", "uk_Trucking"  };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_ukOnTheRoad);

            homePage.browseToCategoryOnTopMenu("uk_Maps");
            string[] subCategories_ukMaps = { "uk_Scotland", "uk_England", "uk_Ireland" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_ukMaps);

            homePage.browseToCategoryOnTopMenu("uk_Into Sport");
            string[] subCategories_ukIntoSport = { "uk_Running", "uk_Cycling", "uk_Golfing" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_ukIntoSport);

            homePage.browseToCategoryOnTopMenu("uk_On the Road");
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_ukOnTheRoad);
            categoryPage.clickOnSubCategory("uk_Motorcycles");

            productListPage.verifyCorrectPageIsDisplayed();
            productListPage.verifyCurrency_UK();
           // productListPage.verifyShopByPriceFilter1("> Â£240");
           // productListPage.verifyShopByBrandFilter1("uk_Prestige Series");
            productListPage.clickProductLink("zumo 220");

            productPage.verifyCorrectPageIsDisplayed();
            productPage.selectProductSku("zumo 220, North America");
            productPage.verifyCurrency_UK();

            homePage.browseToCategoryOnTopMenu("uk_On the Road");
            categoryPage.clickOnSubCategory("uk_Automotive");
          //  productListPage.verifyShopByPriceFilter1("< Â£80");
          //  productListPage.verifyShopByPriceFilter2("Â£80 - 160");
          //  productListPage.verifyShopByPriceFilter3("Â£160 - 240");
            productListPage.verifyShopByBrandFilter1("uk_Nuvi");
            productListPage.verifyShopByBrandFilter2("uk_Prestige Series");
            productListPage.verifyShopByBrandFilter3("uk_Essential Series");
            productListPage.verifyShopByBrandFilter4("uk_Zumo");
            productListPage.verifyShopByBrandFilter5("uk_Advanced Series");

        }


        public void testBrowseStore_BE()
        {

            homePage.openBEHomePage();
            homePage.deleteCookies();
            selenium.Select("languageSelect", "United Kingdom - English");
            homePage.verifyCorrectPageIsDisplayed_BE();
            homePage.browseToCategoryOnTopMenu("du_On the Road");

            categoryPage.verifyCorrectPageIsDisplayed(categoryPage.subCategories_duOnTheRoad);

            homePage.browseToCategoryOnTopMenu("fr_Maps");
            categoryPage.verifyNoSubCategoryExists();

            homePage.browseToCategoryOnTopMenu("du_Into Sport");
            String[] subCategories_duIntoSport = { "du_Running", "du_Cycling", "du_Golfing" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_duIntoSport);

            homePage.browseToCategoryOnTopMenu("du_On the Road");
            categoryPage.verifyCorrectPageIsDisplayed(categoryPage.subCategories_duOnTheRoad);
            categoryPage.clickOnSubCategory("du_Automotive");
            productListPage.verifyCorrectPageIsDisplayed();
            productListPage.verifyCurrency_BE();
           // productListPage.verifyShopByPriceFilter1("< â‚¬80");
          //  productListPage.verifyShopByPriceFilter2("â‚¬160 - 240");
          //  productListPage.verifyShopByBrandFilter1("du_Nuvi");
            productListPage.verifyShopByBrandFilter2("du_Prestige Series");
            productListPage.verifyShopByBrandFilter3("du_Essential Series");
            productListPage.verifyShopByBrandFilter4("du_Zumo");
            productListPage.verifyShopByBrandFilter5("du_Advanced Series");

            productListPage.clickProductLink("Draagtas");

            productPage.verifyCorrectPageIsDisplayed();
            productPage.verifyCurrency_BE();

            homePage.browseToCategoryOnTopMenu("du_On the Road");
            categoryPage.clickOnSubCategory("du_Motorcycles");
          //  productListPage.verifyShopByPriceFilter1("> â‚¬240");
            productListPage.verifyShopByBrandFilter1("du_Prestige Series");
        }


        public void testBrowseStore_Digital()
        {

            homePage.openDigitalHomePage();
            homePage.deleteCookies();
            homePage.verifyCorrectPageIsDisplayed_US();
            homePage.browseToCategoryOnTopMenu("On the Road");
            string[] subCategories_onTheRoad = { "Motorcycles", "Automotive", "Trucking"};
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheRoad);

            homePage.browseToCategoryOnTopMenu("On the Go");
            string[] subCategories_onTheGo = { "Track & Locate", "Apps", "Phones" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheGo);

            homePage.browseToCategoryOnTopMenu("On the Trail");
            string[] subCategories_onTheTrail = { "Basic Handhelds", "Mapping Handhelds", "Two Way Radio", "Dog Tracking" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_onTheTrail);

            homePage.browseToCategoryOnTopMenu("Into Sport");
            string[] subCategories_intoSport = { "Running", "Cycling", "Golfing" };
            categoryPage.verifyCorrectPageIsDisplayed(subCategories_intoSport);

            homePage.browseToCategoryOnTopMenu("On the Road");
            categoryPage.clickOnSubCategory("Automotive");
            productListPage.verifyCorrectPageIsDisplayed();
           // productListPage.verifyShopByPriceFilter1("< $100");
           // productListPage.verifyShopByBrandFilter1("Nuvi");
            productListPage.verifyShopByBrandFilter2("Prestige Series");
            productListPage.verifyShopByBrandFilter3("Essential Series");
            productListPage.verifyShopByBrandFilter4("Zumo");
            productListPage.verifyShopByBrandFilter5("Advanced Series");
            productListPage.verifyCurrency_US();
            productListPage.clickProductLink("Approach® S1");
            productPage.verifyCorrectPageIsDisplayed();
            productPage.verifyCurrency_US();

        }

    }
}
