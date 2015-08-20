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
    class Footer
    {
        WebDriverBackedSelenium driver;
        QualityCheck quality;

        public Footer(WebDriverBackedSelenium webdriver, ParentTest test)
        {
            driver = webdriver;
            quality = new QualityCheck(test);
        }

        public void clickDutchLanguageLink()
        {
            quality.Select("languageSelect", "Nederland - Nederlands");
            //IWebElement dutchLanguageLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("footer.language.nl"));
            //dutchLanguageLink.Click();
        }

        public void clickFrenchLanguageLink()
        {
            quality.Select("languageSelect", "France - français");
            //IWebElement dutchLanguageLink = driver.UnderlyingWebDriver.FindElement(By.LinkText("nl_FranÃ§ais"));
            //dutchLanguageLink.Click();
        }


    }
}
