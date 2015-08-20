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
    class Kenwood_SingInTest : ParentTest
    {
        public KenwoodFunctions ken;
        public Kenwood_SingInTest(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {

            //****Enter in Script Name here****  
            base.id = "Kenwood_SingInTest";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Sign Into Kenwood**";

            ken = new KenwoodFunctions(quality, webdriver);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            selenium.Open(base.baseURL);

            ken.WelcomePage();

            quality.Click("link=Sign In");
            quality.WaitForPageToLoad("30000");

            //comment: Go to Sing In page
            ken.SignInPage();

            ken.SignIn("asdfgh", "qasdasdfsfgsd");
            // comment: Insert any username and password
            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("The username/password combination is not valid", selenium.GetText("css=ul.error > li"));

            // comment: Enter only username
            ken.SignIn("qwerty", "");
            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("Password is required to login", selenium.GetText("css=ul.error > li"));

            // comment: Sign in without entering any information

            ken.SignIn("", "");

            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("Username is required to login", selenium.GetText("css=ul.error > li"));
            quality.AreEqual("Password is required to login", selenium.GetText("//div[@id='bd']/ul/li[2]"));

            // comment: Enter only password
            ken.SignIn("", "asfdsffgdfgs");
   
            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("Username is required to login", selenium.GetText("css=ul.error > li"));

            // comment: Enter more than 25 characters in both fields

            ken.SignIn("as!@#!@# 21sasdasdasadasdadaaasdadassasdasdasadasdadaaasdad\\\\", "as!@#!@# 21sasdasdasadasdadaaasdadassasdasdasadasdadaaasdad\\\\");
   
            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("Username is invalid", selenium.GetText("css=ul.error > li"));
            quality.AreEqual("Password is invalid", selenium.GetText("//div[@id='bd']/ul/li[2]"));

            // comment: Insert less than 25 characters in both fields

            ken.SignIn("as!@#!@# 21sasdasdasad", "as!@#!@# 21sasdasdasad");

            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("The username/password combination is not valid", selenium.GetText("css=ul.error > li"));

            // comment: Click on Forgot Username link
            quality.Click("link=Forgot username");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Forgot Username", selenium.GetTitle());
            quality.AreEqual("Forgot Username", selenium.GetText("css=div.titleHeader-text"));
            quality.AreEqual("To retrieve your username, enter the email address that you saved in your myGarmin account. If you did not save an email address in your account or you do not remember it, please contact Product Support.", selenium.GetText("css=p.prompt"));
            quality.AreEqual("Product Support", quality.GetText("link=Product Support"));
            quality.AreEqual("Email Address", selenium.GetText("css=div.inputIndicator-text"));
            quality.AreEqual("", selenium.GetText("id=email"));
            quality.AreEqual("Submit", selenium.GetText("css=a.button > span"));

            // comment: Go Back to Sign in page
            quality.Click("link=Sign In");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Sign In", selenium.GetTitle());

            // comment: Click on Forgot Password
            selenium.Click("link=Forgot password");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Forgot Password", selenium.GetTitle());
            quality.AreEqual("Forgot Password", selenium.GetText("css=div.titleHeader-text"));
            quality.AreEqual("To reset your password, enter the username of your myGarmin account. If you do not remember your username, please contact Product Support.", selenium.GetText("css=p.prompt"));
            quality.AreEqual("Product Support", quality.GetText("link=Product Support"));
            quality.AreEqual("Username", selenium.GetText("css=div.inputIndicator-text"));
            //quality.AreEqual("", selenium.GetValue("css=div.inputIndicator-text"));
            quality.AreEqual("Submit", selenium.GetText("css=a.button > span"));

            // comment: Go Back to Sign in page
            quality.Click("link=Sign In");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Sign In", selenium.GetTitle());

            // comment: Click on Create Account button
            quality.Click("css=div.left > a.button > span");
            quality.WaitForPageToLoad("30000");

            ken.CreateAccountPage();

            // comment: Go Back to Sign in page
            quality.Click("link=Sign In");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Sign In", selenium.GetTitle());

            // comment: Enter more than 25 characters in User Name and nothing for password
            ken.SignIn("as!@#!@# 21sasdasdasadasdadaaasdadassasdasdasadasdadaaasdad\\\\", "");

            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("Username is invalid", selenium.GetText("css=ul.error > li"));
            quality.AreEqual("Password is required to login", selenium.GetText("//div[@id='bd']/ul/li[2]"));

            // comment: Enter more than 25 characters in password field and nothing for User Name

            ken.SignIn("", "as!@#!@# 21sasdasdasadasdadaaasdadassasdasdasadasdadaaasdad\\\\");

            quality.AreEqual("Sign In", selenium.GetTitle());
            quality.AreEqual("Username is required to login", selenium.GetText("css=ul.error > li"));
            quality.AreEqual("Password is invalid", selenium.GetText("//div[@id='bd']/ul/li[2]"));

            // comment: Enter valid credentials
            ken.Login(username, password, fullname, false);

            // comment: SignOut
            ken.Logout();


        }
        #endregion


    }


}
