using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Services.Interface;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace HealthCrossplatform.Core.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserService _userService;

        public UserViewModel(IMvxNavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
            SaveProgressCommand = new MvxAsyncCommand(SaveProgress);
        }

        public override void Prepare()
        {
            _user = _userService.GetLoginedUser();
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            return Task.FromResult(0);
        }

        // MVVM Properties
        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        // MVVM Commands
        public IMvxCommand SaveProgressCommand { get; private set; }

        // Private methods

        private async Task SaveProgress()
        {
            var result = await _navigationService.Navigate<SaveProgressViewModel, User, Result<User>>(User);

            if (result != null)
            {
                User = result.Entity;
            }
        }
    }
}
