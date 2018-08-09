using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.FluentLayouts.Touch;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
using HealthCrossplatform.iOS.Sources;
using HealthCrossplatform.iOS.Views.Cells;
using HealthCrossplatform.iOS.Views.Cells.RecipeCell;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Extensions;
using MvvmCross.Exceptions;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace HealthCrossplatform.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Dashboard", TabIconName = "ic_dashboard")]
    public class DashboardView : MvxViewController<DashboardViewModel>
    {
        private UIImageView _imgBackground;
        private MvxUIRefreshControl _refreshControl;
        private UITableView _tableView;
        private DashboardTableViewSource _source;

        public DashboardView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = Strings.Dashboard;

            EdgesForExtendedLayout = UIRectEdge.None;

            View.BackgroundColor = UIColor.Clear;

            _refreshControl = new MvxUIRefreshControl();

            _tableView = new UITableView();
            _tableView.BackgroundColor = UIColor.Clear;
            _tableView.RowHeight = UITableView.AutomaticDimension;
            _tableView.EstimatedRowHeight = 44f;
            _tableView.AddSubview(_refreshControl);

            _imgBackground = new UIImageView(UIImage.FromBundle("Background.jpg"))
            {
                ContentMode = UIViewContentMode.ScaleAspectFill
            };

            _source = new DashboardTableViewSource(_tableView);
            _tableView.Source = _source;

            View.AddSubviews(_tableView, _imgBackground);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _imgBackground.AtLeftOf(View),
                _imgBackground.AtTopOf(View),
                _imgBackground.AtBottomOf(View),
                _imgBackground.AtRightOf(View),

                _tableView.AtLeftOf(View),
                _tableView.AtTopOf(View),
                _tableView.AtBottomOf(View),
                _tableView.AtRightOf(View)
            );

            View.BringSubviewToFront(_tableView);

            var set = this.CreateBindingSet<DashboardView, DashboardViewModel>();
            set.Bind(this).For("NetworkIndicator").To(vm => vm.FetchItemsTask.IsNotCompleted).WithFallback(false);
            set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.LoadItemsTask.IsNotCompleted).WithFallback(false);
            set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.RefreshItemsCommand);
            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.DashboardItems);
            set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchItemsCommand);
            set.Apply();
        }
    }
}
