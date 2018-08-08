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
                Name = baseRecipe.Name,
                Category = baseRecipe.Category,
                Description = baseRecipe.Description,
                Level = baseRecipe.Level,
                Nutrition = baseRecipe.Nutrition,
                Preptime = baseRecipe.Preptime,
                Cooktime = baseRecipe.Cooktime,
                Ingredients = baseRecipe.Ingredients,
                Methods = baseRecipe.Methods,
                Created = baseRecipe.Created,
                Edited = baseRecipe.Edited
            };
        }

        public static Recipe2 ToRecipe2(this BaseRecipe baseRecipe)
        {
            return new Recipe2
            {
                Name = baseRecipe.Name,
                Category = baseRecipe.Category,
                Description = baseRecipe.Description,
                Level = baseRecipe.Level,
                Nutrition = baseRecipe.Nutrition,
                Preptime = baseRecipe.Preptime,
                Cooktime = baseRecipe.Cooktime,
                Ingredients = baseRecipe.Ingredients,
                Methods = baseRecipe.Methods,
                Created = baseRecipe.Created,
                Edited = baseRecipe.Edited
            };
        }
    }
}
