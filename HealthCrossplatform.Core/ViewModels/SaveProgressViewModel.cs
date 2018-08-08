using System.Threading.Tasks;
using Acr.UserDialogs;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.Services.Interface;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace HealthCrossplatform.Core.ViewModels
{
    public class SaveProgressViewModel : BaseViewModel<User, Result<User>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;

        public SaveProgressViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
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
            var ok = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Save a Progress",
                Message = "Click yes to save this progress?",
                OkText = "YES",
                CancelText = "No"
            });

            if (!ok)
                return;


            await _navigationService.Close(this,
                                           new Result<User>
                                           {
                                               Entity = User,
                                               Responsed = true
                                           });
        }
    }
}
