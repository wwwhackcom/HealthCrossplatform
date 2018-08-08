using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Services.Interface;
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
            AddProgressCommand = new MvxAsyncCommand(AddProgress);
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
        public IMvxCommand AddProgressCommand { get; private set; }

        // Private methods

        private async Task AddProgress()
        {
            //var result = await _navigationService.Navigate<AddRecordViewModel, User, UserResult<User>>(null);

            //if (result != null && result.Responsed)
            //{
                
            //}
        }
    }
}
