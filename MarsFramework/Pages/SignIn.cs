using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    class SignIn
    {

        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            //extent reports
            Base.test = Base.extent.StartTest("SignIn Test");

            //Click on SignIn button
            SignIntab.Click();

            //Populate the Excel Sheet of SignIn
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\Rammy\Desktop\marsframework\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "SignIn");

            //Enter email
            Email.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //Enter password
            Password.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on login
            LoginBtn.Click();
        }
    }
}