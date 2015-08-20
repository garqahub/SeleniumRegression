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
    class Kenwood_MyAccount_ValidationTest : ParentTest
    {
        KenwoodFunctions ken;
        public Kenwood_MyAccount_ValidationTest(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            
            //****Enter in Script Name here****  
            base.id = "Validate MyAccount";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Validate editing my account info**";
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

            ken.Login("newtestuser5", "password", "my name", false);

            // comment: Check the My Account menu
            quality.Click("link=My Account");
            quality.WaitForPageToLoad("30000");

            ken.MyAccountPage(true);

            // comment: Click on the "Edit Account" button
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Edit Account", quality.GetTitle());

            ken.EditAccountPage();

            // comment: Go back to My Account
            quality.Click("link=My Account");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Account Settings", quality.GetTitle());

            // comment: Click on the "Change Password" button
            quality.Click("//div[@id='bd']/div[4]/a[2]/span");
            quality.WaitForPageToLoad("30000");

            ken.ChangePasswordPage();

            // comment: Go back to My Account
            quality.Click("link=My Account");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Account Settings", quality.GetTitle());

            // comment: Click on the "View Subscription" button
            quality.Click("//div[@id='bd']/div[6]/a/span");
            quality.WaitForPageToLoad("30000");

            ken.ViewSubscriptionsPage(true, false);

            // comment: Press "Back" button to switch to My Account
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Account Settings", quality.GetTitle());

            // comment: Click on the "View All Orders" button
            quality.Click("//div[@id='bd']/div[6]/a[2]/span");
            quality.WaitForPageToLoad("30000");

            ken.OrderSummary(true);

            // comment: Press "Back" button to switch to My Account
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Account Settings", quality.GetTitle());

            // comment: Click on the "View Downloads" button
            quality.Click("//div[@id='bd']/div[6]/a[3]/span");
            quality.WaitForPageToLoad("30000");

            ken.ViewDownloadsPage(true);

            // comment: Press "Back" button to switch to My Account
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Account Settings", quality.GetTitle());

            // comment: Sign Out
            ken.Logout();

        }
        #endregion


    }


}
