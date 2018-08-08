using System;
using HealthCrossplatform.Core.Models;

namespace HealthCrossplatform.Core.Extensions
{
    public static class DashboardItemExtensions
    {
        public static DashboardItem ToItem(this BaseDashboardItem baseDashboardItem)
        {
            return new DashboardItem
            {
                Name = baseDashboardItem.Name,
                Description = baseDashboardItem.Description,
                Status = baseDashboardItem.Status,
                Recommendation = baseDashboardItem.Recommendation
            };
        }

        public static DashboardItem2 ToItem2(this BaseDashboardItem baseDashboardItem)
        {
            return new DashboardItem2
            {
                Name = baseDashboardItem.Name,
                Description = baseDashboardItem.Description,
                Status = baseDashboardItem.Status,
                Recommendation = baseDashboardItem.Recommendation
            };
        }
    }
}
