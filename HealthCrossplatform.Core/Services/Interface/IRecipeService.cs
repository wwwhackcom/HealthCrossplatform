using System;
using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;

namespace HealthCrossplatform.Core.Services.Interface
{
    public interface IRecipeService
    {
        Task<PagedResult<BaseRecipe>> GetRecipesAsync(string url = null);
    }
}
