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
    class Kenwood_ScanSD_CheckLatestMapForKenwood : ParentTest
    {
        KenwoodFunctions ken;
        public Kenwood_ScanSD_CheckLatestMapForKenwood(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "ScanSD_CheckLatestMapForKenwood";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**ScanSD & Check for the Latest Maps**";
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

            for (int second = 0; second < 61 ; second++)
            {
                if (second >= 60) quality.ErrorReport("timeout", CheckType.Warning);
                try
                {
                    if ("Media Scan" == quality.GetText("css=div.titleHeader-text")) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            quality.AreEqual("Media Scan", quality.GetText("css=div.titleHeader-text"));
            quality.AreEqual("Scanning Your Portable Storage Device... Please wait", quality.GetText("id=messageText"));

            ken.DeviceInformationFoundPage(true);

            // comment: Click on the "Continue" button
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");

            ken.ProductUpdatesPage(true);

            // comment: Click on the "Lastest Map" button
            quality.Click("css=div.description > span");
            quality.WaitForPageToLoad("30000");

            // comment: Validate the Latests Map for Kenwood page
            ken.LatestMapForKenwoodPage(true);


        }
        #endregion


    }


}
