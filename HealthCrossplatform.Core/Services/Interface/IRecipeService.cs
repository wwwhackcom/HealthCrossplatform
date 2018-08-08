using System;
using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;

namespace HealthCrossplatform.Core.Services.Interface
{
    public interface IRecipeService
    {
        Task<PagedResult<Recipe>> GetRecipesAsync(string url = null);
    }
}
