using System;
using System.Collections.Generic;
using HealthCrossplatform.Core.Models;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace HealthCrossplatform.Droid.TemplateSelectors
{
    public class DashboardTemplateSelector : IMvxTemplateSelector
    {
        private readonly Dictionary<Type, int> _itemsTypeDictionary = new Dictionary<Type, int>
        {
            [typeof(DashboardItem)] = Resource.Layout.item_name,
            [typeof(DashboardItem2)] = Resource.Layout.item_name_white
        };

        public int ItemTemplateId { get; set; }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        public int GetItemViewType(object forItemObject)
        {
            return _itemsTypeDictionary[forItemObject.GetType()];
        }
    }
}
