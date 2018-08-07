using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using HealthCrossplatform.Droid.Extensions;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace HealthCrossplatform.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.content_frame, false)]
    [Register("healthCrossplatform.droid.views.DashboardView")]
    public class DashboardView : BaseFragment<DashboardViewModel>
    {
        protected override int FragmentId => Resource.Layout.DashboardView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = Strings.Dashboard;

            var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recipes_recycler_view);
            if (recyclerView != null)
            {
                recyclerView.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);

                recyclerView.AddOnScrollFetchItemsListener(layoutManager, () => ViewModel.FetchRecipesTask, () => ViewModel.FetchRecipeCommand);
            }

            return view;
        }
    }
}
