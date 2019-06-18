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
            TestChromeDriver.RunTestDriver();            
        }
    }
}
