using Gumtree.Pages;

namespace Gumtree
{
    [TestClass]
    public class Tests : SetUp
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hPage = new HomePage(driver);
            var cUrl = driver.Url;
            hPage.ChooseCat();
            var catCheck = hPage.CheckCat();
            Assert.IsTrue(catCheck, "Category should be Boats & Jet Skis");

            hPage.InputSearch();
            hPage.InputLocation();
            hPage.SelectDistance();
            hPage.Search();

            var newUrl = driver.Url;
            Assert.AreNotEqual(cUrl, newUrl, "Url did not change successfully");

            var listings = new QuintrexListing(driver);
            string min = "5000";
            string max = "25000";
            listings.PriceRange(min, max);

            var minPrice = listings.MinPrice.GetAttribute("value");
            Assert.AreEqual(minPrice, min, "Minimum price should be set to 5000");

            var maxPrice = listings.MaxPrice.GetAttribute("value");
            Assert.AreEqual(maxPrice, max, "Maximum price should be set to 25000");

            listings.SortBy();
            listings.SelectListing();

            var singleItem = new SingleListing(driver);
            var checkTitle = singleItem.TitleCheck();
            Assert.IsTrue(checkTitle, "Correct item has not been found");

            var defaultMsg = singleItem.CheckMsg();
            Assert.IsTrue(defaultMsg, "Message box should not be null or empty");
        }
    }
}