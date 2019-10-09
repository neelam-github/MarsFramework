using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {


        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ListingManagement']")]
        private IWebElement manageListingsButton { get; set; }

        //Click on active slider
        [FindsBy(How = How.XPath, Using= "(//input[contains(@name,'isActive')])[1]")]
        private IWebElement ActiveSlider { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[contains(@class,'remove icon')])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement clickActionsButton { get; set; }

        internal void EditListings()
        {
            //Populate the Excel Sheet of Manage Listings
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\Rammy\Desktop\marsframework\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");

            //Wait
            GlobalDefinitions.wait(10);

            //Click on Manage Listing tab under Profile page
            manageListingsButton.Click();

            //Click on Edit button and send to edit page
            edit.Click();

        }

        internal void ViewandDeleteListings()
        {
            //Populate the Excel Sheet of Manage Listings
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\Rammy\Desktop\marsframework\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");

            //Wait
            GlobalDefinitions.wait(10);

            //Click on Manage Listing tab under Profile page
            manageListingsButton.Click();

            //Click on View button and send to View page
            view.Click();

            //Go back to Manage Listing page from View page
            Base.Back();

            //Click on Active slider
            ActiveSlider.Click();

            //Click on delete button
            delete.Click();

            //Popup come up after clicking delete button and click yes button
            clickActionsButton.Click();
            

        }

    }
}
