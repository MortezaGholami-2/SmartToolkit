using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartScraper
{
    public class DynamicWebScraper
    {
        // It's necessery to download the web driver of the browser you want to use and put it inside the bin > debug folder so that you don’t have to specify a path within the code.

        public static HtmlDocument GetWebContentByUrl(string webPageUrl)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl($"{webPageUrl}");

            //HtmlDocument document = new HtmlDocument();
            //document.Load(documentPath);
            //return document;
            return default;
        }
    }
}
