using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestingFramework
{
    public interface IPage
    {
        string Url { get; }

        IWebDriver Driver { get; set; }

        void Navigate();

        void Wait();
    }
}
