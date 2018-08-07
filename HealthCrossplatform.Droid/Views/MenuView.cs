using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.Graphics.Drawable;
using Android.Views;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace HealthCrossplatform.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.nav_frame)]
    [Register("healthCrossplatform.droid.views.MenuView")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.MenuView, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.nav_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_user).SetChecked(true);

            var iconDashboard = _navigationView.Menu.FindItem(Resource.Id.nav_dashboard);
            iconDashboard.SetTitle(Strings.Dashboard);
            iconDashboard.SetCheckable(false);
            iconDashboard.SetChecked(true);
            iconDashboard.SetIcon(Resource.Drawable.dashboard);

            _previousMenuItem = iconDashboard;

            var iconUser = _navigationView.Menu.FindItem(Resource.Id.nav_user);
            iconUser.SetTitle(Strings.UserProfile);
            iconUser.SetCheckable(false);
            iconUser.SetChecked(true);
            //var imgUser = VectorDrawableCompat.Create(Resources, Resource.Drawable.user, Activity.Theme);
            iconUser.SetIcon(Resource.Drawable.user);

            var iconProgress = _navigationView.Menu.FindItem(Resource.Id.nav_progress);
            iconProgress.SetTitle(Strings.Progress);
            iconProgress.SetCheckable(false);
            iconProgress.SetIcon(Resource.Drawable.progress);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if(_previousMenuItem != null)
                _previousMenuItem.SetChecked(false);

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((HomeView)Activity).DrawerLayout.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch(itemId)
            {
                case Resource.Id.nav_dashboard:
                    ViewModel.ShowDashboardCommand.Execute(null);
                    break;
                case Resource.Id.nav_user:
                    ViewModel.ShowUserCommand.Execute(null);
                    break;
                case Resource.Id.nav_progress:
                    ViewModel.ShowProgressCommand.Execute(null);
                    break;
            }
        }
    }
}
