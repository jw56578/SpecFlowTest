using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.Evolution2.AcceptanceTests
{
    public interface IConfiguration
    {
        string RootUrl { get; set; }
    }

    public class DevConfiguration : IConfiguration
    {
        public DevConfiguration()
        {
            RootUrl  = "http://localhost/evolution2/fresh/";
        }

        public string RootUrl
        {
            get;
            set;
        }
    }
    public class TestConfiguration : IConfiguration
    {
        public TestConfiguration()
        {
            RootUrl = "https://test.eleadcrm.com/i53/fresh/";
        }

        public string RootUrl
        {
            get;
            set;
        }
    }
     public class ProdConfiguration : IConfiguration
    {
        public ProdConfiguration()
        {
            RootUrl = "https://www.eleadcrm.com/evo2/fresh/";
        }

        public string RootUrl
        {
            get;
            set;
        }
    }

}
