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
using System.Windows.Forms;
using System.Drawing;
using Selenium;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
#endregion

namespace SeleniumRegression
{
    class ConnectUtility
    {
        WebDriverBackedSelenium selenium;
        string baseurl;
        QualityCheck quality;
        ParentTest currenttest;

        public ConnectUtility(ParentTest test)
        {
            selenium = test.selenium;
            baseurl = test.baseURL;
            quality = test.quality;
            currenttest = test;
        }
        

        /// <summary>
        /// Creates a new username based on the time of day 
        /// </summary>
        /// <param name="password">desired password to use</param>
        /// <param name="quality">Instance of the quality check</param>
        /// <returns>The username that was created</returns>
        public string CreateUser(string password)
        {
            string username;
            string windowtitle;
            username = "connect" + System.DateTime.Now.TimeOfDay.TotalMinutes;
            /*
            if (selenium.IsTextPresent("You are signed in as"))
            {
                selenium.Click("id=signOutLink");
                selenium.WaitForPageToLoad("30000");
            }
             */ 
            quality.Click("id=headerSignInLink");
            selenium.WaitForPageToLoad("30000");
            windowtitle = selenium.UnderlyingWebDriver.Title;

            quality.Click("link=Create your free account");
            Thread.Sleep(3000);

            quality.Type("id=registration:fullNameDecoration:fullName", "Automated Tester");
            quality.Type("id=registration:emailDecoration:email", username + "@fake.com");
            quality.Type("id=registration:usernameDecoration:username", username);
            quality.Type("id=registration:passwordDecoration:password", password);
            quality.Type("id=registration:passwordConfirmDecoration:passwordConfirm", password);
            quality.Type("id=registration:displayNameDecoration:displayName", username);
            //quality.Click("id=registration:myGarminTerms");
            //quality.Click("id=registration:connectTerms");
            quality.Click("id=registration:submitButton");
            quality.WaitForPageToLoad("30000");

            /*
            quality.SelectWindow("Create An Account");
            
            quality.Type("id=name", "automated tester");
            quality.Type("id=email", username + "@fake.com");
            quality.Type("id=username", username);
            quality.Type("id=password", password);
            quality.Type("id=passwordMatch", password);
            Thread.Sleep(1000);
            quality.Click("id=submitBtn");
            Thread.Sleep(6000);
            //selenium.WaitForPageToLoad("30000");
            quality.SelectWindow("Garmin Connect - Register");
            quality.Type("id=userRegistrationException:displayName", username);
            quality.Click("id=userRegistrationException:submitButton");
             */ 
            quality.IsTextPresent(username);

            return username;
        }

        /// <summary>
        /// Go through the process of logging in to connect.  This is for the old sign-in method
        /// </summary>
        /// <param name="username">The username to use</param>
        /// <param name="password">The password to use</param>
        /// <param name="quality">Instance of the QualityCheck for test.</param>
        public void LogIn(string username, string password)
        {
 

            quality.Click("id=headerSignInLink");
            selenium.WaitForPageToLoad("30000");
            quality.Type("id=login:loginUsernameField", username);

            quality.Type("id=login:password", password);

            quality.Click("id=login:signInButton");
            selenium.WaitForPageToLoad("30000");
            quality.CheckBodyForText(username);
        }

        /// <summary>
        /// Convert an Array to a Generic Collection List
        /// </summary>
        /// <param name="list">reference the List you want to house the array</param>
        /// <param name="array">The array you want converted</param>
        public void ConvertArraytoList(ref List<object> list, object[] array)
        {
            foreach (object obj in array)
            {
                list.Add(obj);
            }
        }

        /// <summary>
        /// Uploads a file using the maual/browse option
        /// </summary>
        /// <param name="quality">instance of qualitycheck</param>
        /// <param name="filepath">where the file is located</param>
        /// <param name="gotodetails">if you want the method to go to the file details</param>
        public void UploadFile(string filepath)
        {
            System.IO.FileStream stream;
            try
            {
                stream = new FileStream(filepath, FileMode.Open);
            }
            catch
            {
                MessageBox.Show(filepath + " was not found on this computer.  Process will not continue and fail without it.");
            }

            if (true)
            {
                quality.Click("link=Upload");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(3000);
                quality.Click("link=Manual Upload");

                Thread.Sleep(5000);
                selenium.SelectFrame("browseComputerElementContents");
                quality.Type("id=data", filepath);
                Thread.Sleep(1000);
                //selenium.AttachFile("id=data", filepath);
                quality.Click("id=uploadFromFileButton");
                selenium.WaitForPageToLoad("30000");
                //Thread.Sleep(10000);


                quality.Click("link=View details");

                selenium.WaitForPageToLoad("30000");
                quality.IsTextPresent("Untitled");
                selenium.Refresh(); 
            }


        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckForFirmware()
        {
            Thread.Sleep(10000);
            quality.Click("link=Get Started");
            /*
            bool success = false;
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    selenium.Click("link=Get Started");
                    success = true;
                    currenttest.passedcheck++;
                    i = 30;
                }
                catch (ElementNotVisibleException)
                {

                    Thread.Sleep(1000);
                    success = false;
                }
                catch 
                {

                    Thread.Sleep(1000);
                    success = false;
                }
            }
            if (success == false)
            {
                quality.ErrorReport("link=Get Started", CheckType.Link);
                currenttest.failedcheck++;
            }
             */ 
        }

        /// <summary>
        /// Signs the user out
        /// </summary>
        /// <param name="quality"></param>
        public void SignOut()
        {
            Thread.Sleep(2000);
            quality.Click("id=signOutLink");
            selenium.WaitForPageToLoad("30000");
        }

        
        /// <summary>
        /// This is the new sign-in method for SSO
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void SignIn(string username, string password)
        {
            selenium.WaitForPageToLoad("30000");
            quality.Click("link=Sign In");
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(1000);
            quality.Type("id=login:loginUsernameField", username);
            quality.Type("id=login:password", password);

            quality.Click("id=login:signInButton");
            /*
            quality.SelectFrame("gauth-widget-frame");
            quality.Type("id=username", username);
            quality.Type("id=password", password);
            quality.Click("class=btn1");
             */ 
            selenium.WaitForPageToLoad("30000");
            
        }

    }
}
