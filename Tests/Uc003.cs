//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;



namespace UnitTestProject1.Tests
{
    [Binding]
    public class ValidarCompraOuVendaDeOrdemDeMercadoSteps
    {
        static IWebDriver driver = new ChromeDriver();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

        [Given(@"o acesso ao sistema")]
        public void DadoOAcessoAoSistema()
        {
            //IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://hml.vexter.com.br/login");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("username")).SendKeys("jadsontins@hotmail.com");
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys("Cedro*20");
            driver.FindElement(By.XPath("//button")).Click();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("taSearch")));

        }

        [Given(@"seleciono o ativo (.*)")]
        public void GivenSelecionoOAtivo(string Ativo)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#side-bar-left > nav > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("autoCompleteId")).Clear();
            driver.FindElement(By.Id("autoCompleteId")).SendKeys(Ativo);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("autoCompleteId")).SendKeys(Keys.Enter);
            //var listHits = driver.FindElements(By.CssSelector("button.mat-raised-button.button-type-symbool.type-one.mx-auto"));
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[2]/button/span")).Click();
        }


        [Given(@"realizo uma ordem de (.*)")]
        public void GivenRealizoUmaOrdemDe(string Ordem)
        {
            Thread.Sleep(3000);

            if (Ordem.Equals("COMPRA"))
                driver.FindElement(By.CssSelector("#mat-dialog-title-0 > div > button:nth-child(1)")).Click();
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='STOP'])[1]/following::button[1]")).Click();
            else
                driver.FindElement(By.CssSelector("#mat-dialog-title-0 > div > button:nth-child(1)")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Validade:'])[1]/following::span[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#generic-modal-data > div.button-configuration.text-center.d-flex.justify-content-center > div:nth-child(2) > button")).Click();
            Thread.Sleep(2000);
        }

        [Then(@"O sistema exibe a mensagem (.*)")]
        public void ThenOSistemaExibeAMensagem(string Mensagem)
        {
            try
            {
                var msg = driver.FindElement(By.CssSelector("#generic-modal-term > div.w-100.text-center.px-4.py-2.message-text.clear.green.ng-star-inserted")).Text;
                Assert.AreEqual(msg, Mensagem);
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#generic-modal-term > div.button-configuration.text-center.d-flex.justify-content-center > button")).Click();
            }
            catch (Exception)
            {
                driver.Close();
                throw;
            }

            driver.Close();
        }


    }



}
