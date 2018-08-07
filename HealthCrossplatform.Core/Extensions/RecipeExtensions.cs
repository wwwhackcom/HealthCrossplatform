using System;
using HealthCrossplatform.Core.Models;

namespace HealthCrossplatform.Core.Extensions
{
    public static class RecipeExtensions
    {
        public static Recipe ToRecipe(this BaseRecipe baseRecipe)
        {
            return new Recipe
            {
                Climate = baseRecipe.Climate,
                Created = baseRecipe.Created,
                Diameter = baseRecipe.Diameter,
                Edited = baseRecipe.Edited,
                Films = baseRecipe.Films,
                Gravity = baseRecipe.Gravity,
                Name = baseRecipe.Name,
                OrbitalPeriod = baseRecipe.OrbitalPeriod,
                Population = baseRecipe.Population,
                Residents = baseRecipe.Residents,
                RotationPeriod = baseRecipe.RotationPeriod,
                SurfaceWater = baseRecipe.SurfaceWater,
                Terrain = baseRecipe.Terrain,
                Url = baseRecipe.Url
            };
        }

        public static Recipe2 ToRecipe2(this BaseRecipe baseRecipe)
        {
            return new Recipe2
            {
                Climate = baseRecipe.Climate,
                Created = baseRecipe.Created,
                Diameter = baseRecipe.Diameter,
                Edited = baseRecipe.Edited,
                Films = baseRecipe.Films,
                Gravity = baseRecipe.Gravity,
                Name = baseRecipe.Name,
                OrbitalPeriod = baseRecipe.OrbitalPeriod,
                Population = baseRecipe.Population,
                Residents = baseRecipe.Residents,
                RotationPeriod = baseRecipe.RotationPeriod,
                SurfaceWater = baseRecipe.SurfaceWater,
                Terrain = baseRecipe.Terrain,
                Url = baseRecipe.Url
            };
        }
    }
}
