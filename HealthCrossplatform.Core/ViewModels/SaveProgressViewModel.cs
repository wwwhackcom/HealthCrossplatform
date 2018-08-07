using Acr.UserDialogs;
using HealthCrossplatform.Core.Services.Interface;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Navigation;
using System.Threading.Tasks;
using MvvmCross.Commands;
using HealthCrossplatform.Core.MvxInteraction;
using MvvmCross.ViewModels;

namespace HealthCrossplatform.Core.ViewModels
{
    public class SaveProgressViewModel : BaseViewModel<User, UserResult<User>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserService _userService;
        private readonly IUserDialogs _userDialogs;

        public SaveProgressViewModel(IMvxNavigationService navigationService, IUserService userService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _userService = userService;
            _userDialogs = userDialogs;

            SaveProgressCommand = new MvxAsyncCommand(SaveProgress);
        }

        public override void Prepare(User parameter)
        {
            User = parameter;
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

        public MvxInteraction<UserAction> Interaction { get; set; } = new MvxInteraction<UserAction>();

        // MVVM Commands
        public IMvxCommand SaveProgressCommand { get; private set; }

        // Private methods

        private async Task SaveProgress()
        {
            var destroy = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Save a Progress",
                Message = "Click yes to save this progress?",
                OkText = "YES",
                CancelText = "No"
            });

            if (!destroy)
                return;

            var request = new UserAction
            {
                OnResponsed = () => _navigationService.Close(
                    this,
                    new UserResult<User>
                    {
                        Entity = User,
                        Responsed = true
                    })
            };

            Interaction.Raise(request);
        }
    }
}
