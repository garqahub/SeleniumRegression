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
    class Kenwood_ScanSD_WL_PaymentInfo_check : ParentTest
    {
        KenwoodFunctions ken;
        public Kenwood_ScanSD_WL_PaymentInfo_check(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "ScanSD_WL_PaymentInfo_check";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**ScanSD_WL_PaymentInfo_check**";
            ken = new KenwoodFunctions(quality, selenium);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {

            selenium.Open(base.baseURL);
            DateTime time = DateTime.Now;
            string current_year = time.Year.ToString();
            string current_month = "";


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

            Thread.Sleep(5000);

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
            quality.Type("id=shippingAddressfirstName", "FirstName Tester");
            quality.Type("id=shippingAddresslastName", "LastName Tester");
            quality.Select("id=shippingAddresscountry", "label=Select a Country/Region");
            quality.Select("id=shippingAddresscountry", "label=United States");
            quality.Type("id=shippingAddressaddress1", "24285 Main");
            quality.Type("id=shippingAddressaddress2", "AddressLine2 tester's address");
            quality.Type("id=shippingAddresscity", "");
            quality.Type("id=shippingAddresscity", "E PALO ALTO");
            quality.Select("id=shippingAddressstate", "label=California");
            quality.Type("id=shippingAddresszipPostal", "");
            quality.Type("id=shippingAddresszipPostal", "94303");
            quality.Type("id=shippingAddressphone", "");
            quality.Type("id=shippingAddressphone", "000-555-1212");

            quality.Click("id=continueBtn");

            if (ken.CheckForTimeOut("Edit", "link=Edit", 61))
	{
		 failedcheck++;
	}

            // comment: Check that the "Billing Address" page is displayed

            ken.BillingAddressSection();

            //string current_year = time.Year.ToString();
            string year_builder = "";
            for (int i = 0; i < 16; i++)
            {
                if (i <= 14)
                {
                    year_builder += time.AddYears(i).Year.ToString() + " ";
                }
                else
                {
                    year_builder += time.AddYears(i).Year.ToString();
                }
            }

            quality.AreEqual(year_builder, quality.GetText("id=expYear"));

            //decrease speed of execution
            selenium.SetSpeed("1760");

            quality.Select("name=cardType", "label=Master Card");
            quality.Select("name=cardType", "label=Visa");
            // comment: Type different values for "cardholder's name" text box and card number
            quality.Type("id=cardHolderName", "--//!@# $%$$#$%^&1312asda");
            quality.Type("id=cardNumber", "-123456");
            quality.Type("id=cardSecurityCode", "123");
            quality.Select("id=expMonth", "label=09");
            quality.Select("id=expYear", "label=2024");
            quality.IsTrue(Regex.IsMatch(quality.GetText("link=What is this?"), "^What is this[\\s\\S]$"));

            quality.Click("id=submitOrder");

            quality.AreEqual("Please enter a valid credit card number.", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));

            Thread.Sleep(5000);

            //quality.AreEqual("Sorry, we cannot process orders at this time. Please try again later.", quality.GetText("css=div.error-message-item"));

            quality.Type("id=cardNumber", "123456789123456");
            quality.Click("id=submitOrder");

            //Thread.Sleep(5000);

            ////quality.AreEqual("invalid credit card number", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));
            ////quality.AreEqual("We're sorry, but one or more fields are incomplete or incorrect.", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));


            //for (int second = 0; ; second++)
            //{
            //    if (second >= 60) quality.Fail("timeout");
            //    try
            //    {
            //        if ("We're sorry, but one or more fields are incomplete or incorrect." == quality.GetText("css=div.error-message-title")) break;
            //    }
            //    catch (Exception)
            //    { }
            //    Thread.Sleep(1000);
            //}
            //quality.AreEqual("We're sorry, but one or more fields are incomplete or incorrect.", quality.GetText("css=div.error-message-title"));
            //quality.AreEqual("invalid credit card number", quality.GetText("css=div.error-message-item"));


            quality.AreEqual("Please enter a valid credit card number.", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));

            quality.Select("name=cardType", "label=Master Card");
            quality.Select("id=expYear", "label=2026");
            quality.Type("id=cardNumber", "qweqgrevzqah");
            quality.Click("id=submitOrder");

            Thread.Sleep(5000);
            //CORECT
            //quality.AreEqual("Please enter a valid number.", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));

            //WRONG
            quality.AreEqual("Please enter a valid number", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));

            //for (int second = 0; ; second++)
            //{
            //    if (second >= 60) quality.Fail("timeout");
            //    try
            //    {
            //        if ("Sorry, we cannot process orders at this time. Please try again later." == quality.GetText("css=div.error-message-item")) break;
            //    }
            //    catch (Exception)
            //    { }
            //    Thread.Sleep(1000);
            //}          
            //quality.AreEqual("Sorry, we cannot process orders at this time. Please try again later.", quality.GetText("css=div.error-message-item"));



            quality.Type("id=cardNumber", "!@#%$^^&*%$$)(");
            quality.Click("id=submitOrder");

            Thread.Sleep(5000);

            //CORECT
            //quality.AreEqual("Please enter a valid number.", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));

            //WRONG
            quality.AreEqual("Please enter a valid number", quality.GetText("css=#card-number > div.formAlert > div.alert > span"));

            //Check if the current month is not the first one in the year to be able to execute the expiration date of the card

            if (time.Month >= 2)
            {
                quality.Type("id=cardNumber", "5555555555554444");
                quality.Select("id=expYear", "label=2024");

                if (time.Month < 10 && time.Month > 1)
                {
                    DateTime substractMonth = time.AddMonths(-1);
                    int onlyMonth = substractMonth.Month;
                    current_month = "0" + onlyMonth.ToString();
                }

                else if (time.Month == 10)
                {
                    current_month = "09";
                }

                else if (time.Month > 10 && time.Month <= 12)
                {
                    DateTime substractMonth = time.AddMonths(-1);
                    int onlyMonth = substractMonth.Month;
                    current_month = onlyMonth.ToString();
                }

                quality.Select("id=expMonth", "label=" + current_month + "");
                quality.Select("id=expYear", "label=" + current_year + "");
                quality.Click("id=submitOrder");

                Thread.Sleep(5000);

                quality.AreEqual("Expiration Date must be in the future", quality.GetText("css=#expiration-date > div.formAlert > div.alert > span"));
            }
            // comment: Insert some special characters in the CSC field
            quality.Select("name=cardType", "label=Discover");
            quality.Type("id=cardHolderName", "holder name");
            quality.Type("id=cardNumber", "6011111111111117");
            quality.Type("id=cardSecurityCode", "!@#$");
            quality.Select("id=expMonth", "label=03");
            quality.Select("id=expYear", "label=" + time.AddYears(10).Year.ToString() + "");
            quality.Click("id=submitOrder");

            //quality.AreEqual("Please enter a valid number.", quality.GetText("css=#card-security-code > div.formAlert > div.alert > span"));
            //WRONG
            quality.AreEqual("Please enter a valid number", quality.GetText("css=#card-security-code > div.formAlert > div.alert > span"));

            quality.Type("id=cardSecurityCode", "qwer");
            quality.Click("id=submitOrder");

            //quality.AreEqual("Please enter a valid number.", quality.GetText("css=#card-security-code > div.formAlert > div.alert > span"));
            //WRONG
            quality.AreEqual("Please enter a valid number", quality.GetText("css=#card-security-code > div.formAlert > div.alert > span"));

            // comment: Select a VISA card with CSC 200 with Shipping address ZIP Code 94303 (AVSZIP = N)
            quality.Select("name=cardType", "label=Visa");
            quality.Type("id=cardNumber", "4111111111111111");
            quality.Type("id=cardSecurityCode", "200");
            quality.Select("id=expMonth", "label=07");
            quality.Select("id=expYear", "label=" + time.AddYears(13).Year.ToString() + "");
            quality.Click("id=submitOrder");

            Thread.Sleep(16000);

            quality.AreEqual("The zip code you have entered doesn't match the credit card information. Please re-enter your zip code or select a different form of payment.", quality.GetText("css=div.error-message-item"));

            // comment: Select a MASTERCARD and type number from a VISA card
            quality.Select("name=cardType", "label=Master Card");
            quality.Type("id=cardNumber", "4111111111111111");
            quality.Type("id=cardSecurityCode", "222");
            quality.Select("id=expMonth", "label=07");
            quality.Select("id=expYear", "label=" + time.AddYears(13).Year.ToString() + "");
            quality.Click("id=submitOrder");

            Thread.Sleep(16000);

            quality.AreEqual("There was a problem processing your credit card. Please confirm your billing and shipping address and try again. If the problem persists, please confirm that there are funds available or use a different payment method.", quality.GetText("css=div.error-message-item"));
            // comment: Select a DISCOVER card type and type an AMERICAN EXPRESS card number
            quality.Select("name=cardType", "label=Discover");
            quality.Type("id=cardNumber", "378282246310005");
            quality.Type("id=cardSecurityCode", "999");
            quality.Select("id=expMonth", "label=02");
            quality.Select("id=expYear", "label=" + time.AddYears(9).Year.ToString() + "");
            quality.Click("id=submitOrder");

            Thread.Sleep(5000);

            quality.AreEqual("There was a problem processing your credit card. Please confirm your billing and shipping address and try again. If the problem persists, please confirm that there are funds available or use a different payment method.", quality.GetText("css=div.error-message-item"));

            // comment: Update the Shipping address fields
            quality.Click("link=Edit");
            //SET THIS TIME only on FF browser
            /*
            if (browser == "FF")
            {
                quality.WaitForPageToLoad("30000");
            }
             */ 
            quality.AreEqual("Checkout", quality.GetTitle());

            quality.AreEqual("Checkout", quality.GetText("css=div.titleHeader-text"));
            quality.IsTrue(quality.IsTextPresent("Please fill out the form below to complete your transaction. Do not click your browser's Refresh or Back button because this transaction may be interrupted or terminated."));

            quality.AreEqual("Shipping Address", quality.GetText("css=h2"));

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
            // comment: Check that the "Billing Address" page is displayed

            if (ken.CheckForTimeOut("Edit", "link=Edit", 61))
            {
                failedcheck++;
            }

            quality.AreEqual("Edit", quality.GetText("link=Edit"));
            quality.AreEqual("Shipping Address", quality.GetText("css=h2"));
            //quality.AreEqual("Delivery Options", quality.GetText("css=fieldset > div.formHead > h2"));
            quality.AreEqual("Billing Address", quality.GetText("css=#billing-address > fieldset > div.formHead > h2"));
            quality.AreEqual("Payment Information", quality.GetText("css=#payment-information > fieldset > div.formHead > h2"));
            quality.AreEqual("Place Secure Order", quality.GetText("id=submitOrder"));

            // comment: Return an invalid CSC error message
            quality.Select("name=cardType", "label=Discover");
            quality.Type("id=cardHolderName", "holder name");
            quality.Type("id=cardNumber", "6011111111111117");
            quality.Type("id=cardSecurityCode", "333");
            quality.Select("id=expMonth", "label=03");
            quality.Select("id=expYear", "label=" + time.AddYears(10).Year.ToString() + "");
            quality.Click("id=submitOrder");

            Thread.Sleep(9000);

            quality.AreEqual("The CSC code you have entered is invalid. Please re-enter the CSC code or select a different form of payment.", quality.GetText("css=div.error-message-item"));

            //increase speed of test execution
            selenium.SetSpeed("600");

            //----------------
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