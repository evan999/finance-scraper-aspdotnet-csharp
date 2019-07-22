using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FinanceScraper_ConsoleApp;

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

            IWebElement stockTable = driver.FindElement(By.XPath("//tbody"));
            List<IWebElement> stocks = driver.FindElements(By.XPath("//tr")).ToList();

            List<IWebElement> rows = stockTable.FindElements(By.XPath("//tr")).ToList();
            int rowsCount = rows.Count;

            using (var context = new FinanceContext())
            {
                //var stockTable = driver.FindElement(By.XPath("//tbody"));
                //List<IWebElement> lstTrElem = new List<IWebElement>(stockTable.FindElements(By.XPath("//tr")));
                // String strRowData = "";

                
                for (int row = 1; row < rowsCount; row++)
                {
                    List<IWebElement> cells = rows.ElementAt(row).FindElements(By.TagName("td")).ToList();
                    int cellsCount = cells.Count;


                    // string cellText = cells.ElementAt(cell).ToString();
                    // Console.WriteLine("Data: " + cellText);

                    string symbolData = cells.ElementAt(0).Text;
                    Console.WriteLine("Symbol: " + symbolData);
                    string lastPriceData = cells.ElementAt(1).Text;
                    Console.WriteLine("Last Price: " + lastPriceData);
                    string changeData = cells.ElementAt(2).Text;
                    Console.WriteLine("Change: " + changeData);
                    string changeRateData = cells.ElementAt(3).Text;
                    Console.WriteLine("Change Rate: " + changeRateData);
                    string currencyData = cells.ElementAt(4).Text;
                    Console.WriteLine("Currency: " + currencyData);
                    string marketTimeData = cells.ElementAt(5).Text;
                    Console.WriteLine("Market Time: " + marketTimeData);
                    string volumeData = cells.ElementAt(6).Text;
                    Console.WriteLine("Volume: " + volumeData);
                    string shareData = cells.ElementAt(7).Text;
                    Console.WriteLine("Shares: " + shareData);
                    string averageVolumeData = cells.ElementAt(8).Text;
                    Console.WriteLine("Avg Vol Data: " + averageVolumeData);
                    string marketCapData = cells.ElementAt(12).Text;
                    Console.WriteLine("Market Cap: " + marketCapData);

                    var stockRecord = new Stock
                    {
                        Symbol = symbolData,
                        LastPrice = lastPriceData,
                        Change = changeData,
                        ChangeRate = changeRateData,
                        Currency = currencyData,
                        MarketTime = marketTimeData,
                        Volume = volumeData,
                        Shares = shareData,
                        AverageVolume = averageVolumeData,
                        MarketCap = marketCapData
                    };

                    context.Stocks.Add(stockRecord);
                    context.SaveChanges();
                }
            }
        }
    }            
}
        





