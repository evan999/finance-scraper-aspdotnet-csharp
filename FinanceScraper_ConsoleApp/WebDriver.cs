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

            IWebElement stockTable = driver.FindElement(By.XPath("//tr"));
            List<IWebElement> stocks = driver.FindElements(By.XPath("//tr")).ToList();

            List<IWebElement> rows = stockTable.FindElements(By.XPath("//tr")).ToList();
            int rowsCount = rows.Count;



            using (var context = new FinanceContext())
            {
                for (int row = 1; row < rowsCount; row++)
                {

                    List<IWebElement> cells = driver.FindElements(By.XPath("//tr//td")).ToList();
                    int cellsCount = cells.Count;

                    for (int cell = 0; cell < cellsCount; cell++)
                    {
                        string symbolData = cells[0].Text;
                        Console.WriteLine("Symbol: " + symbolData);
                        string lastPriceData = cells[1].Text;
                        Console.WriteLine("Last Price: " + lastPriceData);
                        string changeData = driver.FindElements(By.XPath("//tr//td"))[2].Text;
                        Console.WriteLine("Change: " + changeData);
                        string changeRateData = driver.FindElements(By.XPath("//tr//td"))[3].Text;
                        Console.WriteLine("Change Rate: " + changeRateData);
                        string currencyData = driver.FindElements(By.XPath("//tr//td"))[4].Text;
                        Console.WriteLine("Currency: " + currencyData);
                        string marketTimeData = driver.FindElements(By.XPath("//tr//td"))[5].Text;
                        Console.WriteLine("Market Time: " + marketTimeData);
                        string volumeData = driver.FindElements(By.XPath("//tr//td"))[6].Text;
                        Console.WriteLine("Volume: " + volumeData);
                        string shareData = driver.FindElements(By.XPath("//tr//td"))[7].Text;
                        Console.WriteLine("Shares: " + shareData);
                        string averageVolumeData = driver.FindElements(By.XPath("//tr//td"))[8].Text;
                        Console.WriteLine("Avg Vol Data: " + averageVolumeData);
                        string dayRangeData = driver.FindElements(By.XPath("//tr//td"))[9].Text;
                        Console.WriteLine("Day Range Data: " + dayRangeData);
                        string c52WeekRangeData = driver.FindElements(By.XPath("//tr//td"))[10].Text;
                        Console.WriteLine("C52: " + c52WeekRangeData);
                        string marketCapData = driver.FindElements(By.XPath("//tr//td"))[11].Text;
                        Console.WriteLine("Market Cap: " + marketCapData);

                        var stock = new Stock
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
                            DayRange = dayRangeData,
                            C52WeekRange = c52WeekRangeData,
                            MarketCap = marketCapData
                        };

                        context.Stocks.Add(stock);
                        context.SaveChanges();
                    }
                }
            }

            /*
            foreach (IWebElement stock in stocks)
            {
                List<IWebElement> cells = driver.FindElements(By.XPath("//tr//")).ToList();

                var stockData = stock.Text;
                Console.Write(stockData);



                // Make a new instance of the Stock object.
                // Populate the fields by extracting the data of each field
                // and store it in the corresponding field.
                // var context = new FinanceEntities();
                /*
                var newStock = new Stock
                {
                    id = newStock.Id;
                }
                */

                /*
                using (var db = new FinanceEntities("name= newStock"))
                {
                    
                    var newStock = new Stock
                    {

                    }
                    
                    db.Stocks.Add(new Stock
                    {
                        id = stock. 
                    });
                    db.SaveChanges();

                    var getAllStocks = from x in db.Stocks
                                       orderby x.Symbol
                                       select x;
                

                


            }
            */
        }
    }            
}
        





