using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.FluentLayouts.Touch;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
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
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Recipes", TabIconName = "ic_recipes")]
    public class RecipesView : MvxViewController<RecipesViewModel>
    {
        private UIImageView _imgBackground;
        private MvxUIRefreshControl _refreshControl;
        private UITableView _tableView;
        private RecipeTableSource _source;

        public RecipesView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = Strings.Recipes;

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

            _source = new RecipeTableSource(_tableView);
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

            var set = this.CreateBindingSet<RecipesView, RecipesViewModel>();
            set.Bind(this).For("NetworkIndicator").To(vm => vm.FetchRecipesTask.IsNotCompleted).WithFallback(false);
            set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.LoadRecipesTask.IsNotCompleted).WithFallback(false);
            set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.RefreshRecipesCommand);
            set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Recipes);
            set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.RecipeSelectedCommand);
            set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchRecipeCommand);
            set.Apply();
        }

        public class RecipeTableSource : MvxTableViewSource
        {
            private readonly Dictionary<Type, Type> _itemsTypeDictionary = new Dictionary<Type, Type>
            {
                [typeof(Recipe)] = typeof(RecipeTableViewCell)
            };

            public ICommand FetchCommand { get; set; }

            public RecipeTableSource(UITableView tableView) : base(tableView)
            {
                RegisterCellsForReuse();

                DeselectAutomatically = true;
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
            {
                Type cellType = null;
                if (!_itemsTypeDictionary.TryGetValue(item.GetType(), out cellType))
                    throw new MvxException($"Type {item.GetType().Name} is not registered as cell. Please override RegisterCellsForReuse");

                var cell = this.TableView.DequeueReusableCell(cellType.Name, indexPath) as BaseTableViewCell;

                if (indexPath.Item == ItemsSource.Count() - 5)
                    FetchCommand?.Execute(null);

                return cell;
            }

            private void RegisterCellsForReuse()
            {
                foreach (var type in _itemsTypeDictionary.Values)
                {
                    TableView.RegisterClassForCellReuse(type, type.Name);
                }
            }
        }
    }
}
