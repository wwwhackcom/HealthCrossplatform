using Android.Animation;
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
    [Register("healthCrossplatform.droid.views.UserView")]
    public class UserView : BaseFragment<UserViewModel>, Animator.IAnimatorListener
    {
        protected override int FragmentId => Resource.Layout.UserView;

        private Android.Support.V7.Widget.Toolbar _toolbar;
        private Button _btnResponse;
        private LottieAnimationView _animationView;

        private UserAction _interactionRequested;

        private IMvxInteraction<UserAction> _interaction;
        public IMvxInteraction<UserAction> Interaction
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
            _btnResponse = view.FindViewById<Button>(Resource.Id.btn_response);
            _animationView = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            _animationView.ImageAssetsFolder = "imgs";
            _animationView.AddAnimatorListener(this);

            _toolbar.SetTitleTextColor(AppColors.AccentColor.ToNativeColor());

            this.AddBindings(_toolbar, "Title Person.Name");
            this.AddBindings(this, "Interaction Interaction");

            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            var myAnimation = AnimationUtils.LoadAnimation(Context, Resource.Animation.pulse_animation);
            _btnResponse.StartAnimation(myAnimation);
        }

        public override void OnPause()
        {
            base.OnPause();

            _btnResponse.ClearAnimation();
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<UserAction> eventArgs)
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
            _interactionRequested?.OnResponsed();
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}
