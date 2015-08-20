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
using System.Drawing;
using Selenium;
#endregion


namespace SeleniumRegression
{
    //****Enter in desired test name in replace of Connect_SignIn****
    class MyGarmin_SignIn : ParentTest
    {

        
        public MyGarmin_SignIn(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "MyGarmin Sign In";
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

            selenium.Open(baseURL);
            selenium.SelectFrame("garmin.com");
            selenium.Type("username", "gctestuser003");
            Thread.Sleep(1000);
            selenium.Type("id=password", "test1!");
            selenium.Click("id=login-btn-signin");
            selenium.WaitForPageToLoad("30000");
            selenium.SelectWindow("null");
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");


        }
        #endregion


    }


}
