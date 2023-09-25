using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumtree.Pages
{
    public class QuintrexListing
    {

        private IWebDriver driver;

        public QuintrexListing(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MinPrice => driver.FindElement(By.CssSelector("input#input-srp-range-filter-min"));

        public IWebElement MaxPrice => driver.FindElement(By.CssSelector("input#input-srp-range-filter-max"));

        public IWebElement PriceBtn => driver.FindElement(By.XPath("//button[contains(text(), 'Go')]"));

        public IWebElement FilterBtn => driver.FindElement(By.Id("srp-sort-by"));


        public void SelectListing()
        {
           
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IList<IWebElement> lists = wait.Until(e =>
                {
                    var elements = driver.FindElements(By.XPath("//span[@class='user-ad-row-new-design__title-span']"));
                    return elements.Count > 0 ? elements : null;
                });
                
               
                foreach (IWebElement list in lists)
                {   
                    if (list.Text.Contains("freedom sport"))
                    {
                        list.Click();
                    }

                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void SortBy()
        {
            try
            {
                SelectElement select = new SelectElement(FilterBtn);
                select.SelectByValue("price_desc");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void PriceRange(string min, string max)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.CssSelector("input#input-srp-range-filter-min")));

            MinPrice.SendKeys(min);
            MaxPrice.SendKeys(max);
            PriceBtn.Click();
        }

    }
}
