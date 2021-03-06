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
    class ConnectSignIn : ParentTest
    {
        public ConnectSignIn(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "ConnectSignIn";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**A simple Sign In test**";
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            selenium.Open(base.baseURL);
            quality.Click("id=headerSignInLink");
            quality.Type("id=login:loginUsernameField", "gctestuser010");
            quality.Type("id=login:password", "test1!");
            quality.WaitForPageToLoad("30000");
            quality.IsTextPresent("Welcome, manualtest");
            quality.Click("id=signOutLink");
            quality.WaitForPageToLoad("30000");
            quality.Type("id=login:loginUsernameField", "manualtest");

            quality.WaitForPageToLoad("30000");


        }
        #endregion


    }


}
