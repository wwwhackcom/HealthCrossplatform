using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using HealthCrossplatform.Core.Services.Interface;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Extensions;

namespace HealthCrossplatform.Core.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IMvxNavigationService _navigationService;

        private string _nextPage;

        public RecipesViewModel(
            IRecipeService recipeService,
            IMvxNavigationService navigationService)
        {
            _recipeService = recipeService;
            _navigationService = navigationService;

            Recipes = new MvxObservableCollection<IRecipe>();

            RecipeSelectedCommand = new MvxAsyncCommand<IRecipe>(RecipeSelected);
            FetchRecipeCommand = new MvxCommand(
                () =>
            {
                if (!string.IsNullOrEmpty(_nextPage))
                {
                    FetchRecipesTask = MvxNotifyTask.Create(LoadRecipes);
                    RaisePropertyChanged(() => FetchRecipesTask);
                }
            });
            RefreshRecipesCommand = new MvxCommand(RefreshRecipes);
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadRecipesTask = MvxNotifyTask.Create(LoadRecipes);

            return Task.FromResult(0);
        }

        // MVVM Properties
        public MvxNotifyTask LoadRecipesTask { get; private set; }

        public MvxNotifyTask FetchRecipesTask { get; private set; }

        private MvxObservableCollection<IRecipe> _recipes;
        public MvxObservableCollection<IRecipe> Recipes
        {
            get
            {
                return _recipes;
            }
            set
            {
                _recipes = value;
                RaisePropertyChanged(() => Recipes);
            }
        }

        // MVVM Commands
        public IMvxCommand<IRecipe> RecipeSelectedCommand { get; private set; }

        public IMvxCommand FetchRecipeCommand { get; private set; }

        public IMvxCommand RefreshRecipesCommand { get; private set; }

        // Private methods
        private async Task LoadRecipes()
        {
            var result = await _recipeService.GetRecipesAsync(_nextPage);

            List<IRecipe> recipesToAdd = new List<IRecipe>();
            for (int i = 0; i < result.Results.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    recipesToAdd.Add(result.Results.ElementAt(i).ToRecipe());
                }
                else
                {
                    recipesToAdd.Add(result.Results.ElementAt(i).ToRecipe2());
                }
            }

            if (string.IsNullOrEmpty(_nextPage))
            {
                Recipes.Clear();
            }
            Recipes.AddRange(recipesToAdd);

            _nextPage = result.Next;
        }

        private async Task RecipeSelected(IRecipe selectedRecipe)
        {
            //var result = await _navigationService.Navigate<RecipeViewModel, IRecipe, UserResult<IRecipe>>(selectedRecipe);

            //if (result != null && result.Responsed)
            //{
            //    var recipe = Recipes.FirstOrDefault(p => p.Name == result.Entity.Name);
            //    if (recipe != null)
            //        Recipes.Remove(recipe);
            //}
        }

        private void RefreshRecipes()
        {
            _nextPage = null;

            LoadRecipesTask = MvxNotifyTask.Create(LoadRecipes);
            RaisePropertyChanged(() => LoadRecipesTask);
        }
    }
}
