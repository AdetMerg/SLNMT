using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SLNTMT
{

    class CheckoutData
    {
        //predefined info for checkout
        String FirstNameStr = "Alexander";
        String LastNameStr = "Bayer";
        String StreetAddress = "Longroad str.";
        String AddressLine2 = "";
        String CityNameStr = "Stafford";
        String CountryName = "United States";
        String StateProvinceStr = "Connecticut";
        String PostZipStr = "15532";
        String PhoneStr = "176299231";
        String EmailStr = "tddest@yger.net";

        public string FirstNameStr1 { get => FirstNameStr; set => FirstNameStr = value; }
        public string LastNameStr1 { get => LastNameStr; set => LastNameStr = value; }
        public string StreetAddress1 { get => StreetAddress; set => StreetAddress = value; }
        public string AddressLine21 { get => AddressLine2; set => AddressLine2 = value; }
        public string CityNameStr1 { get => CityNameStr; set => CityNameStr = value; }
        public string CountryName1 { get => CountryName; set => CountryName = value; }
        public string StateProvinceStr1 { get => StateProvinceStr; set => StateProvinceStr = value; }
        public string PostZipStr1 { get => PostZipStr; set => PostZipStr = value; }
        public string PhoneStr1 { get => PhoneStr; set => PhoneStr = value; }
        public string EmailStr1 { get => EmailStr; set => EmailStr = value; }
    }

    class WebActionClass
    {

        CheckoutData dataForCheckout;

        String baseShopUrl = "https://www.supremesclothingonline.com/";
        String sampleElement = "https://www.supremesclothingonline.com/supreme-20fw-icy-arc-hooded-sweatshirt-3-colors-p-6244.html?zenid=sbqs1fhf3bn693qoslbqkk8nu5";

        IWebDriver currentDriver;

        Boolean SetUpFirefoxWebDriver()
        {
            currentDriver = new FirefoxDriver("/home/cpyrg/Documents/geckodriver");
            if (currentDriver != null)
            {
                currentDriver.Manage().Cookies.DeleteAllCookies();
                return true;
            }
            else
            {
                return false;
            }
        }

        Boolean FindAndClickCheckoutButton()
        {
            IWebElement checkoutButtonElement = currentDriver.FindElement(By.Id("CHECKOUT"));
            if (checkoutButtonElement == null)
            {
                return false;
            }
            else
            {
                //trying to hit the button
                checkoutButtonElement.Submit();
                return true;
            }
        }


        Boolean NavigateToBaseShop()
        {
            currentDriver.Navigate().GoToUrl(baseShopUrl);
            return true;
        }

        Boolean NavigateToElement(String elementUrl)
        {
            currentDriver.Navigate().GoToUrl(elementUrl);
            return true;
        }

        Boolean FillTheForm()
        {
            //clicking the privacy button
            String privacyCheckButtonCSS = "#privacy";
            IWebElement privacyCheckButtonElement =
                currentDriver.FindElement(By.CssSelector(privacyCheckButtonCSS));
            privacyCheckButtonElement.Click();

            //Clicking and typing the name
            String firstNameFieldCSS = "#firstname";
            IWebElement firstNameFieldElement =
                currentDriver.FindElement(By.CssSelector(firstNameFieldCSS));
            firstNameFieldElement.Click();
            firstNameFieldElement.SendKeys("Alexander");

            String lastNameFieldCSS = "#lastname";
            IWebElement lastNameFieldElement =
                currentDriver.FindElement(By.CssSelector(lastNameFieldCSS));
            lastNameFieldElement.Click();
            lastNameFieldElement.SendKeys(dataForCheckout.LastNameStr1);

            String streetFieldCSS = "#street-address";
            IWebElement streetFieldElement =
                currentDriver.FindElement(By.CssSelector(streetFieldCSS));
            streetFieldElement.Click();
            streetFieldElement.SendKeys(dataForCheckout.StreetAddress1);

            String billingAddressFieldCSS = ".fec-billing-address > .fec-field:nth-child(7)";
            IWebElement billingAddressFieldElement =
                currentDriver.FindElement(By.CssSelector(billingAddressFieldCSS));
            billingAddressFieldElement.Click();

            String suburbFieldCSS = "#suburb";
            IWebElement suburbFieldElement =
                currentDriver.FindElement(By.CssSelector(suburbFieldCSS));
            suburbFieldElement.Click();

            String cityFieldCSS = "#city";
            IWebElement cityFieldElement =
                currentDriver.FindElement(By.CssSelector(cityFieldCSS));
            cityFieldElement.Click();
            cityFieldElement.SendKeys(dataForCheckout.CityNameStr1);

            String countryFieldCSS = "#country";
            IWebElement countryFieldElement =
                currentDriver.FindElement(By.CssSelector(countryFieldCSS));
            countryFieldElement.Click();

            String countryNameFieldCSS = "#country > option:nth-child(2)";
            IWebElement countryNameFieldElement =
                currentDriver.FindElement(By.CssSelector(countryNameFieldCSS));
            countryNameFieldElement.Click();

            String stateZoneFieldCSS = "#stateZone";
            IWebElement stateZoneFieldElement =
                currentDriver.FindElement(By.CssSelector(stateZoneFieldCSS));
            stateZoneFieldElement.Click();

            String stateZoneNameFieldCSS = "#stateZone > option:nth-child(15)";
            IWebElement stateZoneNameFieldElement =
                currentDriver.FindElement(By.CssSelector(stateZoneNameFieldCSS));
            stateZoneNameFieldElement.Click();

            String postCodeFieldCSS = "#postcode";
            IWebElement postCodeFieldElement =
                currentDriver.FindElement(By.CssSelector(postCodeFieldCSS));
            postCodeFieldElement.Click();
            postCodeFieldElement.SendKeys(dataForCheckout.PostZipStr1);

            String emailFieldCSS = "#email-address";
            IWebElement emailFieldElement =
                currentDriver.FindElement(By.CssSelector(emailFieldCSS));
            emailFieldElement.Click();
            emailFieldElement.SendKeys(dataForCheckout.EmailStr1);

            String phoneFieldCSS = "#telephone";
            IWebElement phoneFieldElement =
                currentDriver.FindElement(By.CssSelector(phoneFieldCSS));
            phoneFieldElement.Click();
            phoneFieldElement.SendKeys(dataForCheckout.PhoneStr1);

            return true;
        }

        public void PerformAction()
        {
            if (SetUpFirefoxWebDriver() == false)
            {
                return;
            }

            dataForCheckout = new CheckoutData();

            NavigateToElement(sampleElement);

            String addToCartButtonCSS = ".buybtn";
            //adding to the cart
            Console.WriteLine("Adding to cart");
            IWebElement checkoutButtonElement =
                currentDriver.FindElement(By.CssSelector(addToCartButtonCSS));

            checkoutButtonElement.Submit();

            //checkout
            Console.WriteLine("Checkout");
            String checkoutFromCartButtonCSS = ".forward img";

            IWebElement checkoutFromCartButtonElement =
                currentDriver.FindElement(By.CssSelector(checkoutFromCartButtonCSS));
            checkoutFromCartButtonElement.Click();

            //guest checkout
            String guestCheckoutButtonCss = ".buttonRow img";
            IWebElement guestCheckoutButtonElement =
                currentDriver.FindElement(By.CssSelector(guestCheckoutButtonCss));
            guestCheckoutButtonElement.Click();

            //Filling the form
            Console.WriteLine("Filling the form");
            FillTheForm();

            //continueCheckoutButton
            Console.WriteLine("Continuing");
            String continueCheckoutButtonCss = "#checkoutButton > input";
            IWebElement continueCheckoutButtonElement =
                currentDriver.FindElement(By.CssSelector(continueCheckoutButtonCss));
            continueCheckoutButtonElement.Click();

            //clicking the free shipping button
            String freeShippingButtonCss = "#ship-freeoptions-freeoptions";
            IWebElement freeShippingButtonElement =
                currentDriver.FindElement(By.CssSelector(freeShippingButtonCss));
            freeShippingButtonElement.Click();

            //clicking the cont
            continueCheckoutButtonCss = ".forward > input";
            continueCheckoutButtonElement =
                currentDriver.FindElement(By.CssSelector(continueCheckoutButtonCss));
            continueCheckoutButtonElement.Click();
        }

        public WebActionClass()
        {

        }

    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Selenium driver test");

            WebActionClass actClass = new WebActionClass();

            actClass.PerformAction();

        }
    }
}
