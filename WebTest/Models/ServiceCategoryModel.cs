
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class ServiceCategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Alias { get; set; }

        public List<ServiceModel> Services { get; set; } = new List<ServiceModel>();
    }

    public class ServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
    }
}

