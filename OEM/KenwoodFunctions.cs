
#region Using Statements
using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Windows.Forms;
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
    class KenwoodFunctions
    {
        public QualityCheck selenium;
        public WebDriverBackedSelenium seleniumdriver;
        string var;
        string browser;
        
        public KenwoodFunctions(QualityCheck quality, WebDriverBackedSelenium driver)
        {
            var = Environment.GetEnvironmentVariable("locale");
            selenium = quality;
            seleniumdriver = driver;
            browser = Environment.GetEnvironmentVariable("browser");
        }

        public void Checkout(string firstname, string lastname, string country, string address1, string address2, string city, string state, string zip, string phone)
        {
            selenium.SelectFrame("wlc-widget-frame");
            
            selenium.Type("id=shippingAddressfirstName", firstname);
            selenium.Type("id=shippingAddresslastName", lastname);
            selenium.Select("id=shippingAddresscountry", country);
            selenium.Type("id=shippingAddressaddress1", address1);
            selenium.Type("id=shippingAddressaddress2", address2);
            selenium.Type("id=shippingAddresscity", "");
            selenium.Type("id=shippingAddresscity", city);
            selenium.Select("id=shippingAddressstate", state);
            selenium.Type("id=shippingAddresszipPostal", "");
            selenium.Type("id=shippingAddresszipPostal", zip);
            selenium.Type("id=shippingAddressphone", "");
            selenium.Type("id=shippingAddressphone", phone);

            selenium.Highlight("id=continueBtn");
                     
            selenium.Click("id=continueBtn");

            MessageBox.Show("If using IE, click continue before clicking okay.  It is full of fail and will not click it no matter how many times I tell it to.  Sorry :(");
            /*
            selenium.Click("id=continueBtn");
            seleniumdriver.DoubleClick("id=continueBtn");
            seleniumdriver.DoubleClick("id=continueBtn");
            */
        }

        public bool CheckForTimeOut(string text, string fieldID, int timeoutcount)
        {
            for (int second = 0; second < timeoutcount; second++)
            {
                if (second >= timeoutcount-1)
                {
                    selenium.ErrorReport("scan timeout", CheckType.Warning);
                    return true;
                }
                try
                {
                    if (seleniumdriver.IsTextPresent(text))
                    {
                        second = timeoutcount;
                        return false;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            return false;
        }

        public bool IsQuantityEditable()
        {
            try
            {
                if (seleniumdriver.IsEditable("id=quantityDisabled") == false)
                {
                    selenium.ErrorReport("Quantity Cannot be changed", CheckType.Element);
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SignIn(string username, string password)
        {
            selenium.Type("id=username", username);
            selenium.Type("id=password", password);
            selenium.Click("css=a.button > span");
            selenium.WaitForPageToLoad("30000");
        }

        public void SignInPage()
        {
            // comment: Validate the Sign In page
            selenium.IsTextPresent("Sign In");            
            selenium.IsTextPresent("Username");
            selenium.AreEqual("", selenium.GetText("id=username"));
            selenium.IsTextPresent("Password");
            
            selenium.AreEqual("", selenium.GetText("id=password"));
            selenium.AreEqual("Sign In", selenium.GetText("css=a.button"));
            selenium.AreEqual("Forgot username", selenium.GetText("link=Forgot username"));
            selenium.AreEqual("Forgot password", selenium.GetText("link=Forgot password"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=div.dontHaveAccount"), "^Don't have an account[\\s\\S]$"));
            selenium.AreEqual("Create Account", selenium.GetText("css=div.left > a.button > span"));
            
        }

        public void Login(string username, string password, string fullname, bool atCheckOut)
        {
            // comment: Log ing with a My Garmin user and password
            selenium.Type("id=username", username);
            selenium.Type("id=password", password);
            selenium.Click("css=a.button > span");
            seleniumdriver.WaitForPageToLoad("30000");

            if (!atCheckOut)
            {

                selenium.IsTextPresent("Garmin Product Updates for Kenwood");
                selenium.IsTextPresent("Welcome to Garmin Product Updates for Kenwood");
                selenium.IsTextPresent("Welcome " + fullname);
            }
        }

        public void Logout()
        {
            // comment: Sign Out
            Thread.Sleep(1000);
            selenium.Click("link=Sign Out");
            seleniumdriver.WaitForPageToLoad("30000");
            selenium.IsTextPresent("Garmin Product Updates for Kenwood");
            selenium.IsTextPresent("Not signed in");
        }

        public void WelcomePage()
        {
            //Assert.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());
            selenium.Click("css=div.titleHeader-text");
            selenium.IsTextPresent("Welcome to Garmin Product Updates for Kenwood");
            selenium.IsTextPresent("All Kenwood devices are compatible only with the Kenwood maps on this website or the ones from Kenwood dealers");
            //Assert.AreEqual("", selenium.GetText("//img[contains(@src,'https://static.garmincdn.com/autoOem/kenwood/Banner3.jpg')]"));
            selenium.IsTextPresent("Product Updates");
            selenium.IsTextPresent("Get maps, software updates and accessories");
            selenium.IsTextPresent("Update");
            selenium.IsTextPresent("Activate Map Updates");
            selenium.IsTextPresent("Get the unlock code and activate your map DVD");
            selenium.IsTextPresent("Activate");
        }

        public void ForgotUsernamePage()
        {
            //Assert.AreEqual("Forgot Username", selenium.GetTitle());
            selenium.IsTextPresent("Forgot Username");
            selenium.IsTextPresent("To retrieve your username, enter the email address that you saved in your myGarmin account. If you did not save an email address in your account or you do not remember it, please contact Product Support.");
            selenium.IsTextPresent("Email Address");
            //Assert.AreEqual("", selenium.GetText("id=email"));
        }

        public void ForgotPasswordPage()
        {
            //Assert.AreEqual("Forgot Password", selenium.GetTitle());
            //Assert.AreEqual("Forgot Password", selenium.GetText("css=div.titleHeader-text"));
            selenium.IsTextPresent("To reset your password, enter the username of your myGarmin account. If you do not remember your username, please contact Product Support.");
            selenium.Highlight("link=Product Support");
            selenium.IsTextPresent("Username");
            //Assert.AreEqual("", selenium.GetText("id=username"));
            selenium.IsTextPresent("Submit");
        }

        public void MyAccountPage(bool hasAddress2)
        {
            //Assert.AreEqual("Account Settings", selenium.GetTitle());
            selenium.IsTextPresent("My Account");
            selenium.IsTextPresent("My Info");
            selenium.IsTextPresent("Username:");
            selenium.IsTextPresent("Full Name:");
            selenium.IsTextPresent("Email Address:");
            selenium.IsTextPresent("Address:");

            if (hasAddress2)
            {
                selenium.IsTextPresent("Address 2:");
                selenium.IsTextPresent("City:");
                selenium.IsTextPresent("State/Province:");
                selenium.IsTextPresent("Zip/Postal Code:");
                selenium.IsTextPresent("Country:");
                selenium.IsTextPresent("Edit Account");
                selenium.IsTextPresent("Change Password");
                selenium.IsTextPresent("My History");
                selenium.IsTextPresent("View Subscriptions");
                selenium.IsTextPresent("View All Orders");
                selenium.IsTextPresent("View Downloads");
            }

            else
            {
                selenium.IsTextPresent("City:");
                selenium.IsTextPresent("State/Province:");
                selenium.IsTextPresent("Zip/Postal Code:");
                selenium.IsTextPresent("Country:");
                selenium.IsTextPresent("Edit Account");
                selenium.IsTextPresent("Change Password");
                selenium.IsTextPresent("My History");
                selenium.IsTextPresent("View Subscriptions");
                selenium.IsTextPresent("View All Orders");
                selenium.IsTextPresent("View Downloads");
            }
        }

        public void CreateAccountPage()
        {
            //Assert.AreEqual("Create Account", selenium.GetTitle());
            selenium.IsTextPresent("Create Account");
            //-------------

            /*  This section needs to be updated for checks.
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.supportingText"), "^[\\s\\S]* Required fields$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=label"), "^[\\s\\S]*Full Name$"));
            Assert.AreEqual("", selenium.GetText("id=fullName"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr/td[2]/label"), "^[\\s\\S]*Email Address$"));
            Assert.AreEqual("", selenium.GetText("id=email"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[2]/td/label"), "^[\\s\\S]*Address$"));
            Assert.AreEqual("", selenium.GetText("id=address"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[2]/td[2]/label"), "^[\\s\\S]*Username$"));
            Assert.AreEqual("", selenium.GetText("id=username"));
            Assert.AreEqual("Address 2", selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[3]/td/label"));
            Assert.AreEqual("", selenium.GetText("id=address2"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[3]/td[2]/label"), "^[\\s\\S]*Password$"));
            Assert.AreEqual("", selenium.GetText("id=password"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.left > label"), "^[\\s\\S]*City$"));
            Assert.AreEqual("", selenium.GetText("id=city"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.right > label"), "^[\\s\\S]*State/Province$"));
            Assert.AreEqual("selectAAAEAPAlabamaAlaskaAlbertaArizonaArkansasBritish ColumbiaCaliforniaColoradoConnecticutDelawareDistrict of ColumbiaFloridaGeorgiaHawaiiIdahoIllinoisIndianaIowaKansasKentuckyLouisianaMaineManitobaMarylandMassachusettsMichiganMinnesotaMississippiMissouriMontanaNebraskaNevadaNew BrunswickNew HampshireNew JerseyNew MexicoNew YorkNewfoundland and LabradorNorth CarolinaNorth DakotaNorthwest TerritoriesNova ScotiaNunavutOhioOklahomaOntarioOregonPennsylvaniaPrince Edward IslandPuerto RicoQuebecRhode IslandSaskatchewanSouth CarolinaSouth DakotaTennesseeTexasUtahVermontVirginiaWashingtonWest VirginiaWisconsinWyomingYukon", selenium.GetText("id=state"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[4]/td[2]/label"), "^[\\s\\S]*Retype Password$"));
            Assert.AreEqual("", selenium.GetText("id=retypePassword"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[5]/td/div/label"), "^[\\s\\S]*Zip/Postal Code$"));
            Assert.AreEqual("", selenium.GetText("id=zip"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[5]/td/div[2]/label"), "^[\\s\\S]*Country$"));
            Assert.AreEqual("selectAfghanistanAlbaniaAlgeriaAmerican SamoaAndorraAngolaAnguillaAntarcticaAntigua and BarbudaArgentinaArmeniaArubaAustraliaAustriaAzerbaijanBahamasBahrainBangladeshBarbadosBelarusBelgiumBelizeBeninBermudaBhutanBoliviaBosnia and HerzegovinaBotswanaBouvet IslandBrazilBritish Indian Ocean TerritoryBrunei DarussalamBulgariaBurkina FasoBurundiCambodiaCameroonCanadaCape VerdeCayman IslandsCentral African RepublicChadChileChinaChristmas IslandCocos (Keeling) IslandsColombiaComorosCongoCongo, The Democratic Republic of theCook IslandsCosta RicaCroatiaCubaCyprusCzech RepublicDenmarkDjiboutiDominicaDominican RepublicEcuadorEgyptEl SalvadorEquatorial GuineaEritreaEstoniaEthiopiaFalkland Islands (Malvinas)Faroe IslandsFijiFinlandFranceFrench GuianaFrench PolynesiaFrench Southern TerritoriesGabonGambiaGeorgiaGermanyGhanaGibraltarGreeceGreenlandGrenadaGuadeloupeGuamGuatemalaGuineaGuinea-BissauGuyanaHaitiHeard Island and McDonald IslandsHoly See (Vatican City State)HondurasHong KongHungaryIcelandIndiaIndonesiaIran, Islamic Republic ofIraqIrelandIsraelItalyJamaicaJapanJordanKazakhstanKenyaKiribatiKorea, Democratic PeopleKorea, Republic ofKuwaitKyrgyzstanLao PeopleLatviaLebanonLesothoLiberiaLibyan Arab JamahiriyaLiechtensteinLithuaniaLuxembourgMacaoMacedonia, The Former Yugoslav Republic ofMadagascarMalawiMalaysiaMaldivesMaliMaltaMarshall IslandsMartiniqueMauritaniaMauritiusMayotteMexicoMicronesia, Federated States ofMoldova, Republic ofMonacoMongoliaMontserratMoroccoMozambiqueMyanmarNamibiaNauruNepalNetherlandsNetherlands AntillesNew CaledoniaNew ZealandNicaraguaNigerNigeriaNiueNorfolk IslandNorthern Mariana IslandsNorwayOmanPakistanPalauPalestinian Territory,OccupiedPanamaPapua New GuineaParaguayPeruPhilippinesPitcairnPolandPortugalPuerto RicoQatarRepublic of Ivory CoastReunionRomaniaRussian FederationRwandaSaint HelenaSaint Kitts and NevisSaint LuciaSaint Pierre and MiquelonSaint Vincent and the GrenadinesSamoaSan MarinoSao Tome and PrincipeSaudi ArabiaSenegalSerbia and MontenegroSeychellesSierra LeoneSingaporeSlovakiaSloveniaSolomon IslandsSomaliaSouth AfricaSouth Georgia and the South Sandwich IslandsSpainSri LankaSudanSurinameSvalbard and Jan MayenSwazilandSwedenSwitzerlandSyrian Arab RepublicTaiwanTajikistanTanzania, United Republic ofThailandTimor-LesteTogoTokelauTongaTrinidad and TobagoTunisiaTurkeyTurkmenistanTurks and Caicos IslandsTuvaluUgandaUkraineUnited Arab EmiratesUnited KingdomUnited StatesUnited States Minor Outlying IslandsUruguayUzbekistanVanuatuVenezuelaViet NamVirgin Islands, BritishVirgin Islands, U.S.Wallis and FutunaWestern SaharaYemenZambiaZimbabwe", selenium.GetText("id=country"));
            Assert.AreEqual("", selenium.GetText("id=subscribeEmail"));
            Assert.AreEqual("Receive Email alerts when product updates are available", selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[6]/td"));
            Assert.AreEqual("By clicking the Submit button below, you acknowledge that you have read and agree to the Garmin Terms of Use and Privacy Statement", selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[7]/td"));
            */
            //------------------

            /*  This was already commented out.
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=label"), "^[\\s\\S]*Full Name$"));
            Assert.AreEqual("", selenium.GetText("id=fullName"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr/td[2]/label"), "^[\\s\\S]*Username$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[2]/td[2]/label"), "^[\\s\\S]*Username$"));
            Assert.AreEqual("", selenium.GetText("id=username"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[2]/td/label"), "^[\\s\\S]*Address$"));
            Assert.AreEqual("", selenium.GetText("id=address"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[2]/td[2]/label"), "^[\\s\\S]*Password$"));
            Assert.AreEqual("", selenium.GetText("id=password"));
            Assert.AreEqual("Address 2", selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[3]/td/label"));
            Assert.AreEqual("", selenium.GetText("id=address2"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[3]/td[2]/label"), "^[\\s\\S]*Retype Password$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[4]/td[2]/label"), "^[\\s\\S]*Retype Password$"));
            Assert.AreEqual("", selenium.GetText("id=retypePassword"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.left > label"), "^[\\s\\S]*City$"));
            Assert.AreEqual("", selenium.GetText("id=city"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[4]/td/div[2]/label"), "^[\\s\\S]*State/Province$"));
            Assert.AreEqual("selectAAAEAPAlabamaAlaskaAlbertaArizonaArkansasBritish ColumbiaCaliforniaColoradoConnecticutDelawareDistrict of ColumbiaFloridaGeorgiaHawaiiIdahoIllinoisIndianaIowaKansasKentuckyLouisianaMaineManitobaMarylandMassachusettsMichiganMinnesotaMississippiMissouriMontanaNebraskaNevadaNew BrunswickNew HampshireNew JerseyNew MexicoNew YorkNewfoundland and LabradorNorth CarolinaNorth DakotaNorthwest TerritoriesNova ScotiaNunavutOhioOklahomaOntarioOregonPennsylvaniaPrince Edward IslandPuerto RicoQuebecRhode IslandSaskatchewanSouth CarolinaSouth DakotaTennesseeTexasUtahVermontVirginiaWashingtonWest VirginiaWisconsinWyomingYukon", selenium.GetText("id=state"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[4]/td[2]/label"), "^[\\s\\S]*Email Address$"));
            Assert.AreEqual("", selenium.GetText("id=email"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[5]/td/div/label"), "^[\\s\\S]*Country$"));
            Assert.AreEqual("selectAfghanistanAlbaniaAlgeriaAmerican SamoaAndorraAngolaAnguillaAntarcticaAntigua and BarbudaArgentinaArmeniaArubaAustraliaAustriaAzerbaijanBahamasBahrainBangladeshBarbadosBelarusBelgiumBelizeBeninBermudaBhutanBoliviaBosnia and HerzegovinaBotswanaBouvet IslandBrazilBritish Indian Ocean TerritoryBrunei DarussalamBulgariaBurkina FasoBurundiCambodiaCameroonCanadaCape VerdeCayman IslandsCentral African RepublicChadChileChinaChristmas IslandCocos (Keeling) IslandsColombiaComorosCongoCongo, The Democratic Republic of theCook IslandsCosta RicaCroatiaCubaCyprusCzech RepublicDenmarkDjiboutiDominicaDominican RepublicEcuadorEgyptEl SalvadorEquatorial GuineaEritreaEstoniaEthiopiaFalkland Islands (Malvinas)Faroe IslandsFijiFinlandFranceFrench GuianaFrench PolynesiaFrench Southern TerritoriesGabonGambiaGeorgiaGermanyGhanaGibraltarGreeceGreenlandGrenadaGuadeloupeGuamGuatemalaGuineaGuinea-BissauGuyanaHaitiHeard Island and McDonald IslandsHoly See (Vatican City State)HondurasHong KongHungaryIcelandIndiaIndonesiaIran, Islamic Republic ofIraqIrelandIsraelItalyJamaicaJapanJordanKazakhstanKenyaKiribatiKorea, Democratic PeopleKorea, Republic ofKuwaitKyrgyzstanLao PeopleLatviaLebanonLesothoLiberiaLibyan Arab JamahiriyaLiechtensteinLithuaniaLuxembourgMacaoMacedonia, The Former Yugoslav Republic ofMadagascarMalawiMalaysiaMaldivesMaliMaltaMarshall IslandsMartiniqueMauritaniaMauritiusMayotteMexicoMicronesia, Federated States ofMoldova, Republic ofMonacoMongoliaMontserratMoroccoMozambiqueMyanmarNamibiaNauruNepalNetherlandsNetherlands AntillesNew CaledoniaNew ZealandNicaraguaNigerNigeriaNiueNorfolk IslandNorthern Mariana IslandsNorwayOmanPakistanPalauPalestinian Territory,OccupiedPanamaPapua New GuineaParaguayPeruPhilippinesPitcairnPolandPortugalPuerto RicoQatarRepublic of Ivory CoastReunionRomaniaRussian FederationRwandaSaint HelenaSaint Kitts and NevisSaint LuciaSaint Pierre and MiquelonSaint Vincent and the GrenadinesSamoaSan MarinoSao Tome and PrincipeSaudi ArabiaSenegalSerbia and MontenegroSeychellesSierra LeoneSingaporeSlovakiaSloveniaSolomon IslandsSomaliaSouth AfricaSouth Georgia and the South Sandwich IslandsSpainSri LankaSudanSurinameSvalbard and Jan MayenSwazilandSwedenSwitzerlandSyrian Arab RepublicTaiwanTajikistanTanzania, United Republic ofThailandTimor-LesteTogoTokelauTongaTrinidad and TobagoTunisiaTurkeyTurkmenistanTurks and Caicos IslandsTuvaluUgandaUkraineUnited Arab EmiratesUnited KingdomUnited StatesUnited States Minor Outlying IslandsUruguayUzbekistanVanuatuVenezuelaViet NamVirgin Islands, BritishVirgin Islands, U.S.Wallis and FutunaWestern SaharaYemenZambiaZimbabwe", selenium.GetText("id=country"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[5]/td/div[2]/label"), "^[\\s\\S]*Zip/Postal Code$"));
            Assert.AreEqual("", selenium.GetText("id=zip"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[5]/td[2]/label"), "^[\\s\\S]*Retype Email Address$"));
            Assert.AreEqual("", selenium.GetText("id=retypeEmail"));
            Assert.AreEqual("Receive Email alerts when product updates are available", selenium.GetText("css=span.left"));
            Assert.AreEqual("By clicking Continue, you agree to the Garmin Terms of Use and Privacy Statement.", selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[7]/td"));
            */
            selenium.AreEqual("Terms of Use", selenium.GetText("link=Terms of Use"));
            selenium.AreEqual("Privacy Statement", selenium.GetText("link=Privacy Statement"));
            selenium.AreEqual("Cancel", selenium.GetText("css=a.button > span"));
            selenium.AreEqual("Submit", selenium.GetText("//form[@id='createAccountForm']/table/tbody/tr[8]/td/a[2]/span"));
        }

        public void EditAccountPage()
        {
            //Assert.AreEqual("Edit Account", selenium.GetTitle());
            selenium.IsTextPresent("Edit Account");

            /*   This section needs to be updated.
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.supportingText"), "^[\\s\\S]* Required fields\\. Username cannot be changed\\.$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=label"), "^[\\s\\S]*Full Name$"));
            Assert.AreEqual("", selenium.GetText("id=fullName"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[2]/td/label"), "^[\\s\\S]*Address$"));
            Assert.AreEqual("", selenium.GetText("id=address"));
            Assert.AreEqual("Address 2", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[3]/td/label"));
            Assert.AreEqual("", selenium.GetText("id=address2"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.left > label"), "^[\\s\\S]*City$"));
            Assert.AreEqual("", selenium.GetText("id=city"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.right > label"), "^[\\s\\S]*State/Province$"));
            Assert.AreEqual("selectAAAEAPAlabamaAlaskaAlbertaArizonaArkansasBritish ColumbiaCaliforniaColoradoConnecticutDelawareDistrict of ColumbiaFloridaGeorgiaHawaiiIdahoIllinoisIndianaIowaKansasKentuckyLouisianaMaineManitobaMarylandMassachusettsMichiganMinnesotaMississippiMissouriMontanaNebraskaNevadaNew BrunswickNew HampshireNew JerseyNew MexicoNew YorkNewfoundland and LabradorNorth CarolinaNorth DakotaNorthwest TerritoriesNova ScotiaNunavutOhioOklahomaOntarioOregonPennsylvaniaPrince Edward IslandPuerto RicoQuebecRhode IslandSaskatchewanSouth CarolinaSouth DakotaTennesseeTexasUtahVermontVirginiaWashingtonWest VirginiaWisconsinWyomingYukon", selenium.GetText("id=state"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[5]/td/div/label"), "^[\\s\\S]*Zip/Postal Code$"));
            Assert.AreEqual("", selenium.GetText("id=zip"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[5]/td/div[2]/label"), "^[\\s\\S]*Country$"));
            Assert.AreEqual("selectAfghanistanAlbaniaAlgeriaAmerican SamoaAndorraAngolaAnguillaAntarcticaAntigua and BarbudaArgentinaArmeniaArubaAustraliaAustriaAzerbaijanBahamasBahrainBangladeshBarbadosBelarusBelgiumBelizeBeninBermudaBhutanBoliviaBosnia and HerzegovinaBotswanaBouvet IslandBrazilBritish Indian Ocean TerritoryBrunei DarussalamBulgariaBurkina FasoBurundiCambodiaCameroonCanadaCape VerdeCayman IslandsCentral African RepublicChadChileChinaChristmas IslandCocos (Keeling) IslandsColombiaComorosCongoCongo, The Democratic Republic of theCook IslandsCosta RicaCroatiaCubaCyprusCzech RepublicDenmarkDjiboutiDominicaDominican RepublicEcuadorEgyptEl SalvadorEquatorial GuineaEritreaEstoniaEthiopiaFalkland Islands (Malvinas)Faroe IslandsFijiFinlandFranceFrench GuianaFrench PolynesiaFrench Southern TerritoriesGabonGambiaGeorgiaGermanyGhanaGibraltarGreeceGreenlandGrenadaGuadeloupeGuamGuatemalaGuineaGuinea-BissauGuyanaHaitiHeard Island and McDonald IslandsHoly See (Vatican City State)HondurasHong KongHungaryIcelandIndiaIndonesiaIran, Islamic Republic ofIraqIrelandIsraelItalyJamaicaJapanJordanKazakhstanKenyaKiribatiKorea, Democratic PeopleKorea, Republic ofKuwaitKyrgyzstanLao PeopleLatviaLebanonLesothoLiberiaLibyan Arab JamahiriyaLiechtensteinLithuaniaLuxembourgMacaoMacedonia, The Former Yugoslav Republic ofMadagascarMalawiMalaysiaMaldivesMaliMaltaMarshall IslandsMartiniqueMauritaniaMauritiusMayotteMexicoMicronesia, Federated States ofMoldova, Republic ofMonacoMongoliaMontserratMoroccoMozambiqueMyanmarNamibiaNauruNepalNetherlandsNetherlands AntillesNew CaledoniaNew ZealandNicaraguaNigerNigeriaNiueNorfolk IslandNorthern Mariana IslandsNorwayOmanPakistanPalauPalestinian Territory,OccupiedPanamaPapua New GuineaParaguayPeruPhilippinesPitcairnPolandPortugalPuerto RicoQatarRepublic of Ivory CoastReunionRomaniaRussian FederationRwandaSaint HelenaSaint Kitts and NevisSaint LuciaSaint Pierre and MiquelonSaint Vincent and the GrenadinesSamoaSan MarinoSao Tome and PrincipeSaudi ArabiaSenegalSerbia and MontenegroSeychellesSierra LeoneSingaporeSlovakiaSloveniaSolomon IslandsSomaliaSouth AfricaSouth Georgia and the South Sandwich IslandsSpainSri LankaSudanSurinameSvalbard and Jan MayenSwazilandSwedenSwitzerlandSyrian Arab RepublicTaiwanTajikistanTanzania, United Republic ofThailandTimor-LesteTogoTokelauTongaTrinidad and TobagoTunisiaTurkeyTurkmenistanTurks and Caicos IslandsTuvaluUgandaUkraineUnited Arab EmiratesUnited KingdomUnited StatesUnited States Minor Outlying IslandsUruguayUzbekistanVanuatuVenezuelaViet NamVirgin Islands, BritishVirgin Islands, U.S.Wallis and FutunaWestern SaharaYemenZambiaZimbabwe", selenium.GetText("id=country"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[6]/td/label"), "^[\\s\\S]*Email Address$"));
            Assert.AreEqual("", selenium.GetText("id=email"));
            Assert.AreEqual("", selenium.GetText("id=subscribeEmail"));
            Assert.AreEqual("Receive Email alerts when product updates are available", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[7]/td"));
            */
            /*
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.supportingText"), "^[\\s\\S]* Required fields\\. Username cannot be changed\\.$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=label"), "^[\\s\\S]*Full Name$"));
            Assert.AreEqual("", selenium.GetText("id=fullName"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[2]/td/label"), "^[\\s\\S]*Address$"));
            Assert.AreEqual("", selenium.GetText("id=address"));
            Assert.AreEqual("Address 2", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[3]/td/label"));
            Assert.AreEqual("", selenium.GetText("id=address2"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[4]/td/label"), "^[\\s\\S]*City$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.left > label"), "^[\\s\\S]*City$"));
            Assert.AreEqual("", selenium.GetText("id=city"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[5]/td/label"), "^[\\s\\S]*State/Province$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.right > label"), "^[\\s\\S]*State/Province$"));
            Assert.AreEqual("selectAAAEAPAlabamaAlaskaAlbertaArizonaArkansasBritish ColumbiaCaliforniaColoradoConnecticutDelawareDistrict of ColumbiaFloridaGeorgiaHawaiiIdahoIllinoisIndianaIowaKansasKentuckyLouisianaMaineManitobaMarylandMassachusettsMichiganMinnesotaMississippiMissouriMontanaNebraskaNevadaNew BrunswickNew HampshireNew JerseyNew MexicoNew YorkNewfoundland and LabradorNorth CarolinaNorth DakotaNorthwest TerritoriesNova ScotiaNunavutOhioOklahomaOntarioOregonPennsylvaniaPrince Edward IslandPuerto RicoQuebecRhode IslandSaskatchewanSouth CarolinaSouth DakotaTennesseeTexasUtahVermontVirginiaWashingtonWest VirginiaWisconsinWyomingYukon", selenium.GetText("id=state"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[6]/td/label"), "^[\\s\\S]*Zip/Postal Code$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[5]/td/div/label"), "^[\\s\\S]*Zip/Postal Code$"));
            Assert.AreEqual("", selenium.GetText("id=zip"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[7]/td/label"), "^[\\s\\S]*Country$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[5]/td/div[2]/label"), "^[\\s\\S]*Country$"));
            Assert.AreEqual("selectAfghanistanAlbaniaAlgeriaAmerican SamoaAndorraAngolaAnguillaAntarcticaAntigua and BarbudaArgentinaArmeniaArubaAustraliaAustriaAzerbaijanBahamasBahrainBangladeshBarbadosBelarusBelgiumBelizeBeninBermudaBhutanBoliviaBosnia and HerzegovinaBotswanaBouvet IslandBrazilBritish Indian Ocean TerritoryBrunei DarussalamBulgariaBurkina FasoBurundiCambodiaCameroonCanadaCape VerdeCayman IslandsCentral African RepublicChadChileChinaChristmas IslandCocos (Keeling) IslandsColombiaComorosCongoCongo, The Democratic Republic of theCook IslandsCosta RicaCroatiaCubaCyprusCzech RepublicDenmarkDjiboutiDominicaDominican RepublicEcuadorEgyptEl SalvadorEquatorial GuineaEritreaEstoniaEthiopiaFalkland Islands (Malvinas)Faroe IslandsFijiFinlandFranceFrench GuianaFrench PolynesiaFrench Southern TerritoriesGabonGambiaGeorgiaGermanyGhanaGibraltarGreeceGreenlandGrenadaGuadeloupeGuamGuatemalaGuineaGuinea-BissauGuyanaHaitiHeard Island and McDonald IslandsHoly See (Vatican City State)HondurasHong KongHungaryIcelandIndiaIndonesiaIran, Islamic Republic ofIraqIrelandIsraelItalyJamaicaJapanJordanKazakhstanKenyaKiribatiKorea, Democratic PeopleKorea, Republic ofKuwaitKyrgyzstanLao PeopleLatviaLebanonLesothoLiberiaLibyan Arab JamahiriyaLiechtensteinLithuaniaLuxembourgMacaoMacedonia, The Former Yugoslav Republic ofMadagascarMalawiMalaysiaMaldivesMaliMaltaMarshall IslandsMartiniqueMauritaniaMauritiusMayotteMexicoMicronesia, Federated States ofMoldova, Republic ofMonacoMongoliaMontserratMoroccoMozambiqueMyanmarNamibiaNauruNepalNetherlandsNetherlands AntillesNew CaledoniaNew ZealandNicaraguaNigerNigeriaNiueNorfolk IslandNorthern Mariana IslandsNorwayOmanPakistanPalauPalestinian Territory,OccupiedPanamaPapua New GuineaParaguayPeruPhilippinesPitcairnPolandPortugalPuerto RicoQatarRepublic of Ivory CoastReunionRomaniaRussian FederationRwandaSaint HelenaSaint Kitts and NevisSaint LuciaSaint Pierre and MiquelonSaint Vincent and the GrenadinesSamoaSan MarinoSao Tome and PrincipeSaudi ArabiaSenegalSerbia and MontenegroSeychellesSierra LeoneSingaporeSlovakiaSloveniaSolomon IslandsSomaliaSouth AfricaSouth Georgia and the South Sandwich IslandsSpainSri LankaSudanSurinameSvalbard and Jan MayenSwazilandSwedenSwitzerlandSyrian Arab RepublicTaiwanTajikistanTanzania, United Republic ofThailandTimor-LesteTogoTokelauTongaTrinidad and TobagoTunisiaTurkeyTurkmenistanTurks and Caicos IslandsTuvaluUgandaUkraineUnited Arab EmiratesUnited KingdomUnited StatesUnited States Minor Outlying IslandsUruguayUzbekistanVanuatuVenezuelaViet NamVirgin Islands, BritishVirgin Islands, U.S.Wallis and FutunaWestern SaharaYemenZambiaZimbabwe", selenium.GetText("id=country"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[8]/td/label"), "^[\\s\\S]*Email Address$"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[6]/td/label"), "^[\\s\\S]*Email Address$"));
            Assert.AreEqual("", selenium.GetText("id=email"));
            Assert.IsTrue(Regex.IsMatch(selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[9]/td/label"), "^[\\s\\S]*Retype Email Address$"));
            Assert.AreEqual("", selenium.GetText("id=retypeEmail"));
            //Assert.AreEqual("Receive Email alerts when product updates are available", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[10]/td[2]"));
            Assert.AreEqual("Receive Email alerts when product updates are available", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[7]/td"));
            */

            selenium.IsTextPresent("Cancel");
            //Assert.AreEqual("Save Changes", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[8]/td/a[2]/span"));
            //Assert.AreEqual("Save Changes", selenium.GetText("//form[@id='editAccountForm']/table/tbody/tr[11]/td[2]/a[2]/span"));
            selenium.IsTextPresent("Save Changes");
        }

        public void ChangePasswordPage()
        {
            selenium.IsTextPresent("Change Password");
            //Assert.AreEqual("Change Password", selenium.GetText("css=div.titleHeader-text"));
            selenium.IsTextPresent("Username:");
            selenium.IsTextPresent("Current Password");

            selenium.IsTextPresent("New Password");
            //Assert.AreEqual("", selenium.GetValue("id=newPassword"));
            selenium.IsTextPresent("Retype Password");
            //Assert.AreEqual("", selenium.GetValue("id=retypePassword"));
            selenium.IsTextPresent("Cancel");
            selenium.IsTextPresent("Save Changes");
        }

        public void ViewSubscriptionsPage(bool noSubscriptions, bool isActivatedSubscr)
        {
            //Assert.AreEqual("My Subscriptions", selenium.GetTitle());
            selenium.IsTextPresent("My Subscriptions");
            selenium.IsTextPresent("Traffic");

            /*
            if (!noSubscriptions)
            {
                if (!isActivatedSubscr)
                {
                    //Assert.AreEqual("", selenium.GetText("css=#image > img"));

                    string subscription = selenium.GetText("id=name");
                    /*
                    Match match = Regex.Match(subscription, @"\s+([S|s]ubscription)\s+", RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        Assert.True(true);
                    }
                    
                    //Assert.AreEqual("Activate", selenium.GetText("css=#button > a.button > span"));
                }
                //if the subscription is already activated
                else
                {
                    //Assert.AreEqual("", selenium.GetText("css=#image > img"));

                    string subscription = selenium.GetText("id=name");

                    Match match = Regex.Match(subscription, @"\s+([S|s]ubscription)\s+", RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        Assert.True(true);
                    }

                    Assert.IsTrue(selenium.IsTextPresent("Traffic Receiver ID:"));

                    //Assert.AreEqual("Unlock Code", selenium.GetText("css=#button > a.button > span"));
                }
            }
            else
            {
                Assert.AreEqual("You currently do not have any subscriptions", selenium.GetText("css=div.none"));
            }
                */
            selenium.IsTextPresent("« Back");
        }

        public void ViewDownloadsPage(bool noDownloads)
        {
            //selenium.AreEqual("My Downloads", selenium.GetTitle());
            selenium.AreEqual("My Downloads", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("Description", selenium.GetText("css=div.text"));
            selenium.AreEqual("Product Key", selenium.GetText("css=div.productKey-hd > div.text"));
            selenium.AreEqual("Expiration", selenium.GetText("css=div.expirationDate-hd > div.text"));

            selenium.AreEqual("« Back", selenium.GetText("css=a.button > span"));

            if (!noDownloads)
            {

            }
            else
            {
                selenium.AreEqual("Our records show you have no orders", selenium.GetText("css=div.noHistory"));
            }

            selenium.AreEqual("« Back", selenium.GetText("css=a.button > span"));
        }

        public void ActivateMapPage()
        {
            //selenium.AreEqual("Activate Map Update", selenium.GetTitle());
            selenium.AreEqual("Activate Your New Map", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("Your new map on DVD must be activated before you can begin using it. To activate your map, follow the instructions below.", selenium.GetText("css=p.description"));
            selenium.AreEqual("First, locate and make note of the following information. Then, enter the codes in the fields provided.", selenium.GetText("//div[@id='bd']/div[3]/p[2]"));
            selenium.AreEqual("Print these instructions", selenium.GetText("link=Print these instructions"));
            selenium.AreEqual("Power on your navigation unit and insert your map update disc.", selenium.GetText("css=td.details"));
            selenium.AreEqual("Retrieve the 10-digit Unit ID from the navigation unit's map update screen on your Kenwood navigation device.", selenium.GetText("//div[@id='bd']/div[3]/table/tbody/tr[3]/td[2]"));
            selenium.AreEqual("Retrieve the 4-digit Validation Code from the navigation unit's map update screen on your Kenwood navigation device.", selenium.GetText("//div[@id='bd']/div[3]/table/tbody/tr[4]/td[2]"));
            selenium.AreEqual("Retrieve the 8-digit Product Key that came with your map update disc.", selenium.GetText("//div[@id='bd']/div[3]/table/tbody/tr[5]/td[2]"));
            selenium.AreEqual("Unit ID", selenium.GetText("css=div.inputIndicator-text"));
            selenium.AreEqual("", selenium.GetText("id=unitId"));
            selenium.AreEqual("Validation Code", selenium.GetText("//form[@id='activateMapForm']/div[2]/div[2]/div"));
            selenium.AreEqual("", selenium.GetValue("id=validationCode"));
            selenium.AreEqual("Product Key", selenium.GetText("//form[@id='activateMapForm']/div[3]/div[2]/div"));
            selenium.AreEqual("", selenium.GetValue("id=productKey"));
            selenium.AreEqual("Activate Map", selenium.GetText("css=a.button > span"));
        }

        public void PrintInstructionsPage()
        {

            selenium.AreEqual("To Activate Your New Kenwood Map, follow the instructions below", selenium.GetText("css=h3"));
            selenium.AreEqual("Print", selenium.GetValue("id=printPage"));
            selenium.AreEqual("Power on your navigation unit and insert your map update disc.", selenium.GetText("css=li"));
            //Assert.AreEqual("Make note of the 10-digit Unit Id from the navigation unit's map update screen on your Kenwood navigation device.\n\n Unit ID: ____ ____ ____ ____ ____ ____ ____ ____ ____ ____", selenium.GetText("//li[2]"));
            selenium.IsTextPresent("Unit ID: ____ ____ ____ ____ ____ ____ ____ ____ ____ ____");
            //Assert.AreEqual("Make note of the 4-digit Validation Code from the navigation unit's map update screen on your Kenwood navigation device.\n\n Validation Code: ____ ____ ____ ____", selenium.GetText("//li[3]"));
            selenium.IsTextPresent("Validation Code: ____ ____ ____ ____");
            //Assert.AreEqual("Make note of the 8-digit Product Key located on the back of your map update packaging.\n\n Product Key: ____ ____ ____ ____ ____ ____ ____ ____", selenium.GetText("//li[4]"));
            selenium.IsTextPresent("Product Key: ____ ____ ____ ____ ____ ____ ____ ____");
            selenium.AreEqual("Enter the information on the website at the page you were just on. If you no longer have that page open, go to www.garmin.com/kenwood/map/activate.", selenium.GetText("//li[5]"));
            selenium.SelectWindow("name=printPopup");

            //close pop up window
            //seleniumdriver.Close();
        }

        public void MapSuccessfullyActivatedPage()
        {
            selenium.AreEqual("Map Successfully Activated", selenium.GetTitle());
            selenium.AreEqual("Map Successfully Activated", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("To begin using this map, enter the following unlock code in your navigation device:", selenium.GetText("css=p.description"));
            selenium.AreEqual("Unlock Code", selenium.GetText("css=strong"));

            string inputString = selenium.GetText("id=number");

            //Match match = Regex.Match(inputString, @"\w{25}", RegexOptions.IgnoreCase);



            selenium.AreEqual("Print this page", selenium.GetText("link=Print this page"));

            //selenium.Click("link=Print this page");

            //Assert.AreEqual("To have this unlock code sent to your email, enter your address and click Send.", selenium.GetText("css=p.description.textCenter"));
            selenium.IsTextPresent("To have this unlock code sent to your email, enter your address and click Send.");
            selenium.AreEqual("Email Address", selenium.GetText("css=div.inputIndicator-text"));
            selenium.AreEqual("", selenium.GetValue("id=email"));
            selenium.AreEqual("Send", selenium.GetText("css=a.button.left > span"));
        }

        public void ActivateTrafficSubscriptionPage()
        {
           

            /*
            Match match1 = Regex.Match(inputString, @"^(Premium Traffic Subscription\s-\s)", RegexOptions.IgnoreCase);

            if (match1.Success)
            {
                Assert.AreEqual("Premium Traffic Subscription - ", match1.Groups[0].ToString());
            }
             */

            //selenium.AreEqual("In order to activate your traffic subscription please enter the Traffic Receiver ID of your device. Your Traffic Receiver ID is a 10-digit number located on your device under Settings > Traffic > Subscriptions > Add.", selenium.GetText("css=p.instructions"));
            //selenium.AreEqual("Traffic Receiver ID", selenium.GetText("css=div.inputIndicator-text"));
            //selenium.AreEqual("", selenium.GetText("id=trafficReceiverId"));
            //selenium.AreEqual("Activate", selenium.GetTable("css=table.1.1"));
        }

        public void ActivateTrafficSubscriptionUnlockCodePage()
        {
            selenium.AreEqual("Traffic Subscription Unlock Code", selenium.GetTitle());
            selenium.AreEqual("Traffic Subscription Unlock Code", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("To begin using this traffic subscription, enter the following unlock code in your navigation device:", selenium.GetText("css=p.description"));
            selenium.AreEqual("1", selenium.GetText("css=td.number"));
            selenium.AreEqual("From the Main menu, touch Settings > Traffic > Subscriptions > Add > Next.", selenium.GetText("css=td.details"));
            selenium.AreEqual("2", selenium.GetText("//div[@id='unlockCode']/div/table/tbody/tr[2]/td"));
            selenium.AreEqual("Use the on-screen keyboard to enter your traffic subscription code, and touch Next.", selenium.GetText("//div[@id='unlockCode']/div/table/tbody/tr[2]/td[2]"));
            selenium.AreEqual("3", selenium.GetText("//div[@id='unlockCode']/div/table/tbody/tr[3]/td"));
            selenium.AreEqual("A message appears indicating that your traffic subscription is enabled. Touch Done.", selenium.GetText("//div[@id='unlockCode']/div/table/tbody/tr[3]/td[2]"));

            string unlockCode = selenium.GetText("id=unlockBox");

            /*
            Match match1 = Regex.Match(unlockCode, @"(.*)(\:)", RegexOptions.IgnoreCase);

            if (match1.Success)
            {
                Assert.AreEqual("Traffic Subscription Unlock Code(s):", match1.Groups[0].ToString());
            }
             */ 

            //Assert.AreEqual("Traffic Subscription Unlock Code(s):\n 5KLW3UDXQRCKCGVH9XDN4U6BX", selenium.GetText("id=unlockBox"));

            string inputString = selenium.GetText("id=number");

            /*
            Match match = Regex.Match(inputString, @"\w{25}", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                Assert.True(true);
            }
             */ 

            //Assert.AreEqual("5KLW3UDXQRCKCGVH9XDN4U6BX", selenium.GetText("id=number"));

            selenium.AreEqual("Print this page", selenium.GetText("link=Print this page"));
            //Assert.AreEqual("To have this unlock code sent to your email, enter your address and click Send.", selenium.GetText("css=p.description.textCenter"));
            selenium.IsTextPresent("To have this unlock code sent to your email, enter your address and click Send.");
            //selenium.AreEqual("To have this unlock code sent to your email, enter your address and click Send.", selenium.GetText("//div[@id='unlockCode']/div[2]/p"));
            selenium.AreEqual("Email Address", selenium.GetText("css=div.inputIndicator-mid"));
            selenium.AreEqual("", selenium.GetText("id=email"));
            selenium.AreEqual("Send", selenium.GetText("css=a.button.left > span"));
        }

        public void AddToCartTrafficVerification(bool sameInternalId)
        {
            if (sameInternalId)
            {
                selenium.AreEqual("Add to Cart: Traffic Verification", selenium.GetTitle());
                selenium.AreEqual("Add to Cart: Traffic Subscription", selenium.GetText("css=div.titleHeader-text"));
                selenium.AreEqual("To add this item to your cart, please complete the following", selenium.GetText("id=verifyTrafficInstructions"));
                selenium.AreEqual("Unit ID", selenium.GetText("css=div.inputIndicator-text"));
                selenium.AreEqual("", selenium.GetValue("id=unitId"));
                selenium.AreEqual("By clicking the Continue button below, you acknowledge that you have read and agree to the Garmin End User License Agreement.", selenium.GetText("//form[@id='verifyTrafficForm']/table/tbody/tr[4]/td"));
                selenium.AreEqual("Your Unit ID is a 10-digit number located on your device under Settings > System > About.", selenium.GetText("css=div.instructions"));
                selenium.AreEqual("Cancel", selenium.GetText("css=a.button > span"));
                selenium.AreEqual("Continue", selenium.GetText("link=Continue"));
                selenium.AreEqual("End User License Agreement", selenium.GetText("link=End User License Agreement"));
            }
            else
            {
                selenium.AreEqual("Add to Cart: Traffic Verification", selenium.GetTitle());
                selenium.AreEqual("Add to Cart: Traffic Subscription", selenium.GetText("css=div.titleHeader-text"));
                selenium.AreEqual("To add this item to your cart, please complete the following", selenium.GetText("id=verifyTrafficInstructions"));
                selenium.AreEqual("Unit ID", selenium.GetText("css=div.inputIndicator-text"));
                selenium.AreEqual("", selenium.GetText("id=unitId"));
                selenium.AreEqual("Your Unit ID is a 10-digit number located on your device under Settings > System > About.", selenium.GetText("css=div.instructions"));
                //selenium.AreEqual("", selenium.GetText("id=trafficReceiverId"));
                //selenium.AreEqual("Traffic Receiver ID", selenium.GetText("//form[@id='verifyTrafficForm']/table/tbody/tr[4]/td/div/div[2]/div"));
                //selenium.IsTextPresent("Your Traffic Receiver ID is a 10-digit number located on your device under Settings > Traffic > Subscriptions > Add.");
                selenium.AreEqual("Cancel", selenium.GetText("css=a.button > span"));
                selenium.AreEqual("Continue", selenium.GetText("link=Continue"));
            }
        }

        public void AddToCartTraffic_PopUp_AlreadyRegistered()
        {
            selenium.AreEqual("Traffic Services for Kenwood", selenium.GetTitle());
            selenium.AreEqual("Error", selenium.GetText("id=ui-dialog-title-dialog"));
            selenium.AreEqual("", selenium.GetText("css=div.left.image > img"));
            selenium.AreEqual("This device is currently registered to another user account", selenium.GetText("css=div.errorMessage"));
            selenium.AreEqual("Continue", selenium.GetText("//button[@type='button']"));
        }

        public void DeviceInformationFoundPage(bool exactlyDeviceFromXml)
        {
            for (int second = 0; second < 61 ; second++)
            {
                if (second >= 60) selenium.ErrorReport("timeout", CheckType.Warning);
                try
                {
                    if (seleniumdriver.IsTextPresent("Please select a device")) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            selenium.AreEqual("Device Found", selenium.GetTitle());
            selenium.AreEqual("Device Information Found", selenium.GetText("css=div.titleHeader-text"));

            if (!exactlyDeviceFromXml)
            {

                selenium.AreEqual("DNX6980", selenium.GetText("css=div.header"));
                selenium.AreEqual("Unit ID:", selenium.GetText("css=b"));
                selenium.AreEqual("", selenium.GetText("css=img.margin-rb10.left"));
                selenium.AreEqual("Yes, this is my device", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[2]"));
                selenium.AreEqual("Continue", selenium.GetText("css=a.button > span"));
                selenium.AreEqual("DNX7180", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[3]/div/div"));
                selenium.AreEqual("Unit ID:", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[3]/div/div[2]/b"));
                selenium.AreEqual("", selenium.GetText("//img[contains(@src,'https://static.garmincdn.com/autoOem/kenwood/models/11_DNX7180_K_BASIC_F_NAVI.jpg')]"));
                selenium.AreEqual("Yes, this is my device", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[4]"));
                selenium.AreEqual("Continue", selenium.GetText("//div[@id='modelIdentificationConfirm']/a[2]/span"));
                selenium.AreEqual("My device isn't listed here", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[5]"));
                selenium.AreEqual("Start Over", selenium.GetText("//div[@id='modelIdentificationConfirm']/a[3]/span"));
            }
            else
            {
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=div.header"), "(DNX|KNA-)(\\d{4})(.*)"));
                selenium.AreEqual("Unit ID:", selenium.GetText("css=b"));
                selenium.AreEqual("", selenium.GetText("css=img.margin-rb10.left"));
                selenium.AreEqual("Yes, this is my device", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[2]"));
                selenium.AreEqual("Continue", selenium.GetText("css=a.button > span"));
                selenium.AreEqual("My device isn't listed here", selenium.GetText("//div[@id='modelIdentificationConfirm']/div[3]"));
                selenium.AreEqual("Start Over", selenium.GetText("//div[@id='modelIdentificationConfirm']/a[2]/span"));
            }
        }

        public void DeviceSelectionPage()
        {
            selenium.AreEqual("Select a Model", selenium.GetTitle());
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.titleHeader-text"), "^Which Kenwood device do you have[\\s\\S]$"));
            selenium.AreEqual("Region:", selenium.GetText("css=span.left"));
            selenium.AreEqual("AllNorth AmericaEuropeOther", selenium.GetText("id=headUnitRegionFilter"));
            selenium.AreEqual("Series:", selenium.GetText("//div[@id='bd']/div[3]/form/span[2]"));
            selenium.AreEqual("AllDNXKNA", selenium.GetText("id=headUnitSeriesFilter"));
        }

        public void ModelIdentificationPage()
        {
            //Assert.AreEqual("Model Identification", selenium.GetTitle());
            //Assert.AreEqual("The model you selected requires identification using portable media", selenium.GetText("css=div.titleHeader-text"));
            //Assert.AreEqual("To identify your device and see available updates, follow the instructions below", selenium.GetText("css=div.description"));
            //Assert.AreEqual("", selenium.GetText("css=div.margin-rb10.left > img"));
            //Assert.AreEqual("Print these instructions", selenium.GetText("link=Print these instructions"));
            //Assert.AreEqual("Insert portable media into your navigation unit.", selenium.GetText("css=td.details"));
            //Assert.AreEqual("1", selenium.GetText("css=td.number"));
            //Assert.AreEqual("(This will initiate data export from the navigation unit onto your portable media)", selenium.GetText("css=div.smallInstr"));
            //Assert.AreEqual("2", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[3]/td"));
            //Assert.AreEqual("When the export is complete, remove your portable media", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[4]/td[2]"));
            //Assert.AreEqual("3", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[4]/td"));
            //Assert.AreEqual("Insert the portable media into your computer and click the Read Media button below", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[5]/td[2]"));
            //Assert.AreEqual("4", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[5]/td"));
            //Assert.AreEqual("Read Media", selenium.GetText("css=a.button > span"));


            selenium.AreEqual("Model Identification", selenium.GetTitle());
            selenium.AreEqual("The model you selected requires identification using portable media", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("To identify your device and see available updates, follow the instructions below", selenium.GetText("css=div.description"));
            selenium.AreEqual("", selenium.GetText("css=div.margin-rb10.left > img"));
            selenium.AreEqual("Print these instructions", selenium.GetText("link=Print these instructions"));
            selenium.AreEqual("Insert portable media into your navigation unit.", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[2]/td[2]"));
            selenium.AreEqual("1", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[2]/td"));
            selenium.AreEqual("(This will initiate data export from the navigation unit onto your portable media)", selenium.GetText("css=div.smallInstr"));
            selenium.AreEqual("2", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[3]/td"));
            selenium.AreEqual("When the export is complete, remove your portable media", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[4]/td[2]"));
            selenium.AreEqual("3", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[4]/td"));
            selenium.AreEqual("Insert the portable media into your computer and click the Read Media button below", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[5]/td[2]"));
            selenium.AreEqual("4", selenium.GetText("//div[@id='modelIdentification']/table/tbody/tr[5]/td"));
            selenium.AreEqual("Read Media", selenium.GetText("css=a.button > span"));
        }

        public void SoftwareUpdatePage()
        {
            selenium.AreEqual("Software Update", selenium.GetTitle());
            selenium.AreEqual("Software Update", selenium.GetText("css=div.titleHeader-text"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=p.header"), "(Garmin Navigation Software)"));
            //Assert.AreEqual("Kenwood Receiver & Garmin Navigation Software update for DNX7180", selenium.GetText("css=p.header"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//div[@id='bd']/div[4]/p[2]"), "(download the latest)"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//div[@id='bd']/div[4]/div/p[2]"), "(download the latest)"));
            //Assert.AreEqual("You're ready to download the latest Kenwood & Garmin software for your device.", selenium.GetText("//div[@id='bd']/div[4]/p[2]"));
            selenium.AreEqual("Get Latest Navigation Software", selenium.GetText("css=div.softwareUpdate > a.button > span"));
            selenium.AreEqual("« Back to Updates", selenium.GetText("css=a.button > span"));
        }

        public void UpdateRequieredPage()
        {
            selenium.AreEqual("Update Required", selenium.GetTitle());
            selenium.AreEqual("Update Required", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("This product is dependent on the latest software for your device", selenium.GetText("css=div.description"));
            selenium.AreEqual("1", selenium.GetText("css=td.number"));
            selenium.AreEqual("Go to the Software Updates page and update your device with the latest software by following the instructions", selenium.GetText("css=td.details"));
            selenium.AreEqual("2", selenium.GetText("//div[@id='software']/table/tbody/tr[2]/td"));
            selenium.AreEqual("Return to Scan Portable Media to restart the process\n Data export is required after software update", selenium.GetText("//div[@id='software']/table/tbody/tr[2]/td[2]"));
            selenium.AreEqual("Data export is required after software update", selenium.GetText("css=div.smallInstr"));
            selenium.AreEqual("Software Updates", selenium.GetText("link=Software Updates"));
            selenium.AreEqual("Scan Portable Media", selenium.GetText("link=Scan Portable Media"));
        }

        public void ProductUpdatesPage(bool hasTraffic)
        {
            //Assert.IsTrue(Regex.IsMatch(selenium.GetTitle(), "Product Updates for Kenwood .*"));
            //Assert.AreEqual("Product Updates for Kenwood DNX7180", selenium.GetTitle());
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.titleHeader-text"), "Product Updates for Kenwood .*"));
            //Assert.AreEqual("Product Updates for Kenwood DNX7180", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-rb10.left"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.header"), ".*"));
            //Assert.AreEqual("DNX7180", selenium.GetText("css=div.header"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.region"), "[North America|Europe|Other]"));
            //Assert.AreEqual("North America", selenium.GetText("css=div.region"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-10.left"));
            selenium.AreEqual("Latest Map", selenium.GetText("css=div.productUpdate > div.description > div.header"));
            //Assert.AreEqual("Latest map data and expanded features ensure that you will navigate with confidence", selenium.GetText("css=div.description > span"));

            if (hasTraffic)
            {
                selenium.AreEqual("", selenium.GetText("css=a.updatesLink > div.productUpdate > img.margin-10.left"));
                selenium.AreEqual("Real-Time Traffic", selenium.GetText("//div[@id='productUpdates']/a[2]/div/div/div"));
                selenium.AreEqual("", selenium.GetText("//div[@id='productUpdates']/a[2]/div/img"));
                selenium.AreEqual("Software Updates", selenium.GetText("css=div.description.padding-top-10 > div.header"));
            }
            else
            {
                selenium.AreEqual("", selenium.GetText("css=a.updatesLink > div.productUpdate > img.margin-10.left"));
                //Assert.AreEqual("Software Updates", selenium.GetText("//div[@id='productUpdates']/a[2]/div/div/div"));
                selenium.AreEqual("Software Updates", selenium.GetText("css=div.description.padding-top-10 > div.header"));
            }
        }

        public void ProductUpdatesPage_NoUpdates()
        {
            //Assert.IsTrue(Regex.IsMatch(selenium.GetTitle(), "Product Updates for Kenwood .*"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.titleHeader-text"), "Product Updates for Kenwood .*"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-rb10.left"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.header"), ".*"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.region"), "[North America|Europe|Other]"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-10.left"));
            selenium.AreEqual("Latest Map", selenium.GetText("css=div.noLink"));
            selenium.AreEqual("Real-Time Traffic", selenium.GetText("css=a.updatesLink > div.productUpdate > div.description > div.header"));
        }

        public void ValidateFirmwarePage()
        {
            selenium.SelectWindow("name=undefined");
            selenium.AreEqual("", selenium.GetText("css=img[alt=\"Kenwood\"]"));
            selenium.AreEqual("A program to improve the function of 2011 Navigation/Multimedia receiver has been released.", selenium.GetText("css=strong"));
            selenium.AreEqual("About the 2011 Navigation/Multimedia receiver firmware updater", selenium.GetText("//div[@id='main']/table/tbody/tr[3]/td/strong"));
            selenium.AreEqual("The firmware for the following products have been updated.", selenium.GetText("//div[@id='main']/table/tbody/tr[3]/td/table[4]/tbody/tr/td/strong"));
            selenium.AreEqual("Improved functions", selenium.GetText("//div[@id='main']/table/tbody/tr[3]/td/table[2]/tbody/tr/td/strong"));
            selenium.AreEqual("Be sure to read and follow the instructions in the \"2011 Navigation/Multimedia receiver Firmware Update Guide.\"", selenium.GetText("//div[@id='main']/table/tbody/tr[3]/td/table[6]/tbody/tr/td/strong"));
            selenium.AreEqual("You must agree to the following conditions before downloading this update program.", selenium.GetText("//div[@id='main']/table/tbody/tr[3]/td/table[8]/tbody/tr/td/strong"));
            selenium.AreEqual("English", selenium.GetText("link=English"));
            selenium.AreEqual("Français", selenium.GetText("link=Français"));
            selenium.AreEqual("Deutsch", selenium.GetText("link=Deutsch"));
            selenium.AreEqual("Nederlands", selenium.GetText("link=Nederlands"));
            selenium.AreEqual("Italiano", selenium.GetText("link=Italiano"));
            selenium.AreEqual("Español", selenium.GetText("link=Español"));
            selenium.AreEqual("Português", selenium.GetText("link=Português"));
            selenium.AreEqual("Pyccкий", selenium.GetText("link=Pyccкий"));
            selenium.AreEqual("Simplified Chinese\n（中文 简体字）", selenium.GetText("css=li.chi > a"));
            //Assert.IsTrue(selenium.IsTextPresent("DNX7180"));
            selenium.AreEqual("DNX7180", selenium.GetText("//div[@id='main']/table/tbody/tr[3]/td/table[4]/tbody/tr[3]/td/table/tbody/tr[2]/td"));

            selenium.Click("link=Français");
            selenium.WaitForPageToLoad("30000");
            selenium.AreEqual("Kenwood / Dispositif de mise à jour du micrologiciel", selenium.GetTitle());
        }

        public void TrafficSubscriptionPage()
        {
            selenium.AreEqual("Traffic Subscriptions", selenium.GetTitle());
            selenium.AreEqual("Traffic Subscriptions for Your Device", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-rb10.left"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.header"), ".*"));
            //Assert.AreEqual("DNX7180", selenium.GetText("css=div.header"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.region"), "[North America|Europe|Other]"));
            //Assert.AreEqual("North America", selenium.GetText("css=div.region"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.text"), "Premium Traffic Subscription .*"));
            //Assert.AreEqual("Premium Traffic Subscription by Navteq – North America", selenium.GetText("css=div.text"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-10.left"));
        }

        public void TrafficServicesForkenwoodPage()
        {
            selenium.AreEqual("Traffic Services for Kenwood", selenium.GetTitle());
            selenium.AreEqual("Traffic Services for Kenwood", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("« Back to Updates", selenium.GetText("css=a.button > span"));
            selenium.AreEqual("Download", selenium.GetText("css=div.format.left"));
            selenium.AreEqual("Add to Cart", selenium.GetText("css=a.button.left > span"));
            //Assert.AreEqual("$49.99", selenium.GetText("css=div.price"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.price"), "\\$\\d{2,6}.\\d{2}"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=div.price"), ".*"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.header"), "Premium Traffic Subscription .*"));
            //Assert.AreEqual("Premium Traffic Subscription by Navteq – North America", selenium.GetText("css=div.header"));

            selenium.AreEqual("", selenium.GetText("css=img.left.margin-rb10"));

            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=h3"), "Receive Real-time Traffic for .*"));
            //Assert.AreEqual("Receive Real-time Traffic for North America", selenium.GetText("css=h3"));

            //Assert.AreEqual("Avoid traffic tie-ups in North America with a lifetime traffic subscription. Garmin, in partnership with NAVTEQ, delivers real-time traffic news and updates for all major routes directly to your compatible Garmin device.", selenium.GetText("css=p"));

            selenium.AreEqual("Route Around Tie-ups. Avoid Delays", selenium.GetText("//div[@id='bd']/div[4]/div[2]/h3[2]"));
            //Assert.AreEqual("With a traffic subscription for North America and a traffic receiver, you’ll get the latest information on construction, accidents, lane closings and other obstructions that lie ahead on your route. Using your compatible Garmin, you can conveniently route around traffic to avoid delays — saving you drive time, gas and money!", selenium.GetText("//div[@id='bd']/div[4]/div[2]/p[2]"));
            selenium.AreEqual("Requirements", selenium.GetText("css=div.product > h3"));
            selenium.AreEqual("Terms and Conditions", selenium.GetText("css=strong"));
            selenium.AreEqual("Lifetime traffic extends for the useful life of your Garmin traffic receiver (as long as you own a compatible Garmin GPS) or as long as Garmin receives traffic data from its traffic supplier, whichever is shorter. Traffic content not available for all areas.", selenium.GetText("//div[@id='bd']/div[4]/p[2]"));
            selenium.AreEqual("About Coverage", selenium.GetText("//div[@id='bd']/div[4]/h3[2]"));

            //Assert.AreEqual("This lifetime subscription by NAVTEQ delivers real-time traffic news and updates for 98 metropolitan markets in North America, including Canada, directly to your compatible Garmin device.", selenium.GetText("//div[@id='bd']/div[4]/p[3]"));
            //Assert.AreEqual("View NAVTEQ's coverage map.", selenium.GetText("//div[@id='bd']/div[4]/p[4]"));
            //Assert.AreEqual("", selenium.GetText("css=img[alt=\"Navteq Traffic\"]"));
        }

        public void TrafficReceiverOnlyPage()
        {
            selenium.AreEqual("Add to Cart: Traffic Verification", selenium.GetTitle());
            //selenium.AreEqual("", selenium.GetText("css=div.titleHeader-left"));
            selenium.AreEqual("To add this item to your cart, please complete the following", selenium.GetText("id=verifyTrafficInstructions"));
            selenium.AreEqual("Traffic Receiver ID", selenium.GetText("css=div.inputIndicator-text"));
            //selenium.AreEqual("", selenium.GetText("id=trafficReceiverId"));
            //selenium.AreEqual("Your Traffic Receiver ID is a 10-digit number located on your device under Settings > Traffic > Subscriptions > Add.", selenium.GetText("css=div.instructions"));
            selenium.AreEqual("By clicking the Continue button below, you acknowledge that you have read and agree to the Garmin End User License Agreement.", selenium.GetText("//form[@id='verifyTrafficForm']/table/tbody/tr[4]/td"));
            selenium.AreEqual("End User License Agreement", selenium.GetText("link=End User License Agreement"));
            selenium.AreEqual("Cancel", selenium.GetText("css=a.button > span"));
            selenium.AreEqual("Continue", selenium.GetText("link=Continue"));
        }

        //public void LatestMapForKenwoodPage(WebDriverBackedSelenium selenium)
        //{
        //    Assert.IsTrue(Regex.IsMatch(selenium.GetTitle(), "City Navigator"));
        //    //Assert.AreEqual("Download: City Navigator® North America NT 2012 Map Update for Kenwood", selenium.GetTitle());
        //    //Assert.AreEqual("Latest Map for Kenwood DNX7180", selenium.GetText("css=div.titleHeader-text"));
        //    Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.titleHeader-text"), "(DNX|KNA-)(\\d{4})(.*)"));
        //    Assert.AreEqual("« Back to Updates", selenium.GetText("css=a.button > span"));
        //    Assert.AreEqual("Download", selenium.GetText("css=div.productType"));
        //    Assert.AreEqual("Add to Cart", selenium.GetText("css=a.button.left > span"));
        //    //Assert.AreEqual("$69.99", selenium.GetText("css=div.price"));
        //    //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.price"), "\\$\\d{2,6}.\\d{2}"));
        //    Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.price"), ".*"));
        //    Assert.AreEqual("Download: City Navigator® North America NT 2012 Map Update for Kenwood", selenium.GetText("css=div.header"));
        //    Assert.AreEqual("", selenium.GetText("css=img.margin-rb10.left"));
        //    Assert.AreEqual("Navigate the streets of North America with confidence. This download updates detailed road maps and points of interest on your compatible Kenwood device, so you can navigate with exact, turn-by-turn directions to any address or intersection. Route to restaurants, gas stations, lodging, attractions and more.", selenium.GetText("css=p"));
        //    Assert.AreEqual("Requirements", selenium.GetText("css=h3"));
        //    Assert.AreEqual("Download Requirements", selenium.GetText("id=reqDownload"));
        //    Assert.AreEqual("File Information", selenium.GetText("css=strong"));
        //    Assert.AreEqual("Please note, if you download the map update to an SD card, the card must remain in the device to use the map.", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[2]"));
        //    Assert.AreEqual("Use With One Device Only", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[3]/strong"));
        //    Assert.AreEqual("This product may be unlocked and used on 1 compatible device. If you want to use this same map on subsequent units, you must purchase a new map for each device.", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[4]"));
        //    Assert.AreEqual("Data downloaded is associated with the device you select during the download process. Please purchase additional quantities for additional devices.", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[5]"));
        //    Assert.AreEqual("Download Times", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[6]/strong"));
        //    Assert.AreEqual("Not for use with dial-up Internet access or satellite Internet providers. Actual download speeds may vary.", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[7]"));
        //    Assert.AreEqual("Expiration Date", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[8]/strong"));
        //    Assert.AreEqual("You have 1 year from your date of purchase to download this file from your account.", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[9]"));
        //    Assert.AreEqual("Minimum Requirements", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[10]/strong"));
        //    Assert.AreEqual("The download process requires you to install the free Garmin Communicator Plugin on your computer so we can communicate with your device.", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/p[11]"));
        //    Assert.AreEqual("PC", selenium.GetText("css=div > strong"));
        //    Assert.AreEqual("Mac®", selenium.GetText("//div[@id='bd']/div[4]/div[3]/div/strong[2]"));
        //    Assert.AreEqual("Features", selenium.GetText("css=div.features > h3"));
        //    Assert.AreEqual("Includes more than 6.6 million mi (10.6 million km) of roads, including motorways, national and regional thoroughfares and local roads, throughout North America.", selenium.GetText("css=div.features > ul > li"));
        //    Assert.AreEqual("Displays more than 8.5 million points of interest throughout the country, including restaurants, lodging, border crossings, attractions, petrol stations, hospitals and more.", selenium.GetText("//div[@id='bd']/div[4]/div[4]/ul/li[2]"));
        //    Assert.AreEqual("Gives turn-by-turn directions on your compatible Kenwood device.", selenium.GetText("//div[@id='bd']/div[4]/div[4]/ul/li[3]"));
        //    Assert.AreEqual("Speaks street names (example: \"Turn right on Main Street\")", selenium.GetText("//div[@id='bd']/div[4]/div[4]/ul/li[4]"));
        //    Assert.AreEqual("Includes navigational features, such as turn restrictions, roundabout guidance, speed categories and more.", selenium.GetText("//div[@id='bd']/div[4]/div[4]/ul/li[5]"));
        //    Assert.AreEqual("Contains traffic data for compatible devices that use traffic receivers.", selenium.GetText("//div[@id='bd']/div[4]/div[4]/ul/li[6]"));
        //    Assert.AreEqual("About Coverage", selenium.GetText("css=div.text > h3"));
        //    Assert.AreEqual("Features fully routable, detailed maps of the U.S., Canada, Mexico, Puerto Rico, U.S. Virgin Islands, Cayman Islands, the Bahamas, French Guiana, Guadeloupe, Martinique, Saint Barthélemy and Jamaica.", selenium.GetText("css=div.text > p"));
        //    Assert.AreEqual("", selenium.GetText("css=div.image > img"));
        //    Assert.AreEqual("Part Number: 010-D1207-00", selenium.GetText("css=div.partNumber"));
        //    Assert.AreEqual("Download", selenium.GetText("//div[@id='bd']/div[4]/div[7]/div"));
        //    Assert.AreEqual("Add to Cart", selenium.GetText("//div[@id='bd']/div[4]/div[7]/a/span"));
        //    //Assert.AreEqual("$69.99", selenium.GetText("//div[@id='bd']/div[4]/div[7]/div[2]"));
        //    //Assert.IsTrue(Regex.IsMatch(selenium.GetText("//div[@id='bd']/div[4]/div[7]/div[2]"), "\\$\\d{2,6}.\\d{2}"));
        //    Assert.IsTrue(Regex.IsMatch(selenium.GetText("//div[@id='bd']/div[4]/div[7]/div[2]"), ".*"));
        //}

        public void LatestMapForKenwoodPage(bool availableToBuy)
        {

            selenium.IsTrue(Regex.IsMatch(selenium.GetTitle(), "City Navigator"));
            //Assert.AreEqual("SD data card, City Navigator NT, North America 2011-Kenwood", selenium.GetTitle());
            selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=div.titleHeader-text"), "Latest Map for Kenwood"));
            //Assert.AreEqual("Latest Map for Kenwood KNA-G610", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("« Back to Updates", selenium.GetText("css=a.button > span"));
            //Assert.AreEqual("SD data card, City Navigator NT, North America 2011-Kenwood", selenium.GetText("css=div.header"));

            if (availableToBuy)
            {
                selenium.AreEqual("Add to Cart", selenium.GetText("css=a.button.left > span"));
            }
            else
            {
                selenium.AreEqual("Not Available Online", selenium.GetText("css=div.notAvailable"));
            }

            selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=div.header"), "City Navigator"));
            selenium.AreEqual("Features", selenium.GetText("css=div.features > h3"));
            selenium.AreEqual("About Coverage", selenium.GetText("css=div.text > h3"));
            selenium.AreEqual("", selenium.GetText("css=div.image > img"));
            //Assert.AreEqual("Part Number: 010-10679-13", selenium.GetText("css=div.partNumber"));
            //Assert.IsTrue(Regex.IsMatch(selenium.GetText("css=div.partNumber"), "Part Number: \\d+-\\d+-\\d+"));
            selenium.IsTrue(selenium.IsElementPresent("css=div.partNumber"));
        }

        public void ShoppingCartWithTrafficSubscriptionToBuy(bool oneTrafficSubscription)
        {
            selenium.AreEqual("Shopping Cart", selenium.GetTitle());
            selenium.AreEqual("Shopping Cart", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("", selenium.GetText("css=div.tableHeader-left"));
            selenium.AreEqual("Unit Price", selenium.GetText("css=#price-hd > div.text"));
            selenium.AreEqual("Qty", selenium.GetText("css=#quantity-hd > div.text"));
            selenium.AreEqual("Total", selenium.GetText("css=#total-hd > div.text"));
            selenium.AreEqual("", selenium.GetText("css=img.margin-r20"));

            if (oneTrafficSubscription)
            {
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=span.name"), "Premium Traffic Subscription .*"));
                //Assert.AreEqual("Premium Traffic Subscription by Navteq – North America", selenium.GetText("css=span.name"));
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("id=price"), ".*"));
                //Assert.AreEqual("$49.99", selenium.GetText("id=price"));
                //Assert.AreEqual("$49.99", selenium.GetText("id=total"));
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("id=total"), ".*"));
                selenium.AreEqual("Subtotal", selenium.GetText("css=div.text.right"));
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=strong"), ".*"));
                //Assert.AreEqual("$49.99", selenium.GetText("css=strong"));
                selenium.AreEqual("remove", selenium.GetText("link=remove"));
                selenium.AreEqual("Update", selenium.GetText("css=a.button > span"));
                selenium.AreEqual("Continue Shopping", selenium.GetText("//form[@id='shoppingCartForm']/div[2]/div[4]/a/span"));
                selenium.AreEqual("Checkout", selenium.GetText("//form[@id='shoppingCartForm']/div[2]/div[4]/a[2]/span"));
            }
            else if (!oneTrafficSubscription)
            {
                selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=span.name"), "Premium Traffic Subscription .*"));
                //Assert.AreEqual("Premium Traffic Subscription by Navteq – North America", selenium.GetText("//div[2]/div/span"));
                selenium.AreEqual("remove", selenium.GetText("xpath=(//a[contains(text(),'remove')])[2]"));
                //Assert.AreEqual("$49.99", selenium.GetText("xpath=(//div[@id='price'])[2]"));
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("xpath=(//div[@id='price'])[2]"), ".*"));
                //Assert.AreEqual("$49.99", selenium.GetText("xpath=(//div[@id='total'])[2]"));
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("xpath=(//div[@id='price'])[2]"), ".*"));
                //Assert.AreEqual("$99.98", selenium.GetText("css=strong"));
                //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=strong"), ".*"));
                selenium.AreEqual("Subtotal", selenium.GetText("css=div.text.right"));
                selenium.AreEqual("Update", selenium.GetText("css=a.button > span"));
                selenium.AreEqual("Checkout", selenium.GetText("//form[@id='shoppingCartForm']/div[3]/div[4]/a[2]/span"));
                selenium.AreEqual("Continue Shopping", selenium.GetText("//form[@id='shoppingCartForm']/div[3]/div[4]/a/span"));
            }
        }

        public void ShoppingCartWithLatestMapToBuy()
        {
            selenium.AreEqual("Shopping Cart", selenium.GetTitle());
            selenium.AreEqual("Shopping Cart", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("Item Description", selenium.GetText("css=div.text"));
            selenium.AreEqual("Unit Price", selenium.GetText("css=#price-hd > div.text"));
            selenium.AreEqual("Qty", selenium.GetText("css=#quantity-hd > div.text"));
            selenium.AreEqual("Total", selenium.GetText("css=#total-hd > div.text"));
            selenium.AreEqual("Download: City Navigator® North America NT 2012 Map Update for Kenwood", selenium.GetText("css=span.name"));
            selenium.AreEqual("remove", selenium.GetText("link=remove"));
            //Assert.AreEqual("$69.99", selenium.GetText("id=price"));
            selenium.IsTrue(Regex.IsMatch(selenium.GetText("id=price"), ".*"));
            //Assert.AreEqual("$69.99", selenium.GetText("id=total"));
            selenium.IsTrue(Regex.IsMatch(selenium.GetText("id=total"), ".*"));
            selenium.AreEqual("Subtotal", selenium.GetText("css=div.text.right"));
            //Assert.AreEqual("$69.99", selenium.GetText("css=strong"));
            selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=strong"), ".*"));
            selenium.IsTrue(selenium.IsElementPresent("css=a.button > span"));
            selenium.AreEqual("Checkout", selenium.GetText("//form[@id='shoppingCartForm']/div[2]/div[4]/a[2]/span"));
            selenium.AreEqual("Continue Shopping", selenium.GetText("//form[@id='shoppingCartForm']/div[2]/div[4]/a/span"));
        }

        public void CheckOutPage()
        {
            selenium.AreEqual("Checkout", selenium.GetTitle());
            selenium.AreEqual("Checkout", selenium.GetText("css=div.titleHeader-text"));
            selenium.IsTrue(selenium.IsTextPresent("Please fill out the form below to complete your transaction. Do not click your browser's Refresh or Back button because this transaction may be interrupted or terminated."));

        }

        public void DeliveryOptionsSection(string browser)
        {
            selenium.AreEqual("Edit", selenium.GetText("link=Edit"));
            selenium.AreEqual("Shipping Address", selenium.GetText("css=h2"));
            selenium.AreEqual("Delivery Options", selenium.GetText("css=fieldset > div.formHead > h2"));
            selenium.AreEqual("Billing Address", selenium.GetText("css=#billing-address > fieldset > div.formHead > h2"));
            selenium.AreEqual("Payment Information", selenium.GetText("css=#payment-information > fieldset > div.formHead > h2"));
            selenium.AreEqual("Place Secure Order", selenium.GetText("id=submitOrder"));

            // comment: Check Delivery Options
            selenium.AreEqual("Delivery Options", selenium.GetText("css=fieldset > div.formHead > h2"));
            selenium.AreEqual("Note: Order may take 1-2 business days to process.", selenium.GetText("css=p"));
            selenium.AreEqual("Ground Shipping (2-5 business days) - $ 8.00 USD", selenium.GetText("css=label"));
            selenium.AreEqual("2nd Business Day (2-3 business days) - $ 18.00 USD", selenium.GetText("//div[@id='delivery-options']/fieldset/div[2]/label[2]"));
            selenium.AreEqual("Next Business Day (1 business day) - $ 28.00 USD", selenium.GetText("//div[@id='delivery-options']/fieldset/div[2]/label[3]"));

            if (browser == "FF")
            {
                selenium.Click("//input[@id='deliveryOptionsRB' and @value='com.elasticpath.commons.datatransfer.ShippingFixedPriceDTO^5_28.00_Next Business Day (1 business day)']");
                selenium.WaitForPageToLoad("30000");
            }
            else
            {
                selenium.Click("//div[@id='delivery-options']/fieldset/div[2]/label[3]");
                Thread.Sleep(6000);
            }

            selenium.AreEqual("on", selenium.GetValue("//input[@id='deliveryOptionsRB' and @value='com.elasticpath.commons.datatransfer.ShippingFixedPriceDTO^5_28.00_Next Business Day (1 business day)']"));
            selenium.AreEqual("The shippable products in your order are expected to be delivered in 2 - 4 business days.", selenium.GetText("css=#estimated-delivery-msg > p"));
            selenium.AreEqual("2nd Business Day (2-3 business days) - $ 18.00 USD", selenium.GetText("//div[@id='delivery-options']/fieldset/div[2]/label[2]"));

            if (browser == "FF")
            {
                selenium.Click("//input[@id='deliveryOptionsRB' and @value='com.elasticpath.commons.datatransfer.ShippingFixedPriceDTO^4_18.00_2nd Business Day (2-3 business days)']");
                selenium.WaitForPageToLoad("30000");
            }
            else
            {
                selenium.Click("//div[@id='delivery-options']/fieldset/div[2]/label[2]");
                Thread.Sleep(6000);
            }

            selenium.AreEqual("on", selenium.GetValue("//input[@id='deliveryOptionsRB' and @value='com.elasticpath.commons.datatransfer.ShippingFixedPriceDTO^4_18.00_2nd Business Day (2-3 business days)']"));
            selenium.AreEqual("The shippable products in your order are expected to be delivered in 3 - 6 business days.", selenium.GetText("css=#estimated-delivery-msg > p"));
            selenium.AreEqual("Ground Shipping (2-5 business days) - $ 8.00 USD", selenium.GetText("css=label"));

            if (browser == "FF")
            {
                selenium.Click("id=deliveryOptionsRB");
                selenium.WaitForPageToLoad("30000");
            }
            else
            {
                selenium.Click("css=label");
                Thread.Sleep(6000);
            }

            selenium.AreEqual("on", selenium.GetValue("id=deliveryOptionsRB"));
            selenium.AreEqual("The shippable products in your order are expected to be delivered in 3 - 8 business days.", selenium.GetText("css=#estimated-delivery-msg > p"));


        }

        public void BillingAddressSection()
        {
            // comment: Check the Billing Address section
            selenium.AreEqual("Billing Address", selenium.GetText("css=#billing-address > fieldset > div.formHead > h2"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=span.required-field-msg"), "^[\\s\\S]* Required Field$"));
            // comment: Check if the check box of the Billing Address is not checked
            selenium.AreEqual("My Billing Address Is the Same as My Shipping Address", selenium.GetText("css=#sameAsShipping-same-address > label"));
            // comment: CHECK here if the checkbox is checked

            //get if a checkbox is checked or not
            string checkedOrNot = selenium.GetValue("id=sameAsShipping-sameAddress");

            if (checkedOrNot == "off")
            {
                selenium.Click("id=sameAsShipping-sameAddress");
            }

            //Boolean check = selenium.IsEditable("id=billingAddressfirstName");
            //Assert.IsFalse(check);
        }

        public void PaymentInformationSection()
        {
            // comment: Check the Payment Information section
            selenium.AreEqual("Payment Information", selenium.GetText("css=#payment-information > fieldset > div.formHead > h2"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=#payment-information > fieldset > div.formHead > span.required-field-msg"), "^[\\s\\S]*Required Field$"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=#card-type > div.formLabel > label > abbr.req"), "^[\\s\\S]*$"));
            selenium.AreEqual("Visa Master Card American Express Discover", selenium.GetText("name=cardType"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=#cardholder-name > div.formLabel > label"), "^Cardholder's Name[\\s\\S]*$"));
            selenium.AreEqual("", selenium.GetText("id=cardHolderName"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=#card-number > div.formLabel > label > abbr.req"), "^[\\s\\S]*$"));
            selenium.AreEqual("", selenium.GetText("id=cardNumber"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=#card-security-code > div.formLabel > label > abbr.req"), "^[\\s\\S]*$"));
            selenium.AreEqual("", selenium.GetText("id=cardSecurityCode"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("link=What is this?"), "^What is this[\\s\\S]$"));
            //selenium.IsTrue(Regex.IsMatch(selenium.GetText("css=#expiration-date > div.formLabel > label > abbr.req"), "^[\\s\\S]*$"));
            selenium.AreEqual("01 02 03 04 05 06 07 08 09 10 11 12", selenium.GetText("id=expMonth"));
        }

        public void OrderSummary(bool noOrders)
        {
            selenium.AreEqual("My Orders", selenium.GetTitle());
            selenium.AreEqual("My Orders", selenium.GetText("css=div.titleHeader-text"));
            selenium.AreEqual("« Back", selenium.GetText("css=a.button > span"));
            selenium.AreEqual("Order #", selenium.GetText("css=div.text"));
            selenium.AreEqual("Order Date", selenium.GetText("css=#orderDate-hd > div.text"));
            selenium.AreEqual("Total", selenium.GetText("css=#total-hd > div.text"));
            selenium.AreEqual("Status", selenium.GetText("css=#status-hd > div.text"));
            selenium.AreEqual("Tracking Number", selenium.GetText("css=#trackingNumber-hd > div.text"));

            if (!noOrders)
            {
                selenium.IsTrue(selenium.IsElementPresent("id=orderNumber"));
                selenium.IsTrue(selenium.IsElementPresent("id=orderDate"));
                selenium.IsTrue(selenium.IsElementPresent("id=total"));
                selenium.IsTrue(selenium.IsElementPresent("id=status"));
                selenium.IsTrue(selenium.IsElementPresent("id=trackingNumber"));
                selenium.AreEqual("Details", selenium.GetText("css=#view > a.button > span"));
            }
            else
            {
                selenium.AreEqual("Our records show you have no orders", selenium.GetText("css=div.noHistory"));
            }
        }

        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        private void setLanguage()
        {
            
            switch (var)
            {
                case "en_US":
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=United States - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_US\"]");
                    //Thread.Sleep(2000);

                    seleniumdriver.SetSpeed("550");
                    break;
                case "en_AU":
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=Australia - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_AU\"]");
                    //Thread.Sleep(2000);

                    seleniumdriver.SetSpeed("550");
                    break;

                case "en_CA":
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=Canada - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_CA\"]");
                    //Thread.Sleep(2000);

                    seleniumdriver.SetSpeed("550");
                    break;

                case "en_IE":
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=Ireland - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_IE\"]");
                    //Thread.Sleep(2000);
                                        
                    seleniumdriver.SetSpeed("550");
                    break;

                case "en_SG":
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=Singapore - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_SG\"]");
                    //Thread.Sleep(2000);
                                       
                    seleniumdriver.SetSpeed("550");
                    break;

                case "en_GB":
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=United Kingdom - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_GB\"]");
                    //Thread.Sleep(2000);

                    
                    seleniumdriver.SetSpeed("550");
                    break;

                default:
                    seleniumdriver.Open("/kenwood/");
                    selenium.AreEqual("Garmin Product Updates for Kenwood", selenium.GetTitle());

                    seleniumdriver.SetSpeed("4000");

                    selenium.Click("id=languages");
                    selenium.Select("id=languages", "label=United States - English");
                    Thread.Sleep(2000);
                    selenium.Click("css=option[value=\"en_US\"]");

                    //selenium.Select("id=languages", "label=United Kingdom - English");
                    //Thread.Sleep(2000);
                    //selenium.Click("css=option[value=\"en_GB\"]");
                                        
                    seleniumdriver.SetSpeed("550");
                    break;
            }
        }

        private void check_CartFull_and_LogOutUser()
        {
            try
            {
                // comment: Check if the user is still lgged in
                if (selenium.IsTextPresent("Sign Out") == true)
                {
                    string inputString = selenium.GetText("css=a.margin-l5");
                    Match match = Regex.Match(inputString, @"Cart\s\((\d)\)", RegexOptions.IgnoreCase);

                    // comment: Check if the sing in user has products in the cart
                    if (match.Success)
                    {
                        int key = Convert.ToInt32(match.Groups[1].Value);

                        if (key != 0)
                        {
                            // comment: got to Shopping Cart
                            selenium.Click("css=a.margin-l5");

                            selenium.WaitForPageToLoad("30000");

                            selenium.AreEqual("Shopping Cart", selenium.GetTitle());

                            //bool foundRemoveLink = true;

                            while (true)
                            {
                                //bool remove = selenium.IsTextPresent("remove");
                                if (selenium.IsTextPresent("remove") == true)
                                {
                                    // comment: Click the remove link from the shopping cart(if it is only one item)
                                    selenium.Click("link=remove");
                                    Thread.Sleep(2000);
                                    if (selenium.IsTextPresent("Your Shopping Cart is currently empty") == true)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            selenium.IsTrue(selenium.IsTextPresent("Cart (0)"));
                        }
                    }

                    // comment: Logout the user
                    Logout();



                    selenium.IsTrue(selenium.IsTextPresent("Sign In"));


                }

                else
                {
                    string inputString = selenium.GetText("css=a.margin-l5");
                    Match match = Regex.Match(inputString, @"Cart\s\((\d)\)", RegexOptions.IgnoreCase);

                    // comment: Check if the sing in user has products in the cart
                    if (match.Success)
                    {
                        int key = Convert.ToInt32(match.Groups[1].Value);

                        if (key != 0)
                        {
                            // comment: got to Shopping Cart
                            selenium.Click("css=a.margin-l5");

                            selenium.WaitForPageToLoad("30000");

                            Assert.AreEqual("Shopping Cart", selenium.GetTitle());

                            //bool foundRemoveLink = true;

                            while (true)
                            {
                                //bool remove = selenium.IsTextPresent("remove");
                                if (selenium.IsTextPresent("remove") == true)
                                {
                                    // comment: Click the remove link from the shopping cart(if it is only one item)
                                    selenium.Click("link=remove");
                                    Thread.Sleep(2000);
                                    if (selenium.IsTextPresent("Your Shopping Cart is currently empty") == true)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            Assert.IsTrue(selenium.IsTextPresent("Cart (0)"));
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }


    }

}
