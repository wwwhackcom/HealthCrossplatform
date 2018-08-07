using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using HealthCrossplatform.Core.ViewModels;

namespace HealthCrossplatform.Core
{
    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication app, IMvxNavigationService mvxNavigationService)
            : base(app, mvxNavigationService)
        {
        }

        protected override void NavigateToFirstViewModel(object hint = null)
        {
            NavigationService.Navigate<HomeViewModel>();
        }
    }
}
