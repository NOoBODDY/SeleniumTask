using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTask
{
    class Program
    {
        

        static void Main(string[] args)
        {
            IWebDriver driver;
            string URL = "https://careers.veeam.ru/vacancies";
            string department = "Разработка продуктов";
            string language = "Английский";
            int expectedAmount = 0;

            if (args.Length != 0)
            {
                if ( args.Length == 1)
                {
                    expectedAmount = Convert.ToInt32(args[0]);
                }
                else
                {
                    expectedAmount = Convert.ToInt32(args[0]);
                    department = args[1];
                    language = args[2];
                }
                
            }
            Console.WriteLine("Find vacancys for {0} department, {1} language. Expected amount {2}", department, language, expectedAmount);

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // timeout for 10 seconds


            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.FullScreen();

            //choose department
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div")).FindElement(By.LinkText(department)).Click();

            //choose language
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button")).Click();

            IList<IWebElement> elements = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div")).FindElements(By.TagName("label"));
            foreach (IWebElement element in elements)
            {
                if (element.Text == language)
                {
                    element.Click();
                }
                
            }
            
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button")).Click();

            //count positions
            int amount = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div")).FindElements(By.TagName("a")).Count / 2;
            Console.WriteLine("Vacancys amount: " + amount);
            if (amount != expectedAmount)
            {
                Console.WriteLine("Real amount not equal to expected");
            }
            else
            {
                Console.WriteLine("Real amount equal to expected");
            }
            driver.Close();
        }


    }
}
