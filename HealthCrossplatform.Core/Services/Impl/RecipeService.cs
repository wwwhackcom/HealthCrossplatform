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

        public Task<PagedResult<Recipe>> GetRecipesAsync(string url = null)
        {
            //return string.IsNullOrEmpty(url)
                         //? _restClient.MakeApiCall<PagedResult<BaseRecipe>>("/recipes/", HttpMethod.Get)
                             //: _restClient.MakeApiCall<PagedResult<BaseRecipe>>(url, HttpMethod.Get);
            return Task.FromResult(GetMockedRecipes());
        }

        private PagedResult<Recipe> GetMockedRecipes()
        {
            return new PagedResult<Recipe>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<Recipe>
                {
                    new Recipe
                    {
                        Name = "GREEK-STYLE POTATO SALAD",
                        Category = "SALAD",
                        Description = "Here is an easy but super tasty variation to the classic potato salad.",
                        Url = "recipePic1",
                    },
                    new Recipe
                    {
                        Name = "COCONUT & MANGO RED CHICKEN CURRY",
                        Category = "CURRY",
                        Description = "There’s no need to go out for a great Thai curry when creating your own at home is so simple",
                        Url = "recipePic2",
                    },
                    new Recipe
                    {
                        Name = "EASY SUMMER SALAD",
                        Category = "SALAD",
                        Description = "Throw this salad together quickly when you need a perfect entertaining salad. ",
                        Url = "recipePic3",
                    },
                    new Recipe
                    {
                        Name = "CREAMY EGG & WATERCRESS SALAD",
                        Category = "SALAD",
                        Description = "This is our modern take on a curried mayo egg salad.",
                        Url = "recipePic4",
                    },
                    new Recipe
                    {
                        Name = "HONEY MUSTARD CHICKEN & PASTA SALAD",
                        Category = "SALAD",
                        Description = "This is a great salad to rustle up when you have some leftover cooked chicken. ",
                        Url = "recipePic5",
                    }
                }
            };
        }
    }
}
