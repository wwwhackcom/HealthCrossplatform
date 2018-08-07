using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using OxyPlot.Xamarin.Android;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;

namespace HealthCrossplatform.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.content_frame, true)]
    [Register("healthCrossplatform.droid.views.ProgressView")]
    public class ProgressView : BaseFragment<ProgressViewModel>
    {
        protected override int FragmentId => Resource.Layout.ProgressView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = Strings.Progress;

            var plot = view.FindViewById<PlotView>(Resource.Id.plot_view);
            plot.Model = ViewModel.PlotModel;

            return view;
        }

    }
}
