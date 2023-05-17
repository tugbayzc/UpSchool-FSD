﻿using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using UpSchool.Domain.Dtos;
using Microsoft.AspNetCore.SignalR.Client;

Thread.Sleep(5000);

new DriverManager().SetUpDriver(new ChromeConfig());

IWebDriver driver = new ChromeDriver();

var hubConnection = new HubConnectionBuilder()
            .WithUrl($"http://localhost:7296/Hubs/SeleniumLogHub")
            .WithAutomaticReconnect()
            .Build();
await hubConnection.StartAsync();

try
{
    await hubConnection.InvokeAsync<bool>("SendLogNotificationAsync", CreateLog("Bot started"));

    driver.Navigate().GoToUrl("https://www.google.com/");

    // We are waiting for fun. 
    Thread.Sleep(1500);

    IWebElement searchBox = driver.FindElement(By.Name("q"));
    searchBox.SendKeys("UpSchool");
    searchBox.Submit();

    // We are waiting for the results to load.
    Thread.Sleep(3000);

    // // UP School.io is the first result we want to click on.
    IWebElement firstResult = driver.FindElements(By.CssSelector("div.g")).FirstOrDefault();
    if (firstResult != null)
    {
        IWebElement link = firstResult.FindElement(By.TagName("a"));
        link.Click();
    }
    else
    {
        Console.WriteLine("No search results found.");
    }

    Console.ReadKey();


    driver.Quit();
}
catch (Exception exception)
{
    driver.Quit();
}

SeleniumLogDto CreateLog(string message) => new SeleniumLogDto(message);  

