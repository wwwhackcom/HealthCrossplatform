﻿using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
using HealthCrossplatform.iOS.CustomControls;
using TZStackView;
using UIKit;

namespace HealthCrossplatform.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Menu", TabIconName = "ic_menu")]
    public class MenuView : MvxViewController<MenuViewModel>
    {
        private const float PROFILE_IMAGE_SIZE = 80f;

        private UIImageView _imgBackground;
        private StackView _options;

        private UIView _lineHeaderTop, _lineHeaderBottom;
        private UIImageView _imgHeaderBackground, _imgHeaderProfile;
        private UILabel _lblHeaderName;

        private MenuOption _optionProgress, _optionAddProgress;

        public MenuView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Black;

            Title = Strings.Menu;

            _imgBackground = new UIImageView(UIImage.FromBundle("Background.jpg"))
            {
                
            };

            _options = new StackView
            {
                Axis = UILayoutConstraintAxis.Vertical
            };

            _lineHeaderTop = new UIView { BackgroundColor = UIColor.White };
            _lineHeaderBottom = new UIView { BackgroundColor = UIColor.White };
            _imgHeaderBackground = new UIImageView(UIImage.FromBundle("menu_header_background"))
            {
                
            };
            _imgHeaderProfile = new UIImageView(UIImage.FromBundle("profile"))
            {
                BackgroundColor = UIColor.Black,
                ContentMode = UIViewContentMode.ScaleAspectFit,
                ClipsToBounds = true
            };
            _imgHeaderProfile.Layer.CornerRadius = PROFILE_IMAGE_SIZE / 2;
            _lblHeaderName = new UILabel
            {
                Font = UIFont.SystemFontOfSize(22f, UIFontWeight.Bold),
                TextColor = UIColor.White,
                Text = "Nick W"
            };

            _optionProgress = new MenuOption();
            _optionProgress.ImageView.Image = UIImage.FromBundle("ic_progress");
            _optionProgress.Label.Text = Strings.Progress;
            _optionAddProgress = new MenuOption();
            _optionAddProgress.ImageView.Image = UIImage.FromBundle("ic_user");
            _optionAddProgress.Label.Text = Strings.AddProgress;

            View.AddSubviews(_imgBackground, _lineHeaderTop, _imgHeaderBackground, _lineHeaderBottom, _imgHeaderProfile, _lblHeaderName, _options);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _options.AddArrangedSubview(_optionProgress);
            _options.AddArrangedSubview(_optionAddProgress);

            View.AddConstraints(
                _imgBackground.AtLeftOf(View),
                _imgBackground.AtTopOf(View),
                _imgBackground.AtBottomOf(View),
                _imgBackground.AtRightOf(View),

                _lineHeaderTop.AtLeftOf(View),
                _lineHeaderTop.AtTopOf(View),
                _lineHeaderTop.AtRightOf(View),
                _lineHeaderTop.Height().EqualTo(.5f),

                _imgHeaderBackground.Below(_lineHeaderTop),
                _imgHeaderBackground.AtLeftOf(View),
                _imgHeaderBackground.AtRightOf(View),
                _imgHeaderBackground.Height().EqualTo(180f),

                _lineHeaderBottom.Below(_imgHeaderBackground),
                _lineHeaderBottom.AtLeftOf(View),
                _lineHeaderBottom.AtRightOf(View),
                _lineHeaderBottom.Height().EqualTo(.5f),

                _imgHeaderProfile.WithSameCenterX(_imgHeaderBackground),
                _imgHeaderProfile.WithSameCenterY(_imgHeaderBackground).Minus(20f),
                _imgHeaderProfile.Width().EqualTo(PROFILE_IMAGE_SIZE),
                _imgHeaderProfile.Height().EqualTo(PROFILE_IMAGE_SIZE),

                _lblHeaderName.WithSameCenterX(_imgHeaderBackground),
                _lblHeaderName.Below(_imgHeaderProfile),

                _options.Below(_lineHeaderBottom),
                _options.AtLeftOf(View),
                _options.AtRightOf(View)
            );

            var set = this.CreateBindingSet<MenuView, MenuViewModel>();
            set.Bind(_optionProgress.Tap()).For(g => g.Command).To(vm => vm.ShowProgressCommand);
            set.Bind(_optionAddProgress.Tap()).For(g => g.Command).To(vm => vm.SaveProgressCommand);
            set.Apply();
        }
    }
}
