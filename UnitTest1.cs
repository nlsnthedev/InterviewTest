using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Skylink.AutomationAssignment
{
    [TestFixture]
    public class ChiomaInterviewTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver("/Users/macbook/Desktop/Dev/chromedriver-mac-x64/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void BuyTShirt()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Login
            IWebElement username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");
            System.Threading.Thread.Sleep(2000);

            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");
            System.Threading.Thread.Sleep(2000);

            IWebElement loginButton = driver.FindElement(By.Name("login-button"));
            loginButton.Click();
            System.Threading.Thread.Sleep(2000);

            // Add T-shirt to cart
            wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"item_1_title_link\"]/div")).Displayed);
            IWebElement sauceTShirt = driver.FindElement(By.XPath("//*[@id=\"item_1_title_link\"]/div"));
            sauceTShirt.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement addToCart = driver.FindElement(By.Id("add-to-cart"));
            addToCart.Click(); // adding to Cart
            System.Threading.Thread.Sleep(2000);

            IWebElement cartButton = driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a"));
            cartButton.Click(); // clicking the cart button
            System.Threading.Thread.Sleep(2000);

            // Proceed to checkout
            IWebElement checkoutButton = driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();
            System.Threading.Thread.Sleep(2000);

            // Fill in the checkout information
            IWebElement firstName = driver.FindElement(By.Id("first-name"));
            firstName.SendKeys("Chioma");
            System.Threading.Thread.Sleep(2000);

            IWebElement lastName = driver.FindElement(By.Id("last-name"));
            lastName.SendKeys("Cynthia");
            System.Threading.Thread.Sleep(2000);

            IWebElement postalCode = driver.FindElement(By.Id("postal-code"));
            postalCode.SendKeys("12345");
            System.Threading.Thread.Sleep(2000);

            IWebElement continueButton = driver.FindElement(By.Id("continue"));
            continueButton.Click();
            System.Threading.Thread.Sleep(2000);

            // Complete purchase
            IWebElement finishButton = driver.FindElement(By.Id("finish"));
            finishButton.Click();
            System.Threading.Thread.Sleep(2000);

            // Verify purchase confirmation
            wait.Until(driver => driver.FindElement(By.CssSelector(".complete-header")).Displayed);
            IWebElement purchaseConfirmation = driver.FindElement(By.CssSelector(".complete-header"));
            Assert.That(purchaseConfirmation.Text.Contains("Thank you for your order"), Is.True);
        }

       [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
            }
        } 
    }
}