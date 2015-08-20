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
    class Kenwood_CreateAccount_ValidationTest : ParentTest
    {
        KenwoodFunctions ken;

        public Kenwood_CreateAccount_ValidationTest(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Create Account Validation";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the quality.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Place your description of the test purpose here for more clarity in reporting**";
            ken = new KenwoodFunctions(quality, selenium);
        }

        #region Test Script
        //this is the test code generated by quality
        //****Paste test script here*****
        public override void RunTest()
        {

            selenium.Open(base.baseURL);
            ken.WelcomePage();

            quality.Click("link=Sign In");
            quality.WaitForPageToLoad("30000");

            // comment: Validate the Create Account page
            quality.Click("css=div.left > a.button > span");
            quality.WaitForPageToLoad("30000");

            ken.CreateAccountPage();

            // comment: Do not enter any information on this page and click on submit
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");

            quality.AreEqual("Create Account", quality.GetTitle());
            quality.AreEqual("Zip/Postal code is required", quality.GetText("css=ul.error > li"));
            quality.AreEqual("Retype Password field is required", quality.GetText("//div[@id='bd']/ul/li[2]"));
            quality.AreEqual("Username field is required", quality.GetText("//div[@id='bd']/ul/li[3]"));
            quality.AreEqual("Address is required", quality.GetText("//div[@id='bd']/ul/li[4]"));
            quality.AreEqual("E-mail Address is required", quality.GetText("//div[@id='bd']/ul/li[5]"));
            quality.AreEqual("State/Province is required", quality.GetText("//div[@id='bd']/ul/li[6]"));
            //Assert.AreEqual("Retype E-mail Address is required", quality.GetText("//div[@id='bd']/ul/li[7]"));
            //Assert.AreEqual("Full Name is required", quality.GetText("//div[@id='bd']/ul/li[8]"));
            //Assert.AreEqual("Password field is required", quality.GetText("//div[@id='bd']/ul/li[9]"));
            //Assert.AreEqual("Country is required", quality.GetText("//div[@id='bd']/ul/li[10]"));
            //Assert.AreEqual("City is required", quality.GetText("//div[@id='bd']/ul/li[11]"));
            quality.IsTextPresent("Full Name is required");
            quality.IsTextPresent("Password field is required");
            quality.IsTextPresent("Country is required");
            quality.IsTextPresent("City is required");

            // comment: Validate all the input text boxes are editable.
            quality.Type("id=fullName", "teeeeeeest");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Type("id=address", "home address");
            quality.Type("id=username", "random user");
            quality.Type("id=address2", "office address");
            quality.Type("id=password", "password1");
            quality.Type("id=city", "my city");
            quality.Select("id=state", "label=Hawaii");
            quality.Type("id=retypePassword", "qwe");
            quality.Type("id=zip", "132");
            quality.Select("id=country", "label=Barbados");
            quality.Click("id=subscribeEmail");

            // comment: Enter an already existing user name and click submit
            quality.Type("id=fullName", "teeeeeeest");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Type("id=address", "home address");
            quality.Type("id=username", username);
            quality.Type("id=address2", "office address");
            quality.Type("id=password", "password1");
            quality.Type("id=city", "my city");
            quality.Select("id=state", "label=Hawaii");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=zip", "132");
            quality.Select("id=country", "label=Barbados");
            quality.Click("id=subscribeEmail");
            quality.Type("id=username", username);
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.IsTextPresent("Username is already taken");

            // comment: Enter less than or equal to 25 characters for Username
            quality.Type("id=username", "testuser2011testuser201152345");
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("link=Submit");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of Username is 25 characters");
            
            // comment: Enter less than 4 characters for Username field
            quality.Type("id=username", "tes");
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("link=Submit");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("Username must be at least 4 characters");

            // comment: Enter a valid user name with alpha numeric and special characters 
            quality.Type("id=username", "radu.tighqwer@garmin.com");
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");

            // comment: Enter more than 50 charactors in Full Name field
            quality.Type("id=fullName", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasssssssssssdwe");
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.IsTextPresent("The maximum length of Full Name is 50 characters");

            // comment: Enter a full name with spaces and alpha numerics and click on continue
            quality.Type("id=fullName", "qw 123s@#$ssdwe");
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());

            // comment: Enter more than 100 characters in Address field.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome addresshome addresshome addresshome address");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of Address is 100 characters");

            // comment: Enter more than 100 charactors in Address 2 field.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice addressoffice addressoffice addressoffice addressoffice addressoffice addressoffice addressoffice address");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of Address 2 is 100 characters");

            // comment: Enter more than 50 charactors in City field.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy citymy citymy citymy citymy citymy citymy citymy citymy citymy citymy citymy citymy city");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of City is 50 characters");

            // comment: Enter more than 25 charactors in Zip Code field.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=zip", "13qweq21321@#$%#^%#$#2132132132132132132132132132132132132dsew");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of Zip/Postal Code is 20 characters");

            // comment: Validate the user is able to select a state from State dropdownlist and acountry from Country drop down list.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=username", "q123werwqst34dc");
            quality.Type("id=email", "asda.rea@garmin.com");
            //quality.Type("id=retypeEmail", "asda.rea@garmin.com");
            quality.Type("id=zip", "13qwe@# $%#^%#$#2");
            quality.Select("id=state", "label=Florida");
            quality.Select("id=state", "label=Louisiana");
            quality.Select("id=state", "label=Nebraska");
            quality.Select("id=country", "label=Cameroon");
            quality.Select("id=country", "label=Bahrain");

            // comment: Enter more than 50 charactors in Email Address and Retype Email Address field.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=zip", "13qwe@# $%#^%#$#2");
            quality.Select("id=state", "label=Hawaii");
            quality.Select("id=country", "label=United States");
            quality.Type("id=email", "radu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of E-mail Address is 50 characters");
            quality.IsTextPresent("E-mail Address is invalid");

            /*
            // comment: Enter more than 50 charactors in Retype - Email Address field.
            quality.Type("id=password", "password1");
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=zip", "13qwe@# $%#^%#$#2");
            quality.Select("id=state", "label=Hawaii");
            quality.Select("id=country", "label=United States");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.comradu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            Assert.AreEqual("Create Account", quality.GetTitle());
            Assert.AreEqual("E-mail Addresses do not match", quality.GetText("css=ul.error > li"));
            */

            // comment: Validate the web portal is allowing Password length less than 6 characters.
            quality.Type("id=password", "pass");
            quality.Type("id=retypePassword", "pass");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=zip", "13qwe@# $%#^%#$#2");
            quality.Select("id=state", "label=Hawaii");
            quality.Select("id=country", "label=United States");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("Password must be at least 6 characters");

            // Enter different values in both Password and Retype Password fields.
            quality.Type("id=password", password);
            quality.Type("id=retypePassword", "password1");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=zip", "13qwe@# $%#^%#$#2");
            quality.Select("id=state", "label=Hawaii");
            quality.Select("id=country", "label=United States");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("Passwords do not match");

            // Enter more than 25 characters in both Password and Retype Password fields 
            quality.Type("id=password", "passwordpasswordpasswordpasswordpasswordpasswordpassword");
            quality.Type("id=retypePassword", "passwordpasswordpasswordpasswordpasswordpasswordpassword");
            quality.Type("id=address", "hom!@#$%^&&^%$#e addresshome addresshome addresshome addresshome addresshome");
            quality.Type("id=address2", "office a!@#$%^&&^%$#ddressoffice addressoffice addressoffice addressoffice addressoffice");
            quality.Type("id=city", "my city!@##$$@#!@#my citymy citymy citymy");
            quality.Type("id=zip", "13qwe@# $%#^%#$#2");
            quality.Select("id=state", "label=Hawaii");
            quality.Select("id=country", "label=United States");
            quality.Type("id=email", "radu.tighineanu@garmin.com");
            //quality.Type("id=retypeEmail", "radu.tighineanu@garmin.com");
            quality.Click("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span");
            quality.WaitForPageToLoad("30000");
            quality.AreEqual("Create Account", quality.GetTitle());
            quality.IsTextPresent("The maximum length of Password is 25 characters");


        }
        #endregion


    }


}