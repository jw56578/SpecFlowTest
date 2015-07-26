using test.Evolution2.AcceptanceTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace test.SelfServe.AcceptanceTests.Hooks
{
    [Binding]
    public class Step
    {

        [BeforeStep]
        public void BeforeStep()
        {
            if(!FeatureContext.Current.ContainsKey("test.Evolution2.AcceptanceTests.IMethodDecorator"))
                return;
            var md = FeatureContext.Current.Get<IMethodDecorator>();
            if(md != null)
                md.BeforeCall();
        }

        [AfterStep]
        public void AfterStep()
        {
            if (!FeatureContext.Current.ContainsKey("test.Evolution2.AcceptanceTests.IMethodDecorator"))
                return;
            var md = FeatureContext.Current.Get<IMethodDecorator>();
            if (md != null)
                md.AfterCall();
        }
    }
}
