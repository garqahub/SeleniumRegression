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
    class Kenwood_NoScanSD_CheckShippingAddress_Validation : ParentTest
    {
        KenwoodFunctions ken;
        public Kenwood_NoScanSD_CheckShippingAddress_Validation(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "NoScanSD_CheckShippingAddress_Validation";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**NoScanSD_CheckShippingAddress_Validation**";
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

            quality.Select("id=headUnitRegionFilter", "label=All");
            quality.WaitForPageToLoad("30000");
            quality.Select("id=headUnitRegionFilter", "label=Europe");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Select a Model", quality.GetTitle());

            //comment: Select a device 
            quality.Click("link=DNX7220");
            quality.WaitForPageToLoad("30000");

            ken.ProductUpdatesPage(true);

            // comment: Click on "Real-Time Traffic" button
            quality.Click("//div[@id='productUpdates']/a[2]/div/div/div");
            quality.WaitForPageToLoad("30000");

            //comment: Check the "Real traffic Subscription"
            ken.TrafficSubscriptionPage();

            //comment: Click on the first traffic subscription (North America)
            quality.Click("css=div.text");
            quality.WaitForPageToLoad("30000");

            ken.TrafficServicesForkenwoodPage();

            //comment: Click "Add to Cart" button without beeing logged-in
            quality.Click("css=a.button.left > span");
            quality.WaitForPageToLoad("30000");

            //comment: Validate the "Add to Cart: Traffic Subscription" page
            ken.AddToCartTrafficVerification(true);

            // comment: Type a Valid Unit ID
            quality.Type("id=unitId", "");
            quality.Type("id=unitId", "3422110080");
            quality.Click("//form[@id='verifyTrafficForm']/table/tbody/tr[5]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");

            ken.ShoppingCartWithTrafficSubscriptionToBuy(true);

            // comment: Click the "Checkout" button
            quality.Click("//form[@id='shoppingCartForm']/div[2]/div[4]/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.Select("id=shippingAddresscountry", "label=United States");

            ken.CheckOutPage();

            //comment: Empty all the requiered fields and press the "Continue" button
            quality.Type("id=shippingAddressfirstName", "");
            quality.Type("id=shippingAddresslastName", "");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Type("id=shippingAddressaddress1", "");
            quality.Type("id=shippingAddressaddress2", "");
            quality.Type("id=shippingAddresscity", "");
            quality.Select("id=shippingAddressstate", "label=Select a State/Province");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddressphone", "");
            quality.Type("id=shippingAddressphone", "");

            quality.Click("id=continueBtn");

            if (ken.CheckForTimeOut("This field is required.","css=div.alert > span", 61))
            {
                failedcheck++;
            }


            quality.AreEqual("This field is required.", quality.GetText("css=div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-last-name > div.formAlert > div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-country-region > div.formAlert > div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-address-line-1 > div.formAlert > div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-city > div.formAlert > div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-state-province > div.formAlert > div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-zip-postal-code > div.formAlert > div.alert > span"));
            quality.AreEqual("This field is required.", quality.GetText("css=#shippingAddress-phone > div.formAlert > div.alert > span"));

            // comment: State doesn't match the the zip code
            quality.Type("id=shippingAddressfirstName", "ABC Tester");
            quality.Type("id=shippingAddresslastName", "EFG Tester");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=United States");
            quality.Type("id=shippingAddressaddress1", "lololol tester's address");
            quality.Type("id=shippingAddressaddress2", "qwerty tester's address");
            quality.Type("id=shippingAddresscity", "HILO");
            quality.Select("id=shippingAddressstate", "label=Idaho");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddresszipPostal", "96720");
            quality.Type("id=shippingAddressphone", "");
            quality.Type("id=shippingAddressphone", "789-555-888824");

            quality.Click("id=continueBtn");

            if (ken.CheckForTimeOut("State does not match zip/postal code.", "css=#shippingAddress-state-province > div.formAlert > div.alert > span", 61))
            {
                failedcheck++;
            }

            quality.AreEqual("State does not match zip/postal code.", quality.GetText("css=#shippingAddress-state-province > div.formAlert > div.alert > span"));

            // comment: Zip code is not valid
            quality.Type("id=shippingAddressfirstName", "ABC Tester");
            quality.Type("id=shippingAddresslastName", "EFG Tester");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=United States");
            quality.Type("id=shippingAddressaddress1", "lololol tester's address");
            quality.Type("id=shippingAddressaddress2", "qwerty tester's address");
            quality.Type("id=shippingAddresscity", "");
            quality.Type("id=shippingAddresscity", "HILO");
            quality.Select("id=shippingAddressstate", "label=Hawaii");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddresszipPostal", "12356");
            quality.Type("id=shippingAddressphone", "");
            quality.Type("id=shippingAddressphone", "789-555-888824");

            quality.Click("id=continueBtn");

            if (ken.CheckForTimeOut("Zip/postal code is not valid.", "css=#shippingAddress-zip-postal-code > div.formAlert > div.alert > span", 61))
            {
                failedcheck++;
            }

            quality.AreEqual("Zip/postal code is not valid.", quality.GetText("css=#shippingAddress-zip-postal-code > div.formAlert > div.alert > span"));

            //comment: Type the maximum values for First Name, Last Name (100 characters) & Address1, Address2(200 characters) & Phone (20 characters) & City (100 characters)
            quality.Type("id=shippingAddressfirstName", "FirstName TesterFirstName TesterFirstName TesterFirstName TesterFirstName TesterFirstName TesterFirs");
            quality.Type("id=shippingAddresslastName", "FirstName TesterFirstName TesterFirstName TesterFirstName TesterFirstName TesterFirstName TesterFirs");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=Hong Kong");
            quality.Type("id=shippingAddressaddress1", "AddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addr");
            quality.Type("id=shippingAddressaddress2", "AddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addressAddressLine1 tester's addr");

            quality.IsTrue(quality.IsElementPresent("id=shippingAddressstate"));

            quality.Type("id=shippingAddresscity", "HILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILOHILO");
            quality.Type("id=shippingAddresszipPostal", "12351235498456564546163112316984565645461631123163");
            quality.Type("id=shippingAddressphone", "000-555-1212000-555-");

            // comment: City doesn't match the the zip code
            quality.Type("id=shippingAddressfirstName", "ABC Tester");
            quality.Type("id=shippingAddresslastName", "EFG Tester");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=United States");
            quality.Type("id=shippingAddressaddress1", "lololol tester's address");
            quality.Type("id=shippingAddressaddress2", "qwerty tester's address");
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
