using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace FinanceScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            WebDriver.RunWebDriver();
        }
    }
}
