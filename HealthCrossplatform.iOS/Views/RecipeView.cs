using Airbnb.Lottie;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Color.Platforms.Ios;
using MvvmCross.ViewModels;
using HealthCrossplatform.Core;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.Resources;
using HealthCrossplatform.Core.ViewModels;
using HealthCrossplatform.iOS.CustomControls;
using HealthCrossplatform.iOS.Extensions;
using TZStackView;
using UIKit;

namespace HealthCrossplatform.iOS.Views
{
    [MvxChildPresentation]
    public class RecipeView : MvxViewController<RecipeViewModel>
    {
        private const float HEADER_HEIGHT = 160f;

        private UIScrollView _scrollView;
        private UIView _contentView;
        private TwitterCoverImageView _twitterCoverImageView;
        private UILabel _lblCategory;
        private UIView _line;
        private StackView _stackInfo;
        private InfoView _viewName, _viewDesc;
        private UIImageView _imageView;
        private UIButton _btnLike;

        private LOTAnimationView _animation;

        private IMvxInteraction<RecipeAction> _interaction;
        public IMvxInteraction<RecipeAction> Interaction
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

            Title = "Recipe Details";

            View.BackgroundColor = UIColor.Black;

            _scrollView = new UIScrollView();

            _twitterCoverImageView = new TwitterCoverImageView
            {
                CoverViewHeight = HEADER_HEIGHT,
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("recipe_header"),
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
            _lblCategory = new UILabel
            {
                Font = UIFont.SystemFontOfSize(28f, UIFontWeight.Bold),
                TextColor = AppColors.AccentColor.ToNativeColor()
            };

            _viewName = new InfoView();
            _viewName.Label.Text = Strings.Name;

            _viewDesc = new InfoView();
            _viewDesc.Label.Text = Strings.Description;

            _imageView = new UIImageView
            {
                Image = UIImage.FromBundle("recipePic2.jpg")
            };

            _btnLike = new UIButton
            {
                BackgroundColor = UIColor.Red
            };
            _btnLike.Layer.CornerRadius = 8f;
            _btnLike.SetTitle(Strings.Like.ToUpper(), UIControlState.Normal);
            _btnLike.SetTitleColor(UIColor.White, UIControlState.Normal);
            _btnLike.SetTitleColor(UIColor.LightGray, UIControlState.Selected);
            _btnLike.PulseToSize(1.2f, 2f, true, true);

            _animation = LOTAnimationView.AnimationNamed("health");
            _animation.Hidden = true;

            _scrollView.AddSubview(_twitterCoverImageView);

            View.AddSubviews(_scrollView);
            View.AddSubview(_animation);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _scrollView.AddSubviews(_lblCategory, _line, _contentView);
            _scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _contentView.AddSubviews(_stackInfo, _imageView, _btnLike);
            _contentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _stackInfo.AddArrangedSubview(_viewName);
            _stackInfo.AddArrangedSubview(_viewDesc);

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

                _lblCategory.Above(_line, 8f),
                _lblCategory.AtLeftOf(_line, 8f),

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

                _imageView.Below(_stackInfo, 20f),
                _imageView.WithSameCenterX(_contentView),
                _imageView.Width().EqualTo(210f),
                _imageView.Height().EqualTo(90f),

                _btnLike.Below(_imageView, 20f),
                _btnLike.WithSameCenterX(_contentView),
                _btnLike.AtBottomOf(_contentView, 250f),
                _btnLike.Width().EqualTo(120f)
            );

            var set = this.CreateBindingSet<RecipeView, RecipeViewModel>();
            set.Bind(_lblCategory).To(vm => vm.Recipe.Category);
            set.Bind(_viewName.Information).To(vm => vm.Recipe.Name);
            set.Bind(_viewDesc.Information).To(vm => vm.Recipe.Description);
            set.Bind(_btnLike).To(vm => vm.LikeRecipeCommand);
            set.Bind(this).For(v => v.Interaction).To(vm => vm.Interaction);
            set.Apply();
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<RecipeAction> eventArgs)
        {
            _animation.Hidden = false;
            _animation.PlayWithCompletion(
                (animationFinished) =>
            {
                eventArgs.Value.OnLiked();
            });
        }
    }
}
