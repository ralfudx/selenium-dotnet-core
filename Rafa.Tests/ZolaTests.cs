using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Resources;
using Xunit;

namespace Rafa.Tests
{
    public class ZolaTests: IDisposable
    {
        public static IWebDriver _browserDriver;
        public IConfiguration _config;
        public string _filePath;
        
		public ZolaTests()
        {
            _browserDriver = new ChromeDriver("./");
            _config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
			_browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/sample_resume.txt";
        }

        public void Dispose()
        {
           _browserDriver.Quit();
        }

        [Fact]
        public void Apply_For_Job()
        {
			//go to url and click apply button for QA Engineer role
			_browserDriver.Navigate().GoToUrl(_config["zolaurl"]);
			_browserDriver.FindElement(By.XPath("//*[@id='tab-annunci']/div[6]/div[2]/a/button")).Click();
			
			//fill form
			_browserDriver.FindElement(By.Id("nome")).SendKeys(_config["name"]);
			_browserDriver.FindElement(By.Id("cognome")).SendKeys(_config["surname"]);
			_browserDriver.FindElement(By.Id("candidatoEmail")).SendKeys(_config["email"]);
			_browserDriver.FindElement(By.Id("candidatoEmailConfirm")).SendKeys(_config["email"]);
			
			//enter text for cover letter
			var coverLetterElement = _browserDriver.FindElement(By.Id("field_0_31942"));
			coverLetterElement.SendKeys(_config["coverletter"]);

            //attach resume/cv
            _browserDriver.FindElement(By.Id("field_fileCV")).SendKeys(_filePath);
			
			//select checkbox and submit form ----- note that click submit button has been intentionally commented out
			_browserDriver.FindElement(By.XPath("//*[@class='checkbox']/div/input")).Click();
			//_browserDriver.FindElement(By.Id("submit_button")).Click();
			
        }
    }
}
