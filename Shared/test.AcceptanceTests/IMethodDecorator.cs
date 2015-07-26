using test.SpecFlowPlugin.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.Evolution2.AcceptanceTests
{
    public interface IMethodParameters
    {
        string Url{get;set;}
        string CssSelector{get;set;}
    }
    public interface IMethodDecorator
    {
        void After(IMethodParameters mp);
        void Before(IMethodParameters mp);
        void BeforeCall();
        void AfterCall();
    }

    public class MethodParameters : IMethodParameters
    {
        public string Url { get; set; }
        public string CssSelector { get; set; }
    }
    public class MethodDecorator :  IMethodDecorator
    {

        public void After(IMethodParameters mp)
        {
            
        }

        public void Before(IMethodParameters mp)
        {
            if (!string.IsNullOrEmpty(mp.CssSelector))
                new StepDefinitionProxy().Driver.ScrollElementIntoView(mp.CssSelector);
        }


        public void BeforeCall()
        {
           
        }

        public void AfterCall()
        {
            
        }
    }

    public class StepDefinitionProxy : StepDefinitionBase
    { 
        public StepDefinitionProxy():base(new WebDriverFactory())
        {
        }
        public IWebDriver Driver
        {
            get { return StepDefinitionBase.CurrentDriver; }
        }

     
    }

}
