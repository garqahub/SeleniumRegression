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
    class Kenwood_NoScanSD_OtherRegion_CheckTheSoftwareUpdates : ParentTest
    {
        KenwoodFunctions ken;
        public Kenwood_NoScanSD_OtherRegion_CheckTheSoftwareUpdates(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "NoScanSD_OtherRegion_CheckTheSoftwareUpdates";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Kenwood_NoScanSD_OtherRegion_CheckTheSoftwareUpdates**";
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
            quality.Select("id=headUnitRegionFilter", "label=Other");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Select a Model", quality.GetTitle());

            //comment: Select the same device like the one from the XML
            quality.Click("link=DNX7320");
            quality.WaitForPageToLoad("30000");

            ken.ProductUpdatesPage(false);

            // comment: Click on "Software Updates" button
            quality.Click("css=div.description.padding-top-10 > span");
            quality.WaitForPageToLoad("30000");

            ken.SoftwareUpdatePage();

            // comment: Click on "Back To Updates" button
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Product Updates for Kenwood DNX7320", quality.GetTitle());

            //comment: Click on "Software Updates" button
            quality.Click("css=div.description.padding-top-10 > div.header");
            quality.WaitForPageToLoad("30000");

            ken.SoftwareUpdatePage();


        }
        #endregion


    }


}
