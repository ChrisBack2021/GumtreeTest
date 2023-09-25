using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumtree.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Cat => driver.FindElement(By.CssSelector("div#categoryId-wrp"));
        public ReadOnlyCollection<IWebElement> CatList => driver.FindElements(By.CssSelector(".j-selectbox__li.j-selectbox__li-1"));

        public IWebElement SearchBar => driver.FindElement(By.XPath("//input[@id='search-query']"));

        public IWebElement Location => driver.FindElement(By.Id("search-area"));

        public IWebElement Distance => driver.FindElement(By.Id("srch-radius-wrp"));

        public ReadOnlyCollection<IWebElement> DistanceList => driver.FindElements(By.XPath("//div[contains(@id, 'srch-radius-wrp-option')]"));

        public IWebElement SearchBtn => driver.FindElement(By.XPath("//button[@class='header__search-button' and @type='submit']"));


        public void Search()
        {
            SearchBtn.Click();
        }


        public void SelectDistance()
        {
            Distance.Click();

            foreach (var d in DistanceList)
            {

                if (d.Text.Contains("20"))
                    d.Click();

            }
        }

        public void InputLocation()
        {
            Location.Click();
            Location.SendKeys("Sydney");

        }

        public void InputSearch()
        {
            SearchBar.SendKeys("quintrex");
        }

        public bool CheckCat()
        {
            try
            {
                if (Cat.GetAttribute("title") == "Boats & Jet Skis")
                    return true;
            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }

        public void ChooseCat()
        {
            Cat.Click();

            foreach (var cat in CatList) 
            {
                if (cat.Text.Contains("Boats"))
                {
                    cat.Click();
                }
            }
        }

    }
}
