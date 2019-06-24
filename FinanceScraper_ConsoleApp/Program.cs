using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FinanceScraper_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.finance.yahoo.com/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // driver.FindElement(By.Id("email")).SendKeys("userName");
            /*
            using (IWebDriver driver = new ChromeDriver())
            {
                //Notice navigation is slightly different than the Java version
                //This is because 'get' is a keyword in C#
                driver.Navigate().GoToUrl("http://www.finance.yahoo.com/");



                // Find the text input element by its name
                // IWebElement query = driver.FindElement(By.Name("q"));

                // Enter something to search for
                //query.SendKeys("Cheese");

                // Now submit the form. WebDriver will find the form for us from the element
                //query.Submit();

                // Google's search is rendered dynamically with JavaScript.
                // Wait for the page to load, timeout after 10 seconds
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                // Should see: "Cheese - Google Search" (for an English locale)
                //Console.WriteLine("Page title is: " + driver.Title);
                
            }
            */

        }
    }
}
