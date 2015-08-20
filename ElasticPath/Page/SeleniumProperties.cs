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
    /**
     * Default constructor.
     */
    public class SeleniumProperties
    {

        //private static long serialVersionUID = 1L;

        /// <summary>
        /// 
        /// </summary>
        public SeleniumProperties()
        {


        }


        /**
         * Searches for the property with the specified key in this property list
         * and splits the property into array using the specified regular
         * expression. The method returns null if the property is not found.
         * 
         * @param key
         *            the property key
         * @param regex
         *            the delimiting regular expression
         * @return an array of values for specified property key
         */

    
        ///  <summary>
        /// This method is defunct.  Was calling for getProperty(key); //no such method exists
        /// </summary>
        public string[] getPropertyAsArray(string key, string[] regex)
        {
            //This method is defunct.  Was calling for getProperty(key); //no such method exists
            String property = key;
            if (property == null)
            {
                return null;
            }
            else
            {
                return property.Split(regex, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
