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
    class Kenwood_NoScanSD_CheckShoppingCart_ForATrafficServcie_ShippingValidation : ParentTest
    {
        KenwoodFunctions ken;

        public Kenwood_NoScanSD_CheckShoppingCart_ForATrafficServcie_ShippingValidation(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "NoScanSD_CheckShoppingCart_ForATrafficServcie_ShippingValidation";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**NoScanSD_CheckShoppingCart_ForATrafficServcie_ShippingValidation**";
            ken = new KenwoodFunctions(quality, selenium);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            selenium.Open(base.baseURL);

            quality.AreEqual("Garmin Product Updates for Kenwood", quality.GetTitle());
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

            //comment: Check the "Real Traffic for Kenwood"
            ken.TrafficSubscriptionPage();

            //comment: Click on the first traffic subscription (North America)
            quality.Click("css=div.text");
            quality.WaitForPageToLoad("30000");

            ken.TrafficServicesForkenwoodPage();

            //comment: Click "Add to Cart" button without beeing logged-in
            quality.Click("css=a.button.left > span");
            quality.WaitForPageToLoad("30000");

            ken.SignInPage();

            quality.Type("id=username", username);
            quality.Type("id=password", password);
            quality.Click("css=a.button");
            quality.WaitForPageToLoad("30000");

            //comment: Validate the "Add to Cart: Traffic Subscription" page
            ken.AddToCartTrafficVerification(true);

            // comment: Type a Valid Unit ID 
            quality.Type("id=unitId", "");
            //quality.Type("id=trafficReceiverId", "");
            quality.Type("id=unitId", "3422110080");
            //quality.Type("id=trafficReceiverId", "3422110080");
            //quality.Click("//form[@id='verifyTrafficForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.Click("//form[@id='verifyTrafficForm']/table/tbody/tr[5]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");

            ken.ShoppingCartWithTrafficSubscriptionToBuy(true);

            // comment: Click "Update" button even if the QTY is disabled to be changed
            try
            {
                if (selenium.IsEditable("id=quantityDisabled") == false)
                {
                    quality.ErrorReport("Quantity Cannot be changed", CheckType.Element);
                }

            }
            catch (Exception)
            {

            }
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Shopping Cart", quality.GetTitle());

            // comment: Click the "Checkout" button
            quality.Click("//form[@id='shoppingCartForm']/div[2]/div[4]/a[2]/span");
            quality.WaitForPageToLoad("30000");

            ken.CheckOutPage();
            ken.Logout();

        }
        #endregion


    }


}