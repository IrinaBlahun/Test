using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AuthorizationCianPageTests
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _SingInButton = By.XPath("//span[normalize-space(text()) = 'Зарегистрироваться']");
        private readonly By _loginInputButton = By.XPath("//input[@name='username']");
        private readonly By _continueButton = By.XPath("//button[@type ='submit']");
        private readonly By _passwordInpudButton = By.XPath("//*[@id='new_password']");
        private readonly By _confirmedPasswordInpudButton = By.XPath("//*[@id='confirmed_password']");
        private readonly By _createButton = By.XPath("//span[normalize-space(text()) = 'Создать аккаунт']");

        private readonly By _userLogin = By.XPath("//span[@class='c-header-user-login-full']");

        private const string _login = "irinaTrigger@gmail.com";
        private const string _password = "Gfhjkm4040";
        private const string _confirmed_password = "Gfhjkm4040";
        private const string _expectedLogin = "IrinaTrigger";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://realt.by");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            var SingIn = driver.FindElement(_SingInButton);
            SingIn.Click();

            var login = driver.FindElement(_loginInputButton);
            login.SendKeys(_login);

            var continueLogin = driver.FindElement(_continueButton);
            continueLogin.Click();

            Thread.Sleep(1000);

            var password = driver.FindElement(_passwordInpudButton);
            password.SendKeys(_password);

            var confirmed_password = driver.FindElement(_confirmedPasswordInpudButton);
            confirmed_password.SendKeys(_confirmed_password);

            var createButton = driver.FindElement(_createButton);
            createButton.Click();

            Thread.Sleep(1000);

            var actualLogin = driver.FindElement(_userLogin).Text;
            createButton.Click();

            Assert.AreEqual(_expectedLogin, actualLogin, "Login is wrong");
        }

        [TearDown]
        public void TaerDown()
        {
            driver.Quit();
        }

    }
}
