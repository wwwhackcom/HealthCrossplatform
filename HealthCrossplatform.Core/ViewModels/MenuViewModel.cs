using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace HealthCrossplatform.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowDashboardCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<DashboardViewModel>());
            ShowUserCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<UserViewModel>());
            ShowProgressCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<ProgressViewModel>());
            ShowRecipesCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<RecipesViewModel>());
            SaveProgressCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<SaveProgressViewModel, User, Result<User>>(null));
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowDashboardCommand { get; private set; }
        public IMvxCommand ShowUserCommand { get; private set; }
        public IMvxCommand ShowProgressCommand { get; private set; }
        public IMvxCommand ShowRecipesCommand { get; private set; }
        public IMvxCommand SaveProgressCommand { get; private set; }

        // Private methods
    }
}
