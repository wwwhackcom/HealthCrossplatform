using System;
using System.Collections.Generic;
using System.Windows.Input;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.iOS.Views.Cells;
using HealthCrossplatform.iOS.Views.Cells.DashboardCell;
using MvvmCross.Binding.Extensions;
using MvvmCross.Exceptions;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace HealthCrossplatform.iOS.Sources
{
    public class DashboardTableViewSource : MvxTableViewSource
    {
        private readonly Dictionary<Type, Type> _itemsTypeDictionary = new Dictionary<Type, Type>
        {
            [typeof(DashboardItem)] = typeof(NameTableViewCell),
            [typeof(DashboardItem2)] = typeof(WhiteNameTableViewCell)
        };

        public ICommand FetchCommand { get; set; }

        public DashboardTableViewSource(UITableView tableView) : base(tableView)
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
