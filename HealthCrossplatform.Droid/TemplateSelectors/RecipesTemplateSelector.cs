using System;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using HealthCrossplatform.Core.Models;

namespace HealthCrossplatform.Droid.TemplateSelectors
{
    public class RecipesTemplateSelector : IMvxTemplateSelector
    {
        private readonly Dictionary<Type, int> _itemsTypeDictionary = new Dictionary<Type, int>
        {
            [typeof(Recipe)] = Resource.Layout.item_name,
            [typeof(Recipe2)] = Resource.Layout.item_name_white
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
