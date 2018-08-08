using Android.Animation;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Airbnb.Lottie;
using HealthCrossplatform.Core;
using HealthCrossplatform.Core.MvxInteraction;
using HealthCrossplatform.Core.ViewModels;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Plugin.Color.Platforms.Android;
using MvvmCross.ViewModels;

namespace HealthCrossplatform.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.content_frame, true)]
    [Register("healthCrossplatform.droid.views.RecipeView")]
    public class RecipeView : BaseFragment<RecipeViewModel>, Animator.IAnimatorListener
    {
        protected override int FragmentId => Resource.Layout.RecipeView;

        private Android.Support.V7.Widget.Toolbar _toolbar;
        private Button _btnLike;
        private ImageView _imgRecipe;
        private LottieAnimationView _animationView;

        private RecipeAction _interactionRequested;

        private IMvxInteraction<RecipeAction> _interaction;
        public IMvxInteraction<RecipeAction> Interaction
        {
            get => _interaction;
            set
            {
                if(_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _btnLike = view.FindViewById<Button>(Resource.Id.btn_like);
            //_imgRecipe = view.FindViewById<ImageView>(Resource.Id.img_recipe);
            _animationView = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            _animationView.ImageAssetsFolder = "imgs";
            _animationView.AddAnimatorListener(this);

            _toolbar.SetTitleTextColor(AppColors.AccentColor.ToNativeColor());

            this.AddBindings(_toolbar, "Title Recipe.Category");
            //this.AddBindings(_imgRecipe, "Drawable Recipe.Url");
            this.AddBindings(this, "Interaction Interaction");

            return view;
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<RecipeAction> eventArgs)
        {
            _animationView.Visibility = ViewStates.Visible;
            _animationView.Progress = 0;
            _animationView.PlayAnimation();

            _interactionRequested = eventArgs.Value;
        }

        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            _interactionRequested?.OnLiked();
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}
