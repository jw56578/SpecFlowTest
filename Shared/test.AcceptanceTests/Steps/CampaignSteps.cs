using test.SpecFlowPlugin.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace test.Evolution2.AcceptanceTests.Steps
{
    [Binding]
    public class CampaignSteps : Evolution2DefinitionBase
    {
        CampaignContext _campaignContext = null;
        public CampaignSteps(CampaignContext cc,IWebDriverFactory f,IConfiguration config):base(f,config)
        {
            _campaignContext = cc;
        }
        [Given(@"I have a list of campaign step ids for company ""(.*)""")]
        public void GivenIHaveAListOfCampaignStepIdsForCompany(int p0)
        {
            string query = @"select
	            distinct top 100 lDealerPromotionPushID
            from
	            tblTask t with(nolock)
	            inner join 
	            tblTaskItem ti with (nolock) 
	            on t.ltaskid = ti.ltaskid
	            inner join
	            tblDealerPromotionPush DPP WITH(NOLOCK)
	            on dpp.lDealerPromotionPushID = ti.litem
            where
	            t.lcompanyid = @CompanyId
	            and 
	            ti.nlilistitemid = 2182
	            and 
	            t.lTaskTypeID = 26
	            and 
	            DPP.nliPushTypeID = 2286";
            string queryAllCompanies = @"use dbfresh
            select
	            distinct top 400 lDealerPromotionPushID
            from
	            tblTask t with(nolock)
	            inner join 
	            tblTaskItem ti with (nolock) 
	            on t.ltaskid = ti.ltaskid
	            inner join
	            tblDealerPromotionPush DPP WITH(NOLOCK)
	            on dpp.lDealerPromotionPushID = ti.litem
            where
	            --t.lcompanyid = 9713 and 
	            ti.nlilistitemid = 2182 and 
	            t.lTaskTypeID = 26
	            and 
	            DPP.nliPushTypeID = 2286
	            and t.ltaskid > 127101456 - 9999999";
            using (var conn = new eLead.Data.SqlClient.Fresh.dbFreshConnection(p0)) {

                conn.Open();
                using (System.Data.SqlClient.SqlCommand cmd = conn.CreateCommand(query))
                {
                    cmd.Parameters.Add(eLead.Data.SqlClient.DatabaseHelper.CreateParam("@CompanyId", p0));
                    using (eLead.Common.eSafeDataReader reader = new eLead.Common.eSafeDataReader(cmd.ExecuteReader()))
                    {
                        while (reader.Read())
                        {
                            _campaignContext.StepIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            
            }
        }

        [When(@"I navigate to the view campaign step media resource for each of them")]
        public void WhenINavigateToTheViewCampaignStepMediaResourceForEachOfThem()
        {
            foreach(var id in _campaignContext.StepIds)
            {
                Given("I have navigated to the url \"https://www9.eleadcrm.com/evo2/fresh/eLead-V45/elead_track/Campaigns/ViewCampaignStepMedia.aspx?CampaignStepId=" + id + "\"");
                Then("I wait \"1\" seconds until the browser url contains \"CampaignStepId=" + id + "\"");
                var elm = CurrentDriver.GetElementFromActivePage("center");
                if (!elm.Text.Contains("Sample media not found. Please contact support.")) {
                    _campaignContext.StepIdsWithMedia.Add(id); 
                }

     
            }

        }

        [Then(@"every id should return sample media not found")]
        public void ThenEveryIdShouldReturnSampleMediaNotFound()
        {
            Assert.IsTrue(_campaignContext.StepIdsWithMedia.Count == 0);
        }
    }

    public class CampaignContext
    {
        public CampaignContext() {
            StepIds = new List<int>();
            StepIdsWithMedia = new List<int>();
        }
        public List<int> StepIds { get; private set; }
        public List<int> StepIdsWithMedia { get; private set; }
    }
}
