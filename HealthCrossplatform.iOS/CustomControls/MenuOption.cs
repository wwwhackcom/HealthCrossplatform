using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace HealthCrossplatform.iOS.CustomControls
{
    public class MenuOption : BaseView
    {
        private const float PADDING = 16f;
        private const float IMAGE_SIZE = 24f;

        public UIImageView ImageView { get; set; }

        public UILabel Label { get; set; }

        public UIView Line { get; set; }

        public MenuOption()
        {
        }

        protected override void CreateViews()
        {
            base.CreateViews();

            ImageView = new UIImageView();

            Label = new UILabel
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(18f, UIFontWeight.Bold)
            };

            Line = new UIView { BackgroundColor = UIColor.LightGray };

            AddSubviews(ImageView, Label, Line);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            this.AddConstraints(
                ImageView.AtLeftOf(this, PADDING),
                ImageView.WithSameCenterY(this),
                ImageView.Width().EqualTo(IMAGE_SIZE),
                ImageView.Height().EqualTo(IMAGE_SIZE),

                Label.ToRightOf(ImageView, PADDING / 2),
                Label.AtTopOf(this, PADDING),
                Label.AtRightOf(this, PADDING),

                Line.Below(Label, PADDING),
                Line.AtLeftOf(this, PADDING),
                Line.AtRightOf(this),
                Line.AtBottomOf(this),
                Line.Height().EqualTo(.5f)
            );
        }
    }
}
