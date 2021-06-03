using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DelicioTests.PageObjects
{
    class LocationPage
    {
        private IWebDriver driver;
        public LocationPage(IWebDriver browser)
        {
            driver = browser;
        }


    }
}
