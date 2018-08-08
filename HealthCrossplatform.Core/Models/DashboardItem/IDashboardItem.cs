using System;
using System.Collections.Generic;

namespace HealthCrossplatform.Core.Models
{
    public interface IDashboardItem
    {
        string Name { get; set; }

        string Description { get; set; }

        string Status { get; set; }

        string Recommendation { get; set; }
    }
}
