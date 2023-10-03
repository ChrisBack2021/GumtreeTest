using Microsoft.IdentityModel.Tokens;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumtree.Pages
{
    public class SingleListing
    {
        private IWebDriver driver;

        public SingleListing(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ItemTitle => driver.FindElement(By.CssSelector("h1.vip-ad-title__header"));
        public IWebElement Message => driver.FindElement(By.Id("input-reply-widget-form-message"));

        public IWebElement Desc => driver.FindElement(By.XPath("//div[@class='vip-ad-description__content--wrapped']"));

        public IWebElement MoreBtn => driver.FindElement(By.XPath("//div[@class='vip-ad-description']/button"));



        public bool CheckMsg()
        {
            if (!Message.Text.IsNullOrEmpty())
                return true;
            return false;
        }

        public bool TitleCheck()
        {
            if (ItemTitle.Text.Contains("freedom sport"))
                return true;
            return false;
            
        }
    }
}
