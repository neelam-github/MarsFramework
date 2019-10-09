using AutoIt;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {

        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region FindsBy

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ServiceListing']")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type (One-Off service)
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement OneOffservice { get; set; }

        //Select the Service type (Hourly basis service)
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement Hourlybasisservice { get; set; }

        //Select the Location Type (On-site)
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement OnSite { get; set; }

        //Select the Location Type (Online)
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement Online { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input")]
        private IWebElement Days { get; set; }
        
        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[7]/div[2]/input")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[7]/div[3]/input")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option (Skill-exchange)
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillExchangeOption { get; set; }

        //Click on Skill Trade option (Credit)
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement CreditOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'charge')]")]
        private IWebElement CreditAmount { get; set; }

        //Click on Work Samples
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement WorkSample { get; set; }

        //Click on Active option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveOption { get; set; }

        //Click on Hidden option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement HiddenOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[2]")]
        private IWebElement Category { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement ManageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span")]
        private IWebElement SavedTag { get; set; }

        #endregion

        internal void EnterShareSkill()
        {
            //Populate the Excel Sheet of ShareSkill
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\Rammy\Desktop\marsframework\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            GlobalDefinitions.wait(30);

            //Click on ShareSkill button
            ShareSkillButton.Click();

            //Wait
            GlobalDefinitions.wait(30);

            //Enter data in Title textbox
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            string TitleTextbox = Title.GetAttribute("Value");
            if (TitleTextbox.Length == 0)
            {
                Assert.IsEmpty("Title");
            }

            //Enter data in Description textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            Assert.That(Description.Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));
            
            //Select Category
            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            CategoryDropDown.Click();

            //Select SubCategory
            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            SubCategoryDropDown.Click();

            //Enter data in Tags textbox
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Assert.That(SavedTag.Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Tags")));

            //Click on Hourly basis service or One-off service
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type")== "Hourly basis service")
            {
                Hourlybasisservice.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "One-off service")
            {
                OneOffservice.Click();
            }

            //Click on On-site or Online
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "On-site")
            {
                OnSite.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "Online")
            {
                Online.Click();
            }

            //Wait
            GlobalDefinitions.wait(60);

            //Convert excel dateformat to C# - Enter data in Staredate
            string dateformat = "dd / MM / yyyy";
            string sdate = GlobalDefinitions.ExcelLib.ReadData(2, "Startdate");
            string newStartDate = DateTime.Parse(sdate).ToString(dateformat);
            StartDateDropDown.SendKeys(newStartDate);

            string StartDate = StartDateDropDown.GetAttribute("Value");
            if (StartDate.Length == 0)
            {
                Assert.IsEmpty("Startdate");
            }

            //Convert excel dateformat to C# - Enter data in Enddate
            string edate = GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            string newEndDate = DateTime.Parse(edate).ToString(dateformat);
            EndDateDropDown.SendKeys(newEndDate);

            string EndDate = EndDateDropDown.GetAttribute("Value");
            if (EndDate.Length == 0)
            {
                Assert.IsEmpty("Enddate");
            }
            //Wait
            GlobalDefinitions.wait(60);

            //Click on a day
            Days.Click();

            //Convert excel timeformat to C# - enter data in Starttime
            string timeformat = "hh:mmtt";
            string stime = GlobalDefinitions.ExcelLib.ReadData(2, "Starttime");
            string newStartTime = DateTime.Parse(stime).ToString(timeformat);
            StartTimeDropDown.SendKeys(newStartTime);

            string Start = StartTimeDropDown.GetAttribute("Value");
            if (Start.Length == 0)
            {
                Assert.IsEmpty("Starttime");
            }

            //Convert excel timeformat to C# - enter data in Endtime
            string etime = GlobalDefinitions.ExcelLib.ReadData(2, "Endtime");
            string newEndTime = DateTime.Parse(etime).ToString(timeformat);
            EndTimeDropDown.SendKeys(newEndTime);

            string End = EndTimeDropDown.GetAttribute("Value");
            if (End.Length == 0)
            {
                Assert.IsEmpty("Endtime");
            }

            //Click on Skill-exchange or Credit
            if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Skill-exchange")
            {
                SkillExchangeOption.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);

            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Credit")
            {
                CreditOption.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }

            //Click on Active or Hidden
            ActiveOption.Click();
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Active") == "Active")
            {
                ActiveOption.Click();

            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Active") == "Hidden")
            {
                HiddenOption.Click();
            }

            //Upload a file
            WorkSample.Click();
            GlobalDefinitions.wait(20);
            string path = GlobalDefinitions.ExcelLib.ReadData(2, "WorkSample");
            AutoItX.WinActivate("File Upload");

            //Wait
            GlobalDefinitions.wait(60);

            AutoItX.Send(path);
            AutoItX.Send("{ENTER}");


            Save.Click();

            Assert.That(ManageTitle.Text, Is.EqualTo("Animation"));
        }

        internal void EditShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\Rammy\Desktop\marsframework\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            GlobalDefinitions.wait(30);

            //Click on ShareSkill button
            ShareSkillButton.Click();

            //Wait
            GlobalDefinitions.wait(30);

            //Enter data in Title textbox
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));
            string TitleTextbox = Title.GetAttribute("Value");
            if (TitleTextbox.Length == 0)
            {
                Assert.IsEmpty("Title");
            }

            //Enter data in Description textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));
            Assert.That(Description.Text, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Description")));

            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Category"));
            CategoryDropDown.Click();

            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SubCategory"));
            SubCategoryDropDown.Click();

            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Click on Hourly basis service or One-off service
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Service Type") == "Hourly basis service")
            {
                Hourlybasisservice.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Service Type") == "One-off service")
            {
                OneOffservice.Click();
            }

            //Click on On-site or Online
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Location Type") == "On-site")
            {
                OnSite.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Location Type") == "Online")
            {
                Online.Click();
            }

            //Wait
            GlobalDefinitions.wait(60);

            //Convert excel dateformat to C# - Enter data in Staredate
            string dateformat = "dd / MM / yyyy";
            string sdate = GlobalDefinitions.ExcelLib.ReadData(3, "Startdate");
            string newStartDate = DateTime.Parse(sdate).ToString(dateformat);
            StartDateDropDown.SendKeys(newStartDate);

            string StartDate = StartDateDropDown.GetAttribute("Value");
            if (StartDate.Length == 0)
            {
                Assert.IsEmpty("Startdate");
            }

            //Convert excel dateformat to C# - Enter data in Enddate
            string edate = GlobalDefinitions.ExcelLib.ReadData(3, "Enddate");
            string newEndDate = DateTime.Parse(edate).ToString(dateformat);
            EndDateDropDown.SendKeys(newEndDate);

            string EndDate = EndDateDropDown.GetAttribute("Value");
            if (EndDate.Length == 0)
            {
                Assert.IsEmpty("Enddate");
            }

            //Wait
            GlobalDefinitions.wait(60);

            //Click on a day
            Days.Click();

            //Convert excel timeformat to C# - enter data in Starttime
            string timeformat = "hh:mmtt";
            string stime = GlobalDefinitions.ExcelLib.ReadData(3, "Starttime");
            string newStartTime = DateTime.Parse(stime).ToString(timeformat);
            StartTimeDropDown.SendKeys(newStartTime);

            string Start = StartTimeDropDown.GetAttribute("Value");
            if (Start.Length == 0)
            {
                Assert.IsEmpty("Starttime");
            }

            //Convert excel timeformat to C# - enter data in Endtime
            string etime = GlobalDefinitions.ExcelLib.ReadData(3, "Endtime");
            string newEndTime = DateTime.Parse(etime).ToString(timeformat);
            EndTimeDropDown.SendKeys(newEndTime);

            string End = EndTimeDropDown.GetAttribute("Value");
            if (End.Length == 0)
            {
                Assert.IsEmpty("Endtime");
            }

            //Click on Skill-exchange or Credit
            if (GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade") == "Skill-exchange")
            {
                SkillExchangeOption.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);

            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade") == "Credit")
            {
                CreditOption.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }


            //Click on Active or Hidden
            ActiveOption.Click();
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Active") == "Active")
            {
                ActiveOption.Click();

            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Active") == "Hidden")
            {
                HiddenOption.Click();
            }

            //Upload a file
            WorkSample.Click();
            GlobalDefinitions.wait(20);
            string path = GlobalDefinitions.ExcelLib.ReadData(3, "WorkSample");
            AutoItX.WinActivate("File Upload");

            //Wait
            GlobalDefinitions.wait(60);

            AutoItX.Send(path);
            AutoItX.Send("{ENTER}");

            Save.Click();

            Assert.That(ManageTitle.Text, Is.EqualTo("Voice Actor"));
        }
    }
    
}
