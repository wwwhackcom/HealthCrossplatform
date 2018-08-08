using System;
using System.Collections.Generic;

namespace HealthCrossplatform.Core.Models
{
    public class BaseRecipe : IRecipe
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string Nutrition { get; set; }
        public string Preptime { get; set; }
        public string Cooktime { get; set; }
        public string Ingredients { get; set; }
        public string Methods { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }
    }
}
