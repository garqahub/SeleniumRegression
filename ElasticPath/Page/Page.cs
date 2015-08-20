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
using Selenium;
using System.IO;
#endregion

namespace SeleniumRegression
{
    public class Page
    {

        WebDriverBackedSelenium driver;

        public Page(WebDriverBackedSelenium webdriver)
        {
            driver = webdriver;
            
        }

        public void openPage(String url)
        {
            driver.Open(url);
        }

        public void closeDriver()
        {
            driver.Close();
            
        }


    }
}
