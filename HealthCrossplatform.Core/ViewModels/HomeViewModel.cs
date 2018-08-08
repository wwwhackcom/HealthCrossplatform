using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace HealthCrossplatform.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowUserViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<UserViewModel>());
            ShowMenuViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MenuViewModel>());
            ShowDashboardViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<DashboardViewModel>());
            ShowRecipesViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<RecipesViewModel>());
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxAsyncCommand ShowDashboardViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowUserViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowMenuViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowRecipesViewModelCommand { get; private set; }


        // Private methods
    }
}
