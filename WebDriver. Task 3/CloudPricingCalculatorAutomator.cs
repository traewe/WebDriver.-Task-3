﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection.PortableExecutable;
using OpenQA.Selenium.DevTools.V122.SystemInfo;

namespace WebDriver._Task_3
{
    public class CloudPricingCalculatorAutomator
    {
        private IWebDriver driver;

        public CloudPricingCalculatorAutomator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EstimateComputeEngineCost()
        {
            driver.Navigate().GoToUrl("https://cloud.google.com/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            var searchIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("YSM5S")));
            searchIcon.Click();

            var searchText = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("qdOxv-fmcmS-wGMbrd")));
            searchText.SendKeys("Google Cloud Platform Pricing Calculator");

            new Actions(driver).SendKeys(Keys.Enter).Perform();

            var pricingCalculatorLink = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"
                //a[@href='https://cloud.google.com/products/calculator']")));
            pricingCalculatorLink.Click();

            var addToAstimateButton = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("UywwFc-LgbsSe-OWXEXe-Bz112c-M1Soyc")));
            addToAstimateButton.Click();

            var computeEngineButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-service-form='8' and @data-idx='0']")));
            computeEngineButton.Click();

            var numberOfInstancesInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/c-wiz[1]/div/div/div[1]/div/div/div
                /div/div/div/div/div[1]/div/div[2]/div[3]/div[2]/div/div/div/div/div/div[1]/div[3]/div[2]/div/label/span[2]/input")));
            numberOfInstancesInput.Clear();
            numberOfInstancesInput.SendKeys("4");

            var machineTypeSelectionButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(@"div[jsname='kgDJk']")));
            machineTypeSelectionButton.Click();

            var n1Standard8Button = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li[data-value='n1-standard-8']")));
            n1Standard8Button.Click();

            var addGPUsButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(@"button[jsname='DMn7nd'][aria-label='Add GPUs']")));
            addGPUsButton.Click();

            var GPUModelSelectionButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/c-wiz[1]/div/div/div[1]/div/div
                /div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div")));
            GPUModelSelectionButton.Click();

            var NVIDIATeslaV100Button = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li[data-value='nvidia-tesla-v100']")));
            NVIDIATeslaV100Button.Click();

            var localSSDSelectionButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/c-wiz[1]/div/div/div[1]/div/div
                /div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[1]")));
            localSSDSelectionButton.Click();

            var localSSD2x375GBButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/c-wiz[1]/div/div/div[1]/div/div
                /div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[2]/ul/li[3]")));
            localSSD2x375GBButton.Click();

            var regionSelectionButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/c-wiz[1]/div/div/div[1]/div/div
                /div/div/div/div/div/div[1]/div/div[2]/div[3]/div[29]/div/div[1]/div/div/div/div[1]")));
            regionSelectionButton.Click();

            var NetherlandsRegionButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li[data-value='europe-west4']")));
            NetherlandsRegionButton.Click();

            // Without sleeping system can't receive some previous data
            Thread.Sleep(1000);

            var shareButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"html/body/c-wiz[1]/div/div/div[1]/div/div/div/div
                /div/div/div/div[2]/div[1]/div/div[4]/div[2]/div[2]/div/button")));
            shareButton.Click();

            var openEstimateSummaryButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/div[4]/div[2]/div/div/div/div[1]/a")));
            openEstimateSummaryButton.Click();
        }
        public bool CheckData()
        {
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            var elements = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("span[class='Kfvdz']")));

            return elements[9].Text == "4"
                && elements[10].Text == "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)"
                && elements[11].Text == "Regular"
                && elements[2].Text == "n1-standard-8, vCPUs: 8, RAM: 30 GB"
                && elements[4].Text == "NVIDIA Tesla V100"
                && elements[5].Text == "1"
                && elements[6].Text == "2x375 GB"
                && elements[17].Text == "Netherlands (europe-west4)";
        }
    }
}
