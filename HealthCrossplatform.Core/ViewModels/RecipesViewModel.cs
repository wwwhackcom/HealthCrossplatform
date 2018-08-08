using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCrossplatform.Core.Extensions;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Services.Interface;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

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

            Recipes = new MvxObservableCollection<Recipe>();

            RecipeSelectedCommand = new MvxAsyncCommand<Recipe>(RecipeSelected);
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

        private MvxObservableCollection<Recipe> _recipes;
        public MvxObservableCollection<Recipe> Recipes
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
        public IMvxCommand<Recipe> RecipeSelectedCommand { get; private set; }

        public IMvxCommand FetchRecipeCommand { get; private set; }

        public IMvxCommand RefreshRecipesCommand { get; private set; }

        // Private methods
        private async Task LoadRecipes()
        {
            var result = await _recipeService.GetRecipesAsync(_nextPage);
            if (string.IsNullOrEmpty(_nextPage))
            {
                Recipes.Clear();
            }
            Recipes.AddRange(result.Results);

            _nextPage = result.Next;
        }

        private async Task RecipeSelected(Recipe selectedRecipe)
        {
            var result = await _navigationService.Navigate<RecipeViewModel, Recipe, Result<Recipe>>(selectedRecipe);

            if (result != null && result.Responsed)
            {
                var recipe = Recipes.FirstOrDefault(p => p.Name == result.Entity.Name);
                if (recipe != null)
                    Recipes.Remove(recipe);
            }
        }

        private void RefreshRecipes()
        {
            _nextPage = null;

            LoadRecipesTask = MvxNotifyTask.Create(LoadRecipes);
            RaisePropertyChanged(() => LoadRecipesTask);
        }
    }
}
