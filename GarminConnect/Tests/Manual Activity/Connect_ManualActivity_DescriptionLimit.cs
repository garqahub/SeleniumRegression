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
    class Connect_ManualActivity_DescriptionLimit : ParentTest
    {
        ConnectUtility utility;
        public Connect_ManualActivity_DescriptionLimit(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Connect_ManualActivity_DescriptionLimit";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Check the validation limit of 2000 characters**";
            utility = new ConnectUtility(this);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {

            selenium.Open(base.baseURL);
            utility.SignIn("gctestuser001", "test1!");
            quality.Click("id=navBarTabAnalyze");
            quality.WaitForPageToLoad("30000");
            quality.Click("link=Manual Activity");
            quality.WaitForPageToLoad("30000");
            quality.Type("id=activityNameDecoration:activityName", "I have");
            quality.Select("id=activityTypeDecoration:activityType", "label=Running");
            quality.Type("id=speedPaceContainer:activitySummarySumDuration", "4");
            quality.Type("id=descriptionDecoration:description", "I I did I did this I did this to I did this to take I did this to take up I did this to take up space I did this to take up space to I did this to take up space to test I did this to take up space to test how many I did this to take up space to test how many characters I did this to take up space to test how many characters a I did this to take up space to test how many characters a field I did this to take up space to test how many characters a field can I did this to take up space to test how many characters a field can hold One fish two fish, red fish blue fish and no I still don’t like green eggs and ham.  I do not like them sam I am.  I do not like the in a house I do not like them with a mouse.  I DO NOT LIKE GREEN EGGS AND HAM!!!!!!!!!!!!!!!   Or coming up with something to write here other than spamming the keyboard!!!!!!!!!!!!!!!!!!!!!!!!!!!  BLLLLLLLLLLLLLLLLLLLLLLAAAAAAAAAAAHHHHHHHHHHHHHHHHHHH Wow still a long way to go here………..Hmmmmmmmmmmmmmmmm  maybe some odd characters????  !@#$%^%*(**()*())~~````  that was the longest curse word ever, but those stupid censors keeping me down.  Geez I can’t even say !@#$%^&*()*())~~````, that’s pretty bad.    How is someone supposed to express themselves without being about to say that or @!#@!$@#@!  And now I copy and paste. I I did I did this I did this to I did this to take I did this to take up I did this to take up space I did this to take up space to I did this to take up space to test I did this to take up space to test how many I did this to take up space to test how many characters I did this to take up space to test how many characters a I did this to take up space to test how many characters a field I did this to take up space to test how many characters a field can I did this to take up space to test how many characters a field can hold One fish two fish, red fish blue fish and no I still don’t like green eggs and ham.  I do not like them sam I am.  I do not like the in a house I do not like them with a mou");

            quality.Click("id=saveButton");
            Thread.Sleep(3000);
            quality.IsTextPresent("has a 2000 character limit");

            quality.Type("id=descriptionDecoration:description", "I I did I did this I did this to I did this to take I did this to take up I did this to take up space I did this to take up space to I did this to take up space to test I did this to take up space to test how many I did this to take up space to test how many characters I did this to take up space to test how many characters a I did this to take up space to test how many characters a field I did this to take up space to test how many characters a field can I did this to take up space to test how many characters a field can hold One fish two fish, red fish blue fish and no I still don’t like green eggs and ham.  I do not like them sam I am.  I do not like the in a house I do not like them with a mouse.  I DO NOT LIKE GREEN EGGS AND HAM!!!!!!!!!!!!!!!   Or coming up with something to write here other than spamming the keyboard!!!!!!!!!!!!!!!!!!!!!!!!!!!  BLLLLLLLLLLLLLLLLLLLLLLAAAAAAAAAAAHHHHHHHHHHHHHHHHHHH Wow still a long way to go here………..Hmmmmmmmmmmmmmmmm  maybe some odd characters????  !@#$%^%*(**()*())~~````  that was the longest curse word ever, but those stupid censors keeping me down.  Geez I can’t even say !@#$%^&*()*())~~````, that’s pretty bad.    How is someone supposed to express themselves without being about to say that or @!#@!$@#@!  And now I copy and paste. I I did I did this I did this to I did this to take I did this to take up I did this to take up space I did this to take up space to I did this to take up space to test I did this to take up space to test how many I did this to take up space to test how many characters I did this to take up space to test how many characters a I did this to take up space to test how many characters a field I did this to take up space to test how many characters a field can I did this to take up space to test how many characters a field can hold One fish two fish, red fish blue fish and no I still don’t like green eggs and ham.  I do not like them sam I am.  I do not like the in a house I do not like them with a");
            Thread.Sleep(2000);
            quality.Click("id=saveButton");
            Thread.Sleep(2000);
            quality.WaitForPageToLoad("30000");
            quality.IsElementPresent("id=detailsSummaryBox");
            utility.SignOut();


        }
        #endregion


    }


}
