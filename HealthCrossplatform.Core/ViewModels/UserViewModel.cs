using System.Threading.Tasks;
using Acr.UserDialogs;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.ViewModelResults;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace HealthCrossplatform.Core.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;


        public UserViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            AddProgressCommand = new MvxAsyncCommand(AddProgress);
        }

        public override void Prepare()
        {
            
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            return Task.FromResult(0);
        }

        // MVVM Properties

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
