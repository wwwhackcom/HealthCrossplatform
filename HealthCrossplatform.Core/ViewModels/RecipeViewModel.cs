using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.Services.Interface;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Commands;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace HealthCrossplatform.Core.ViewModels
{
    public class RecipeViewModel : BaseViewModel<Recipe, Result<Recipe>>
    {
        private readonly IMvxNavigationService _navigationService;

        public RecipeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            LikeRecipeCommand = new MvxAsyncCommand(LikeRecipe);
        }

        // MvvmCross Lifecycle
        public override void Prepare(Recipe parameter)
        {
            Recipe = parameter;
        }

        public override Task Initialize()
        {
            return Task.FromResult(0);
        }

        // MVVM Properties

        private IRecipeService _recipeService;
        [MvxInject]
        public IRecipeService RecipeService
        {
            get => _recipeService;
            set => _recipeService = value;
        }

        private Recipe _recipe;
        public Recipe Recipe
        {
            get
            {
                return _recipe;
            }
            set
            {
                _recipe = value;
                RaisePropertyChanged(() => Recipe);
            }
        }

        public MvxInteraction<RecipeAction> Interaction { get; set; } = new MvxInteraction<RecipeAction>();

        // MVVM Commands
        public IMvxCommand LikeRecipeCommand { get; private set; }

        // Private methods
        private Task LikeRecipe()
        {
            var request = new RecipeAction
            {
                OnLiked = () => _navigationService.Close(
                    this,
                    new Result<Recipe>
                    {
                        Entity = Recipe,
                        Responsed = true
                    })
            };

            Interaction.Raise(request);
            return Task.FromResult(0);
        }
    }
}
