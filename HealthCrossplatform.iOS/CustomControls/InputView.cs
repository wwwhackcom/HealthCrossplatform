using Cirrious.FluentLayouts.Touch;
using MvvmCross.Plugin.Color.Platforms.Ios;
using HealthCrossplatform.Core;
using UIKit;

namespace HealthCrossplatform.iOS.CustomControls
{
    public class InputView : BaseView
    {
        public UILabel Label { get; set; }

        public UITextField Input { get; set; }

        public UIView Line { get; set; }

        public InputView()
        {

        }

        protected override void CreateViews()
        {
            base.CreateViews();

            Label = new UILabel
            {
                TextColor = AppColors.AccentColor.ToNativeColor(),
                Font = UIFont.SystemFontOfSize(16f, UIFontWeight.Bold),
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            Input = new UITextField
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Semibold)
            };

            Line = new UIView
            {
                BackgroundColor = UIColor.LightGray
            };

            AddSubviews(Label, Input, Line);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            this.AddConstraints(
                Label.AtLeftOf(this, 8f),
                Label.WithSameCenterY(this),
                Label.WithRelativeWidth(this, .4f),

                Input.AtRightOf(this, 8f),
                Input.AtTopOf(this, 8f),
                Input.WithRelativeWidth(this, .55f),

                Line.Below(Input, 8f),
                Line.AtLeftOf(this),
                Line.AtRightOf(this),
                Line.AtBottomOf(this),
                Line.Height().EqualTo(.5f)
            );
        }
    }
}
