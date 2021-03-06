﻿using Android.Animation;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Airbnb.Lottie;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Plugin.Color.Platforms.Android;
using MvvmCross.ViewModels;
using HealthCrossplatform.Core;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.ViewModels;

namespace HealthCrossplatform.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.content_frame, true)]
    [Register("healthCrossplatform.droid.views.SaveProgressView")]
    public class SaveProgressView : BaseFragment<SaveProgressViewModel>
    {
        protected override int FragmentId => Resource.Layout.SaveProgressView;

        private Android.Support.V7.Widget.Toolbar _toolbar;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar1);


            _toolbar.SetTitleTextColor(AppColors.AccentColor.ToNativeColor());

            this.AddBindings(_toolbar, "Title User.Name");


            return view;
        }


    }
}
