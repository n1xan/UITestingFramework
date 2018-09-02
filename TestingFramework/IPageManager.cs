using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestingFramework
{
    public interface IPageManager
    {
        IWebDriver Driver { get; set; }

        T GetPage<T>() where T : IPage, new();

        TPage CreatePage<TPage>() where TPage : IPage, new();
    }
}