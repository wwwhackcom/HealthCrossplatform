using System;
namespace HealthCrossplatform.Core.Models
{
    public class BaseDashboardItem : IDashboardItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        
        public string Recommendation { get; set; }
    }
}
