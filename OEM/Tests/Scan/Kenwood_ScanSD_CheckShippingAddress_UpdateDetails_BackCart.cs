﻿#region Test Information
/*
* Test Name:
* Author:
* Purpose/Description:
* Creation Date:
* Version: 
* Updated By:
* Updated Date:
*/
#endregion

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
using System.Drawing;
using Selenium;
#endregion


namespace SeleniumRegression
{
    //****Enter in desired test name in replace of EnterClassName****
    class Kenwood_ScanSD_CheckShippingAddress_UpdateDetails_BackCart : ParentTest
    {
        KenwoodFunctions ken;

        public Kenwood_ScanSD_CheckShippingAddress_UpdateDetails_BackCart(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "ScanSD_CheckShippingAddress_UpdateDetails_BackCart";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**ScanSD_CheckShippingAddress_UpdateDetails_BackCart**";
            ken = new KenwoodFunctions(quality, selenium);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {

            selenium.Open(base.baseURL);

            quality.AreEqual("Garmin Product Updates for Kenwood", quality.GetTitle());
            quality.Click("link=Sign In");
            quality.WaitForPageToLoad("30000");

            quality.AreEqual("Sign In", quality.GetTitle());

            ken.Login(username, password, fullname, false);

            //comment: Click on "Update" button from the "Product Updates" panel
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");

            ken.DeviceSelectionPage();

            //comment: Select the same device like the one from the XML
            quality.Select("id=headUnitRegionFilter", "label=All");
            quality.WaitForPageToLoad("30000");
            quality.Select("id=headUnitRegionFilter", "label=North America");
            quality.WaitForPageToLoad("30000");
            quality.Click("link=DNX7180");
            quality.WaitForPageToLoad("30000");

            ken.ModelIdentificationPage();

            //comment: click on "Read Media" button
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Scan Portable Media", quality.GetTitle());

            if (ken.CheckForTimeOut("Media Scan", "css=div.titleHeader-text", 61))
            {
                failedcheck++;
            }

            quality.AreEqual("Media Scan", quality.GetText("css=div.titleHeader-text"));
            quality.AreEqual("Scanning Your Portable Storage Device... Please wait", quality.GetText("id=messageText"));

            ken.DeviceInformationFoundPage(true);

            // comment: Click on the "Continue" button
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");

            ken.ProductUpdatesPage(true);

            // comment: Click on "Latest Map" button
            quality.Click("css=div.description > span");
            quality.WaitForPageToLoad("30000");

            //comment: Check the "Latest Map for Kenwood"
            ken.LatestMapForKenwoodPage(true);

            //comment: Click "Add to Cart" button without beeing logged-in
            quality.Click("css=a.button.left > span");
            quality.WaitForPageToLoad("30000");

            ken.ShoppingCartWithLatestMapToBuy();

            // comment: Click the "Checkout" button
            quality.Click("//form[@id='shoppingCartForm']/div[2]/div[4]/a[2]/span");
            quality.WaitForPageToLoad("30000");

            ken.CheckOutPage();

            // comment: Update the Shipping address fields
            quality.Type("id=shippingAddressfirstName", "ABC Tester");
            quality.Type("id=shippingAddresslastName", "EFG Tester");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=United States");
            quality.Type("id=shippingAddressaddress1", "lololol tester's address");
            quality.Type("id=shippingAddressaddress2", "qwerty tester's address");
            quality.Type("id=shippingAddresscity", "");
            quality.Type("id=shippingAddresscity", "Cluj");
            quality.Select("id=shippingAddressstate", "label=Alaska");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddresszipPostal", "99515");
            quality.Type("id=shippingAddressphone", "");
            quality.Type("id=shippingAddressphone", "789-555-888824");

            quality.Click("id=continueBtn");

            if (ken.CheckForTimeOut("City does not match zip/postal code. Please select a city from the list, or continue with the city you entered.", "css=#shippingAddress-city > div.formAlert > div.alert > span", 61))
            {
                failedcheck++;
            }


            quality.AreEqual("City does not match zip/postal code. Please select a city from the list, or continue with the city you entered.", quality.GetText("css=#shippingAddress-city > div.formAlert > div.alert > span"));

            //comment: Select the City typed
            quality.Select("id=shippingAddresscity", "label=Use what I entered");
            quality.Click("id=continueBtn");
            quality.WaitForPageToLoad("30000");

            // comment: Check that the "Billing Address" page is displayed
            if (ken.CheckForTimeOut("Edit", "link=Edit", 61))
            {

            }


            quality.AreEqual("Edit", quality.GetText("link=Edit"));
            quality.AreEqual("Shipping Address", quality.GetText("css=h2"));
            quality.AreEqual("Billing Address", quality.GetText("css=fieldset > div.formHead > h2"));
            quality.AreEqual("Payment Information", quality.GetText("css=#payment-information > fieldset > div.formHead > h2"));
            quality.AreEqual("Place Secure Order", quality.GetText("id=submitOrder"));

            //comment: Click on "Edit" button to edit the Shipping Address details
            quality.Click("link=Edit");
            quality.WaitForPageToLoad("30000");

            //comment: GO back to Shipping Address page
            ken.CheckOutPage();

            // comment: Update the Shipping address fields
            quality.Type("id=shippingAddressfirstName", "FirstName Tester");
            quality.Type("id=shippingAddresslastName", "LastName Tester");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=United States");
            quality.Type("id=shippingAddressaddress1", "AddressLine1 tester's address");
            quality.Type("id=shippingAddressaddress2", "AddressLine2 tester's address");
            quality.Type("id=shippingAddresscity", "");
            quality.Type("id=shippingAddresscity", "HILO");
            quality.Select("id=shippingAddressstate", "label=Hawaii");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddresszipPostal", "96720");
            quality.Type("id=shippingAddressphone", "");
            quality.Type("id=shippingAddressphone", "000-555-1212");

            quality.Click("id=continueBtn");
            quality.WaitForPageToLoad("30000");

            // comment: Check that the "Billing Address" page is displayed
            if (ken.CheckForTimeOut("Edit", "link=Edit", 61))
            {

            }

            quality.AreEqual("Edit", quality.GetText("link=Edit"));
            quality.AreEqual("Shipping Address", quality.GetText("css=h2"));
            quality.AreEqual("Billing Address", quality.GetText("css=fieldset > div.formHead > h2"));
            quality.AreEqual("Payment Information", quality.GetText("css=#payment-information > fieldset > div.formHead > h2"));
            quality.AreEqual("Place Secure Order", quality.GetText("id=submitOrder"));

            // comment: Go back to Cart and remove the product
            quality.AreEqual("Back to Cart", quality.GetText("id=cancelBtn"));
            quality.Click("css=a.margin-l5");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Shopping Cart", quality.GetTitle());
            try
            {
                quality.IsTrue(quality.IsTextPresent("remove"));
            }
            catch (Exception)
            {
                failedcheck++;
                quality.ErrorReport("remove not found", CheckType.Text);
            }
            quality.Click("link=remove");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Shopping Cart", quality.GetTitle());
            quality.AreEqual("Your Shopping Cart is currently empty", quality.GetText("css=div.cartEmpty"));

            ken.Logout();


        }
        #endregion


    }


}
