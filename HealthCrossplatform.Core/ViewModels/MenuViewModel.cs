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
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowDashboardCommand { get; private set; }
        public IMvxCommand ShowUserCommand { get; private set; }
        public IMvxCommand ShowProgressCommand { get; private set; }
        public IMvxCommand ShowRecipesCommand { get; private set; }

        // Private methods
    }
}
