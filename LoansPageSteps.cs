using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Auden_QA_Test_Chivers
{
    [Binding]
    public sealed class LoansPageSteps : IDisposable
    {

        private int convertedInteger = 0;

        private IWebDriver webDriver = new ChromeDriver();

        [Given(@"I open and navigate to the Auden Short Term Loan Web Site")]
        public void GivenIOpenAndNavigateToTheAudenShortTermLoanWebSite()
        {
            webDriver.Navigate().GoToUrl("https://www.auden.co.uk/credit/shorttermloan");
            //loanPage = new LoanPage(webDriver);

            Assert.That(LogoIsPresent, Is.True);
        }

        [Given(@"The slider element is present")]
        public void GivenTheSliderElementIsPresent()
        {
            Assert.That(IsSliderPresent, Is.True, "True");
        }

        [When(@"Slider is set to Min Position")]
        public void WhenSliderIsSetToMinPosition()
        {
            MoveSlider(0);
            MoveSlider(-270);
        }

        [When(@"Slider is set to Max Position")]
        public void WhenSliderIsSetToMaxPosition()
        {
            MoveSlider(0);
            MoveSlider(270);
        }

        [Then(@"Close the Auden Short Term Loan Web Site")]
        public void ThenCloseTheAudenShortTermLoanWebSite()
        {
            Dispose();
        }

        [Given(@"Slider is set to Min Position value will be £(.*)")]
        public void GivenSliderIsSetToMinPositionValueWillBe(int p0)
        {

            MoveSlider(-270);

            var value = webDriver.FindElement(By.ClassName("loan-amount__range-slider__input")).GetAttribute("value");

            try
            {
                convertedInteger = Int32.Parse(value);
                Console.WriteLine(convertedInteger);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Assert.That(p0 == convertedInteger, Is.True);

            Console.WriteLine("Min Value of p0 = " + "Min Value = " + value);
        }

        [When(@"Slider is set to Quarter Position value will be £(.*)")]
        public void WhenSliderIsSetToQuarterPositionValueWillBe(int p0)
        {
            MoveSlider(-135);

            var value = webDriver.FindElement(By.ClassName("loan-amount__range-slider__input")).GetAttribute("value");

            try
            {
                convertedInteger = Int32.Parse(value);
                Console.WriteLine(convertedInteger);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }



            Assert.That(p0 == convertedInteger, Is.True);

            Console.WriteLine("1/4 Value of p0 = " + "1/4 Value = " + value);
        }

        [When(@"Slider is set to Half Position value will be £(.*)")]
        public void WhenSliderIsSetToHalfPositionValueWillBe(int p0)
        {
            MoveSlider(0);

            var value = webDriver.FindElement(By.ClassName("loan-amount__range-slider__input")).GetAttribute("value");

            try
            {
                convertedInteger = Int32.Parse(value);
                Console.WriteLine(convertedInteger);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }



            Assert.That(p0 == convertedInteger, Is.True);

            Console.WriteLine("1/2 Value of p0 = " + "1/2 Value = " + value);
        }

        [When(@"Slider is set to Three Quarters Position value will be £(.*)")]
        public void WhenSliderIsSetToThreeQuartersPositionValueWillBe(int p0)
        {
            MoveSlider(135);

            var value = webDriver.FindElement(By.ClassName("loan-amount__range-slider__input")).GetAttribute("value");

            try
            {
                convertedInteger = Int32.Parse(value);
                Console.WriteLine(convertedInteger);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }



            Assert.That(p0 == convertedInteger, Is.True);

            Console.WriteLine("3/4 Value of p0 =  " + p0 + "2/4 Value = " + value);
        }

        [When(@"Slider is set to Max Position value will be £(.*)")]
        public void WhenSliderIsSetToMaxPositionValueWillBe(int p0)
        {
            MoveSlider(270);

            var value = webDriver.FindElement(By.ClassName("loan-amount__range-slider__input")).GetAttribute("value");

            try
            {
                convertedInteger = Int32.Parse(value);
                Console.WriteLine(convertedInteger);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }



            Assert.That(p0 == convertedInteger, Is.True);

            Console.WriteLine("Max Value of p0 = " + p0 + "Max Value = " + value);
        }

        [Then(@"Close down the Auden Short Term Loan Web Site")]
        public void ThenCloseDownTheAudenShortTermLoanWebSite()
        {
            Dispose();
        }

        [Given(@"I click the Repayment Day Button (.*) the first Repayment Negative Test value will be Wednesday (.*) Oct (.*) or Thursday (.*) Oct (.*)")]
        public void GivenIClickTheRepaymentDayButtonTheFirstRepaymentNegativeTestValueWillBeWednesdayOctOrThursdayOct(int p0, int p1, int p2, int p3, int p4)
        {
            //Button 1 - Neg


            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Thursday, " + "October " + p1 + "," + " " + p2;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Friday, " + "October " + p3 + "," + " " + p4;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.False);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Positive Test value will be Thursday (.*) Oct (.*) or Friday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentPositiveTestValueWillBeThursdayOctOrFridayOct(int p0, int p1, int p2, int p3, int p4)
        {
            //Button 1 - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Thursday, " + "October " + p1 + "," + " " + p2;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Friday, " + "October " + p3 + "," + " " + p4;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.True);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Negative Testvalue will be Wednesday (.*) Sep (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentNegativeTestvalueWillBeWednesdaySep(int p0, int p1, int p2)
        {
            //Button 5 - Neg
            //Button 6 - Neg
            //Button 18 - Neg



            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__text")).Text;

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Wednesday, " + "September " + p1 + "," + " " + p2;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1, Is.False);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Positive Test value will be Monday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentPositiveTestValueWillBeMondayOct(int p0, int p1, int p2)
        {
            //Button 5 - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__text")).Text;

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Monday, " + "October " + p1 + "," + " " + p2;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1, Is.True);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Positive Test value will be Tuesday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentPositiveTestValueWillBeTuesdayOct(int p0, int p1, int p2)
        {
            //Button 6 - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__text")).Text;

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Tuesday, " + "October " + p1 + "," + " " + p2;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1, Is.True);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Positive Test value will be Friday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentPositiveTestValueWillBeFridayOct(int p0, int p1, int p2)
        {
            //Button 18 - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__text")).Text;

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Friday, " + "October " + p1 + "," + " " + p2;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1, Is.True);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Negative Testvalue will be Wednesday (.*) Sep (.*) or Monday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentNegativeTestvalueWillBeWednesdaySepOrMondayOct(int p0, int p1, int p2, int p3, int p4)
        {
            //Button 26 - Neg

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Wednesday, " + "September " + p1 + "," + " " + p2;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Monday, " + "October " + p3 + "," + " " + p4;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.False);


        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Positive Test value will be Friday (.*) Sep (.*) or Monday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentPositiveTestValueWillBeFridaySepOrMondayOct(int p0, int p1, int p2, int p3, int p4)
        {
            //Button 26 - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Friday, " + "September " + p1 + "," + " " + p2;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Monday, " + "October " + p3 + "," + " " + p4;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.True);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Negative Test value will be Wednesday (.*) Sep (.*) or Monday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentNegativeTestValueWillBeWednesdaySepOrMondayOct(int p0, int p1, int p2, int p3, int p4)
        {
            //Button 27 - Neg

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Wednesday, " + "September " + p1 + "," + " " + p2;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Monday, " + "October " + p3 + "," + " " + p4;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.False);
        }

        [When(@"I click the Repayment Day Button (.*) the first Repayment Positive Test value will be Friday (.*) Sep (.*) or Tuesday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonTheFirstRepaymentPositiveTestValueWillBeFridaySepOrTuesdayOct(int p0, int p1, int p2, int p3, int p4)
        {
            //Button 27 - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(p0);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Friday, " + "September " + p1 + "," + " " + p2;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Tuesday, " + "October " + p3 + "," + " " + p4;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.True);
        }

        [When(@"I click the Repayment Day Button Last Working Day the first Repayment Negative Test value will be Monday (.*) Oct (.*) or Monday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonLastWorkingDayTheFirstRepaymentNegativeTestValueWillBeMondayOctOrMondayOct(int p0, int p1, int p2, int p3)
        {
            //Button Last - Neg

            Thread.Sleep(500);
            RepaymentDaySelector(32);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Monday, " + "October " + p0 + "," + " " + p1;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Monday, " + "October " + p2 + "," + " " + p3;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.False);
        }

        [When(@"I click the Repayment Day Button Last Working Day the first Repayment Positive Test value will be Wednesday (.*) Sep (.*) or Friday (.*) Oct (.*)")]
        public void WhenIClickTheRepaymentDayButtonLastWorkingDayTheFirstRepaymentPositiveTestValueWillBeWednesdaySepOrFridayOct(int p0, int p1, int p2, int p3)
        {
            //Button Last - Pos

            Thread.Sleep(500);
            RepaymentDaySelector(32);

            Thread.Sleep(500);

            //First repayment Element 1
            var value1 = webDriver.FindElement(By.ClassName("loan-schedule__tab__panel__detail__tag__label")).GetAttribute("data-date");

            //Convert to Date String
            var newDate1 = Convert.ToDateTime(value1).ToLongDateString();

            //First repayment Element 2
            var value2 = webDriver.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail__tag__label:nth-child(2)")).Text;

            //Convert to Date String
            var newDate2 = Convert.ToDateTime(value2).ToLongDateString();

            //Concat First Value string from Specflow Variables
            string firstDate = "Wednesday, " + "September " + p0 + "," + " " + p1;

            //Concat Second Value string from Specflow Variables
            string secondDate = "Friday, " + "October " + p2 + "," + " " + p3;

            //Test Value 1
            Console.WriteLine(newDate1);

            //Test Concat Value
            Console.WriteLine(firstDate);

            // Test Value 1
            Console.WriteLine(newDate2);

            //Test Concat Value
            Console.WriteLine(secondDate);

            //Verify Dates Match or Do not Match.
            Assert.That(firstDate == newDate1 && secondDate == newDate2, Is.True);
        }

        //UI Elements

        public bool LogoIsPresent()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//img[@alt='Auden logo']")));

            var element = webDriver.FindElement(By.XPath("//img[@alt='Auden logo']"));

            if (element.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsSliderPresent()

        {
            var element = webDriver.FindElement(By.CssSelector(".loan-amount__range-slider__input"));

            if (element.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void MoveSlider(int offset)
        {
            IWebElement Slider = webDriver.FindElement(By.ClassName("loan-amount__range-slider__input"));
            Thread.Sleep(3000);

            Actions moveSlider = new Actions(webDriver);
            Actions action = moveSlider.DragAndDropToOffset(Slider, offset, 0);

            action.Perform();

        }

        public void RepaymentDaySelector(int selection)
        {
            IWebElement day = webDriver.FindElement(By.CssSelector(".date-selector__flex:nth-child(" + selection + ")>#monthly"));
            day.Click();
        }

        public void Dispose()
        {
            if (webDriver != null)
            {
                webDriver.Dispose();
                webDriver = null;
            }
        }
    }
}
