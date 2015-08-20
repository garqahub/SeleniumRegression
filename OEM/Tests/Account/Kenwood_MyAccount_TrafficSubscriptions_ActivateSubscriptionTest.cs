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
    class Kenwood_MyAccount_TrafficSubscriptions_ActivateSubscriptionTest : ParentTest
    {

        KenwoodFunctions ken;

        public Kenwood_MyAccount_TrafficSubscriptions_ActivateSubscriptionTest(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {

            //****Enter in Script Name here****  
            base.id = "MyAccount_TrafficSubscriptions_ActivateSubscriptionTest";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Check to ensure subscription works**";
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

            ken.SignInPage();

            //ken.Login(quality, "testuser201234", password, "test", false);
            ken.Login(username, password, fullname, false);

            // comment: Check the My Account menu
            quality.Click("link=My Account");
            quality.WaitForPageToLoad("30000");

            ken.MyAccountPage(false);

            // comment: Click on the "View Subscription" button
            quality.Click("//div[@id='bd']/div[6]/a/span");
            quality.WaitForPageToLoad("30000");

            ken.ViewSubscriptionsPage(false, false);

            //comment: Click on the first FOUND Active button
            bool check = false;

            quality.IsTextPresent("Activate");

            if (quality.GetText("css=#button > a.button > span") == "Activate")
            {
                quality.Click("css=#button > a.button > span");
                quality.WaitForPageToLoad("30000");
            }
            else if (quality.IsElementPresent("//div[4]/div/div[3]/div[3]/a/span") == true)
            {
                if (quality.GetText("//div[4]/div/div[3]/div[3]/a/span") == "Activate")
                {
                    quality.Click("//div[4]/div/div[3]/div[3]/a/span");
                    quality.WaitForPageToLoad("30000");
                }
            }
            else if (quality.IsElementPresent("//div[" + 4 + "]/div[3]/a/span"))
            {
                int i = 10;
                while (!check && (quality.IsElementPresent("//div[" + i + "]/div[3]/a/span") == true))
                {
                    if (quality.GetText("//div[" + i + "]/div[3]/a/span") == "Activate")
                    {
                        check = true;
                        quality.Click("//div[" + i + "]/div[3]/a/span");
                        quality.WaitForPageToLoad("30000");
                    }

                    i++;
                }
            }

            //comment: Check activate traffic subscription page
           

            //comment: Click Activate button from the "Activate traffic Subscription" page without entering a unit id
            Thread.Sleep(5000);
            quality.IsTextPresent("Activate");
            selenium.Click("xpath=(//div[@id='button']/a/span)[15]");
            quality.WaitForPageToLoad("30000");
            //quality.AreEqual("Activate Traffic Subscription", quality.GetTitle());
            //quality.IsTextPresent("Traffic Receiver ID is required");

            //comment: Type an invalid Traffic Receiver Id
            quality.Type("id=trafficReceiverId", "as!>?#$%@#!@# 21sasdas9813265dasadaas!@#!@# 21sasdsdad786");
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            //quality.AreEqual("Activate Traffic Subscription", quality.GetTitle());
            quality.IsTextPresent("Please enter a valid Traffic Receiver ID");

            //comment: Type an negative Traffic Receiver Id
            quality.Type("id=trafficReceiverId", "-1");
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            
            quality.AreEqual("The Traffic Receiver ID you entered is not valid", quality.GetText("css=ul.error > li"));

            //comment: Type only characters Traffic Receiver Id
            quality.Type("id=trafficReceiverId", "qwedqewrqwerqwe");
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            
            quality.AreEqual("The Traffic Receiver ID you entered is not valid", quality.GetText("css=ul.error > li"));

            //comment: Type only special characters Traffic Receiver Id
            quality.Type("id=trafficReceiverId", "!$#@$#$!@#!$@#");
            quality.Click("css=a.button > span");
            quality.WaitForPageToLoad("30000");
            
            quality.AreEqual("The Traffic Receiver ID you entered is not valid", quality.GetText("css=ul.error > li"));

            ////comment: Type a VALID Traffic Receiver Id
            //quality.Type("id=trafficReceiverId", unitId);
            //quality.Click("css=a.button > span");
            //quality.WaitForPageToLoad("30000");
            //quality.AreEqual("Activate Traffic Subscription", quality.GetTitle());
            //quality.AreEqual("The Traffic Receiver ID you entered is not valid", quality.GetText("css=ul.error > li"));

            //comment: GO to Subscriptions page
            quality.Click("link=My Subscriptions");
            quality.WaitForPageToLoad("30000");

            // comment: Go back to My Account
            quality.Click("link=« Back");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Account Settings", quality.GetTitle());

            // comment: Sign Out
            ken.Logout();
        }
        #endregion
    }

}
