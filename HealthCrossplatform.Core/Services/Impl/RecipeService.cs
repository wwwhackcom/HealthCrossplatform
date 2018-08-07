using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Net;
using HealthCrossplatform.Core.Services.Interface;

namespace HealthCrossplatform.Core.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRestClient _restClient;

        public RecipeService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<PagedResult<BaseRecipe>> GetRecipesAsync(string url = null)
        {


            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<BaseRecipe>>("/recipes/", HttpMethod.Get)
                             : _restClient.MakeApiCall<PagedResult<BaseRecipe>>(url, HttpMethod.Get);
        }

        private PagedResult<IRecipe> GetMockedRecipes()
        {
            return new PagedResult<IRecipe>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<BaseRecipe>
                {
                    new Recipe
                    {
                        Name = "Alderaan",
                        Population = "20000"
                    },
                    new Recipe2
                    {
                        Name = "Crait",
                        Population = "675000"
                    },
                    new Recipe
                    {
                        Name = "Endor",
                        Population = "22130000"
                    }
                }
            };
        }
    }
}
