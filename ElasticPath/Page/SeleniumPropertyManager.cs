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
    public class SeleniumPropertyManager
    {
        /** Singleton instance **/
        private static SeleniumPropertyManager instance = null;

        /** Location of configuration file **/
        //private String CONFIG_LOCATION = "selenium.properties";

        /** Property object used for getting the properties **/
        //private Properties.Settings properties;
        //string error;

        public SeleniumPropertyManager()
        {

        }
        

        /**
         * Limited scope constructor to prevent instantiation.
         */
        /*
      private SeleniumPropertyManager()
      {
          
          properties = new Properties.Settings();
          try
          {
              ClassLoader loader = ClassLoader.getSystemClassLoader();

              if (loader != null)
              {
                  URL url = loader.getResource(CONFIG_LOCATION);
                  if (url == null)
                  {
                      url = loader.getResource(File.separator + CONFIG_LOCATION);
                  }
                  FileStream inputStream = url.openStream();
                  if (inputStream == null)
                  {
                      throw new FileNotFoundException("Property file '" + CONFIG_LOCATION + "' not found in the classpath!");
                  }
                  properties.load(inputStream);
              }
          }
          catch (FileNotFoundException e)
          {
              error = e.StackTrace;
          }
          catch (IOException e)
          {
              error = e.StackTrace;
          }
           * 
      }
         **/
      
        /*
         * Gets an instance of EPPropertyManager.
         * 
         * @return an instance of EPPropertyManager
         */
        public static void getInstance(ref SeleniumPropertyManager sessioninstance)
        {
            instance = sessioninstance;
            if (instance == null)
            {
               // instance = new SeleniumPropertyManager();
            }
        
        }


        /**
         * Fetches property value given the key.
         * 
         * @param key the key used to identify the requested value
         * @return value associated with key or null if key doesn't exist
         */
        public String getProperty()
        {
            //return properties.SettingsKey;
            return "";
        }



    }
}
