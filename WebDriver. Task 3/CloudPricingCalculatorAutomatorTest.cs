using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver._Task_3
{
    [TestFixture]
    public class CloudPricingCalculatorAutomatorTest
    {
        IWebDriver driver;
        CloudPricingCalculatorAutomator calculatorAutomator;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            calculatorAutomator = new CloudPricingCalculatorAutomator(driver);
        }

        [Test]
        public void EstimateComputeEngineCost()
        {
            calculatorAutomator.EstimateComputeEngineCost();

            Assert.That(calculatorAutomator.CheckData(), Is.EqualTo(true));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
