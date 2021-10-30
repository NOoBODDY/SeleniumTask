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
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // timeout for 10 seconds


            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.FullScreen();

            //choose department
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div")).FindElement(By.LinkText("Разработка продуктов")).Click();

            //choose language
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button")).Click();
            //driver.FindElement(By.CssSelector("#root > div > div.container-main.container-fluid > div > div.row.block-spacer-top > div.col-12.col-lg-4 > div > div:nth-child(3) > div > div > div > div:nth-child(2) > label")).Click();

            IList<IWebElement> elements = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div")).FindElements(By.TagName("label"));
            foreach (IWebElement element in elements)
            {
                if (element.Text == "Английский")
                {
                    element.Click();
                }
                
            }
            
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button")).Click();

            //count positions
            int amount = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[2]/div")).FindElements(By.TagName("a")).Count / 2;
            Console.WriteLine("amount: " + amount);
            driver.Close();
        }


    }
}
