using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FinanceScraper
{
    public class WebDriver
    {
        /*
        public void Login()
        {
            
        }
        */
        public static void RunWebDriver()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://finance.yahoo.com/");

            WebDriverWait waitLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitLogin.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("uh-signedin")));

            IWebElement loginButton = driver.FindElement(By.Id("uh-signedin"));
            loginButton.Click();

            WebDriverWait waitEnterUsername = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitEnterUsername.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-username")));

            IWebElement userName = driver.FindElement(By.Id("login-username"));

            userName.SendKeys("meshberge");
            userName.SendKeys(Keys.Enter);

            WebDriverWait waitEnterPassword = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitEnterPassword.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-passwd")));
            IWebElement password = driver.FindElement(By.Id("login-passwd"));

            password.SendKeys("toonfan1!");
            password.SendKeys(Keys.Enter);

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");

            WebDriverWait waitDataTable = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitDataTable.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//tr")));

            IWebElement stockTable = driver.FindElement(By.XPath("//tr"));
            List<IWebElement> stocks = driver.FindElements(By.XPath("//tr")).ToList();
            foreach (IWebElement stock in stocks)
            {
                var stockData = stock.Text;
                Console.Write(stockData);
            }
        }
        
    }
}



