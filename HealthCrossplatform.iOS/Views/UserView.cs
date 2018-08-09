﻿using Airbnb.Lottie;
using Cirrious.FluentLayouts.Touch;
using HealthCrossplatform.Core;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
using HealthCrossplatform.iOS.CustomControls;
using HealthCrossplatform.iOS.Extensions;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Color.Platforms.Ios;
using MvvmCross.ViewModels;
using TZStackView;
using UIKit;

namespace HealthCrossplatform.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "User", TabIconName = "ic_user")]
    public class UserView : MvxViewController<UserViewModel>
    {
        private const float HEADER_HEIGHT = 160f;

        private UIScrollView _scrollView;
        private UIView _contentView;
        private TwitterCoverImageView _twitterCoverImageView;
        private UILabel _lblName;
        private UIView _line;
        private StackView _stackInfo;
        private InfoView _viewHeight, _viewWeight, _viewWaist, _viewEmail, _viewBirth, _viewGender;
        private UIButton _btnAdd;

        private LOTAnimationView _animation;

        private IMvxInteraction<UserAction> _interaction;
        public IMvxInteraction<UserAction> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = Strings.UserProfile;

            View.BackgroundColor = UIColor.Black;

            _scrollView = new UIScrollView();

            _twitterCoverImageView = new TwitterCoverImageView
            {
                CoverViewHeight = HEADER_HEIGHT,
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("user_header"),
                ScrollView = _scrollView
            };

            _line = new UIView
            {
                BackgroundColor = UIColor.LightGray
            };

            _contentView = new UIView();

            _stackInfo = new StackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 8f
            };
            _lblName = new UILabel
            {
                Font = UIFont.SystemFontOfSize(28f, UIFontWeight.Bold),
                TextColor = AppColors.AccentColor.ToNativeColor()
            };

            _viewHeight = new InfoView();
            _viewHeight.Label.Text = Strings.Height;

            _viewWeight = new InfoView();
            _viewWeight.Label.Text = Strings.Weight;

            _viewWaist = new InfoView();
            _viewWaist.Label.Text = Strings.Waist;

            _viewEmail = new InfoView();
            _viewEmail.Label.Text = Strings.Email;

            _viewBirth = new InfoView();
            _viewBirth.Label.Text = Strings.Birth;

            _viewGender = new InfoView();
            _viewGender.Label.Text = Strings.Gender;

            _btnAdd = new UIButton
            {
                BackgroundColor = UIColor.Red
            };
            _btnAdd.Layer.CornerRadius = 8f;
            _btnAdd.SetTitle(Strings.AddProgress.ToUpper(), UIControlState.Normal);
            _btnAdd.SetTitleColor(UIColor.White, UIControlState.Normal);
            _btnAdd.SetTitleColor(UIColor.LightGray, UIControlState.Selected);
            _btnAdd.PulseToSize(1.2f, 2f, true, true);

            _animation = LOTAnimationView.AnimationNamed("health");
            _animation.Hidden = true;

            _scrollView.AddSubview(_twitterCoverImageView);

            View.AddSubviews(_scrollView);
            View.AddSubview(_animation);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _scrollView.AddSubviews(_lblName, _line, _contentView);
            _scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _contentView.AddSubviews(_stackInfo, _btnAdd);
            _contentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _stackInfo.AddArrangedSubview(_viewEmail);
            _stackInfo.AddArrangedSubview(_viewHeight);
            _stackInfo.AddArrangedSubview(_viewWeight);
            _stackInfo.AddArrangedSubview(_viewWaist);
            _stackInfo.AddArrangedSubview(_viewBirth);
            _stackInfo.AddArrangedSubview(_viewGender);

            View.AddConstraints(
                _scrollView.AtLeftOf(View),
                _scrollView.AtTopOf(View),
                _scrollView.AtRightOf(View),
                _scrollView.AtBottomOf(View),

                _animation.AtLeftOf(View),
                _animation.AtTopOf(View),
                _animation.AtRightOf(View),
                _animation.AtBottomOf(View)
            );

            _scrollView.AddConstraints(
                _line.AtTopOf(_scrollView, HEADER_HEIGHT),
                _line.AtLeftOf(_scrollView),
                _line.AtRightOf(_scrollView),
                _line.Height().EqualTo(.5f),

                _lblName.Above(_line, 8f),
                _lblName.AtLeftOf(_line, 8f),

                _contentView.Below(_line),
                _contentView.AtLeftOf(_scrollView),
                _contentView.AtRightOf(_scrollView),
                _contentView.AtBottomOf(_scrollView)
            );

            View.AddConstraints(
                _contentView.WithSameWidth(View)
            );

            _contentView.AddConstraints(
                _stackInfo.AtTopOf(_contentView),
                _stackInfo.AtLeftOf(_contentView),
                _stackInfo.AtRightOf(_contentView),

                _btnAdd.Below(_stackInfo, 20f),
                _btnAdd.WithSameCenterX(_contentView),
                _btnAdd.AtBottomOf(_contentView, 300f),
                _btnAdd.Width().EqualTo(200f)
            );

            var set = this.CreateBindingSet<UserView, UserViewModel>();

            set.Bind(_lblName).To(vm => vm.User.Username);
            set.Bind(_viewHeight.Information).To(vm => vm.User.UserInfo.Height);
            set.Bind(_viewHeight).For("Visibility").To(vm => vm.User.UserInfo.Height).WithConversion("Visibility");

            set.Bind(_viewWeight.Information).To(vm => vm.User.UserInfo.InitialWeight);
            set.Bind(_viewWeight).For("Visibility").To(vm => vm.User.UserInfo.InitialWeight).WithConversion("Visibility");

            set.Bind(_viewWaist.Information).To(vm => vm.User.UserInfo.InitialWaist);
            set.Bind(_viewWaist).For("Visibility").To(vm => vm.User.UserInfo.InitialWaist).WithConversion("Visibility");

            set.Bind(_viewEmail.Information).To(vm => vm.User.Emailaddress);
            set.Bind(_viewEmail).For("Visibility").To(vm => vm.User.Emailaddress).WithConversion("Visibility");

            set.Bind(_viewBirth.Information).To(vm => vm.User.UserInfo.DOB);
            set.Bind(_viewBirth).For("Visibility").To(vm => vm.User.UserInfo.DOB).WithConversion("Visibility");

            set.Bind(_viewGender.Information).To(vm => vm.User.UserInfo.Gender);
            set.Bind(_viewGender).For("Visibility").To(vm => vm.User.UserInfo.Gender).WithConversion("Visibility");

            set.Bind(_btnAdd).To(vm => vm.SaveProgressCommand);

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(true, false);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NavigationController.SetNavigationBarHidden(false, false);
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<UserAction> eventArgs)
        {
            _animation.Hidden = false;
            _animation.PlayWithCompletion(
                (animationFinished) =>
            {
                eventArgs.Value.OnResponsed();
            });
        }
    }
}
