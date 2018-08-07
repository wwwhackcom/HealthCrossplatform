using System;
using System.Collections.Generic;

namespace HealthCrossplatform.Core.Models
{
    public interface IRecipe
    {
        string Name { get; set; }
        string RotationPeriod { get; set; }
        string OrbitalPeriod { get; set; }
        string Diameter { get; set; }
        string Climate { get; set; }
        string Gravity { get; set; }
        string Terrain { get; set; }
        string SurfaceWater { get; set; }
        string Population { get; set; }
        List<string> Residents { get; set; }
        List<string> Films { get; set; }
        string Created { get; set; }
        string Edited { get; set; }
        string Url { get; set; }
    }
}
