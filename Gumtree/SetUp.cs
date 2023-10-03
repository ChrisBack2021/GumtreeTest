﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumtree
{
    [TestClass]
    public class SetUp
    {
        public IWebDriver driver;
        string url = "https://www.gumtree.com.au/";

        [TestInitialize]
        public void InitialTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
