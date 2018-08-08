using System;
using System.Collections.Generic;

namespace HealthCrossplatform.Core.Models
{
    public interface IRecipe
    {
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        int Level { get; set; }
        string Nutrition { get; set; }
        string Preptime { get; set; }
        string Cooktime { get; set; }
        string Ingredients { get; set; }
        string Methods { get; set; }
        string Created { get; set; }
        string Edited { get; set; }
        string Url { get; set; }
    }
}
