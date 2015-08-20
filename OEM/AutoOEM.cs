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
#endregion
namespace SeleniumRegression
{
    class AutoOEM : TestRunner
    {

        public List<ParentTest> SignIn, AccountCreation, Dashboard, Navigation, ForgotUsername, Account, Scan, NoScan, TroubleShoot;
        public string username, password, fullname, unitId, unitIdNotRegistered, unitIdRegistered, validationCode, productKey;
        #region Constructor
        public AutoOEM(StringBuilder verrors, List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {
            //These came from the scripts.  Once central location to change these values.  To do- work into GUI
            username = "testUser2012";
            password = "password";
            fullname = "test User";
            unitId = "3422110885";//"3563850818";
            unitIdNotRegistered = "3422110080";
            unitIdRegistered = "3422110271";
            validationCode = "BBKJ";
            productKey = "TKJEXZ7Q";

            base.verificationErrors = verrors;
            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            SignIn = new List<ParentTest>();
            AccountCreation = new List<ParentTest>();
            Dashboard = new List<ParentTest>();
            Navigation = new List<ParentTest>();
            ForgotUsername = new List<ParentTest>();
            Account = new List<ParentTest>();
            Scan = new List<ParentTest>();
            NoScan = new List<ParentTest>();
            TroubleShoot = new List<ParentTest>();
            RunTests();
        }
        public AutoOEM(List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {
            //These came from the scripts.  Once central location to change these values.  To do- work into GUI
            username = "testUser2012";
            password = "password";
            fullname = "test User";
            unitId = "3422110885";//"3563850818";
            unitIdNotRegistered = "3422110080";
            unitIdRegistered = "3422110271";
            validationCode = "BBKJ";
            productKey = "TKJEXZ7Q";


            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            SignIn = new List<ParentTest>();
            AccountCreation = new List<ParentTest>();
            Dashboard = new List<ParentTest>();
            Navigation = new List<ParentTest>();
            ForgotUsername = new List<ParentTest>();
            Account = new List<ParentTest>();
            Scan = new List<ParentTest>();
            NoScan = new List<ParentTest>();
            TroubleShoot = new List<ParentTest>();
            PopulateLists();

            scriptlist.Add(AccountCreation);
            scriptlist.Add(SignIn);
            scriptlist.Add(Navigation);
            scriptlist.Add(Dashboard);
            scriptlist.Add(ForgotUsername);
            scriptlist.Add(Account);
            scriptlist.Add(Scan);
            scriptlist.Add(NoScan);
            scriptlist.Add(TroubleShoot);
        }
        #endregion

        //Populate the script lists here.  Follow the example on how to add to a list
        #region Populate Lists
        /// <summary>
        /// Use this method to populate the lists.  They are already set to be selected from the 
        /// CycleScripts method and no other work is required.
        /// </summary>
        public override void PopulateLists()
        {
            Account.Clear();
            ForgotUsername.Clear();
            SignIn.Clear();
            AccountCreation.Clear();
            Dashboard.Clear();
            Navigation.Clear();
            Scan.Clear();
            NoScan.Clear();
            TroubleShoot.Clear();
            base.PopulateLists();
            //MyCategory.Add(new TestCase(base.baseURL, base.webdriver, base.verificationErrors));           
           
            Navigation.Add(new Kenwood_Navigation(base.baseURL, base.webdriver, base.verificationErrors));
            SignIn.Add(new Kenwood_SingInTest(base.baseURL, base.webdriver, base.verificationErrors));
            SignIn.Add(new Kenwood_SignInIndicationTest(base.baseURL, base.webdriver, base.verificationErrors));
            SignIn.Add(new Kenwood_SignOut_ValidationTest(base.baseURL, base.webdriver, base.verificationErrors));
            AccountCreation.Add(new TheKenwood_CreateAccount_NewUserTest(base.baseURL, base.webdriver, base.verificationErrors));
            AccountCreation.Add(new Kenwood_CreateAccount_ValidationTest(base.baseURL, base.webdriver, base.verificationErrors));
            ForgotUsername.Add(new Kenwood_ForgotUsername_ValidationTest(base.baseURL, base.webdriver, base.verificationErrors));
            Account.Add(new Kenwood_MyAccount_ValidationTest(base.baseURL, base.webdriver, base.verificationErrors));
            Account.Add(new Kenwood_MyAccount_OrderHistoryTest(base.baseURL, base.webdriver, base.verificationErrors));
            Account.Add(new Kenwood_MyAccount_TrafficSubscriptions_UnlockCodesTest(base.baseURL, base.webdriver, base.verificationErrors));
            Account.Add(new Kenwood_MyAccount_TrafficSubscriptions_ActivateSubscriptionTest(base.baseURL, base.webdriver, base.verificationErrors));
            Account.Add(new Kenwood_ActivateYourMap_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            Account.Add(new Kenwood_ActivateYourMap_GetUnlockCode(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_CheckAddToCart_TrafficService_UserNotLogged_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            //NoScan.Add(new Kenwood_NoScanSD_CheckDeliveryOptions_Validation(base.baseURL, base.webdriver, base.verificationErrors));  //not working in FF to ID missing elements.
            NoScan.Add(new Kenwood_NoScanSD_CheckTheSoftwareUpdates(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_CheckTrafficServices(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_CheckLatestMapForKenwood(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_OtherRegion_CheckTheSoftwareUpdates(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_OtherRegion_CheckLatestMapForKenwood(base.baseURL, base.webdriver, base.verificationErrors));
            //NoScan.Add(new Kenwood_NoScanSD_CheckShippingAddress_Validation(base.baseURL, base.webdriver, base.verificationErrors)); //Not working in FF cannot ID
            NoScan.Add(new Kenwood_NoScanSD_CheckAddToCart_TrafficService_ExternalTrafficRec_CancelPressed(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_CheckAddToCart_TrafficService_CancelPressed(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_CheckShoppingCart_ForATrafficServcie_TryToUpdate(base.baseURL, base.webdriver, base.verificationErrors));
            NoScan.Add(new Kenwood_NoScanSD_CheckShoppingCart_ForATrafficServcie_ContinueShopping(base.baseURL, base.webdriver, base.verificationErrors));
            //NoScan.Add(new Kenwood_NoScanSD_CheckShoppingCart_ForATrafficServcie_ShippingValidation(base.baseURL, base.webdriver, base.verificationErrors));  //Not working in FF and cannot ID
            Scan.Add(new Kenwood_ScanSD_CheckAddToCart_TrafficService_DeviceAlreadyRegisteredToAnotherUser(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckAddToCart_TrafficService_DeviceHasOnlyTrafficReceiveId(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckLatestMap_DeviceRequieresUpdates_DNX9980_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckLatestMap_DeviceRequieresUpdates_DNX7180_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckShoppingCart_ForALatestMap_TryToUpdate(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckShoppingCart_ForALatestMap_ContinueShopping(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckShoppingCart_ForALatestMap_UserNotLogged_ShippingValidation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckShippingAddress_UpdateDetails_BackCart(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckBillingAddress_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_PaymentInformation_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_WL_PaymentInfo_check(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckMediaScanValidation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckTheSoftwareUpdates_FirmwareValidation(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckRealTrafficSubscription(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckTrafficServicesForKenwood(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_ScanSD_CheckLatestMapForKenwood(base.baseURL, base.webdriver, base.verificationErrors));
            Scan.Add(new Kenwood_Model(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Kenwood_OrderSummary_check(base.baseURL, base.webdriver, base.verificationErrors));
            TroubleShoot.Add(new Kenwood_CheckEach_NA_DeviceType_fortheProductUpdates(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Kenwood_CheckEach_EU_DeviceType_fortheProductUpdates(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Kenwood_CheckEach_Other_DeviceType_fortheProductUpdates(base.baseURL, base.webdriver, base.verificationErrors));
        }
        #endregion

        #region Run Test
        public override void RunTests(int index, int testnumber)
        {
            base.RunTests();
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            for (int i = 0; i < base.browsers.Count; i++)
            {
                base.SetupTest(browsers[i]);
                PopulateLists();
                AddText("   Script Set: " + scriptlist[index][testnumber].id + " started.", fonttype.ScriptFont);
                scriptlist[index][testnumber].selenium = webdriver;
                TestActions(scriptlist[index][testnumber]);
            }
        }
        public override void RunTests()
        {
            base.RunTests();

            for (int i = 0; i < browsers.Count; i++)
            {
                base.SetupTest(browsers[i]);
                PopulateLists();
                CycleScripts();
            }
        }
        #endregion

        private void AssignValues(ParentTest test)
        {

            test.username = username;
            test.password = password;
            test.fullname = fullname;
            test.unitId = unitId;
            test.unitIdNotRegistered = unitIdNotRegistered;
            test.unitIdRegistered = unitIdRegistered;
            test.validationCode = validationCode;
            test.productKey = productKey;

        }

        #region CycleScripts
        public override void CycleScripts()
        {
            for (int i = 0; i < scriptset.Count; i++)
            {
                base.CycleScripts();
                AddText("   Script Set: " + scriptset[i] + " started.", fonttype.ScriptFont);
                switch (scriptset[i])
                {
                    case "Account Creation":
                        base.testcount += AccountCreation.Count;
                        for (int j = 0; j < AccountCreation.Count; j++)
                        {
                            AssignValues(AccountCreation[j]);
                            base.TestActions(AccountCreation[j]);
                        }
                        break;

                    case "Sign In":
                        base.testcount += SignIn.Count;
                        for (int j = 0; j < SignIn.Count; j++)
                        {
                            AssignValues(SignIn[j]);
                            base.TestActions(SignIn[j]);
                        }
                        break;

                    case "Dashboard":
                        base.testcount += Dashboard.Count;
                        for (int j = 0; j < Dashboard.Count; j++)
                        {
                            AssignValues(Dashboard[j]);
                            base.TestActions(Dashboard[j]);
                        }
                        break;
                    case "Navigation":
                        base.testcount += Navigation.Count;
                        for (int j = 0; j < Navigation.Count; j++)
                        {
                            AssignValues(Navigation[j]);
                            base.TestActions(Navigation[j]);
                        }
                        break;
                    case "Forgot Username":
                        base.testcount += ForgotUsername.Count;
                        for (int j = 0; j < ForgotUsername.Count; j++)
                        {
                            AssignValues(ForgotUsername[j]);
                            base.TestActions(ForgotUsername[j]);
                        }
                        break;
                    case "Account":
                        base.testcount += Account.Count;
                        for (int j = 0; j < Account.Count; j++)
                        {
                            AssignValues(Account[j]);
                            base.TestActions(Account[j]);
                        }
                        break;
                    case "ScanSDcard":
                        base.testcount += Scan.Count;
                        for (int j = 0; j < Scan.Count; j++)
                        {
                            AssignValues(Scan[j]);
                            base.TestActions(Scan[j]);
                        }
                        break;
                    case "NoScanSDcard":
                        base.testcount += NoScan.Count;
                        for (int j = 0; j < NoScan.Count; j++)
                        {
                            AssignValues(NoScan[j]);
                            base.TestActions(NoScan[j]);
                        }
                        break;
                    case "TroubleShoot":
                        base.testcount += TroubleShoot.Count;
                        for (int j = 0; j < TroubleShoot.Count; j++)
                        {
                            AssignValues(TroubleShoot[j]);
                            base.TestActions(TroubleShoot[j]);
                        }
                        break;
                    case "All Scripts":
                        scriptset.Clear();
                        scriptset.Add("Account Creation");
                        scriptset.Add("Sign In");
                        scriptset.Add("Dashboard");
                        scriptset.Add("Navigation");
                        scriptset.Add("Forgot Username");
                        scriptset.Add("ScanSDcard");
                        scriptset.Add("NoScanSDcard");
                        scriptset.Add("Account");
                        CycleScripts();
                        scriptset.Clear();
                        break;
                }
            }
            base.TeardownTest();
        }
        #endregion
    }
}
