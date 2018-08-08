using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Color.Platforms.Ios;
using HealthCrossplatform.Core;
using HealthCrossplatform.Core.ViewModels;

namespace HealthCrossplatform.iOS.Views
{
    [MvxRootPresentation]
    public class HomeView : MvxTabBarViewController<HomeViewModel>
    {
        private bool _firstTimePresented = true;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TabBar.BarTintColor = AppColors.PrimaryColor.ToNativeColor();
            TabBar.TintColor = AppColors.AccentColor.ToNativeColor();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (_firstTimePresented)
            {
                _firstTimePresented = false;
                //ViewModel.ShowDashboardViewModelCommand.Execute(null);
                ViewModel.ShowMenuViewModelCommand.Execute(null);
                //ViewModel.ShowUserViewModelCommand.Execute(null);
                //ViewModel.ShowRecipesViewModelCommand.Execute(null);
            }
        }
    }
}
