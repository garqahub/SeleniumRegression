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
    class Kenwood_Navigation : ParentTest
    {
        public Kenwood_Navigation(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Kenwood Navigation";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Place your description of the test purpose here for more clarity in reporting**";
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            //selenium.Open("https://autoem-qa.garmin.com/kenwood/site/forgotUsername");
            //selenium.Open("https://www.garmin.com/kenwood/site/forgotUsername");
            //selenium.Open("https://autoem-qa.garmin.com/kenwood/site/createAccount");
            //selenium.Click("id=email");
            //quality.Type("id=email", "Hello World");

            //quality.Click("link=Product Support");
            //selenium.Open("https://www.garmin.com/kenwood/site/createAccount");

            selenium.Open("https://autoem-dev.garmin.com/paccar/site/createAccount");
            quality.Type("id=fullName", "Hello World");


        }
        #endregion


    }


}
