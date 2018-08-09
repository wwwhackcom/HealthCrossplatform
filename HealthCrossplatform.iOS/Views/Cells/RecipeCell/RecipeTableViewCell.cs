using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace HealthCrossplatform.iOS.Views.Cells.RecipeCell
{
    public class RecipeTableViewCell : BaseTableViewCell
    {
        private const float PADDING = 12f;
        private const float IMAGE_WIDTH = 105f;
        private const float IMAGE_HEIGHT = 45f;

        private UIView _leftView;
        private UIView _rightView;
        private UIImageView _imgView;
        private UILabel _lblName;
        private UILabel _lblCategory;
        private UILabel _lblDesc;

        public RecipeTableViewCell(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateView()
        {
            base.CreateView();

            SelectionStyle = UITableViewCellSelectionStyle.None;

            _leftView = new UIView
            {
                //BackgroundColor = UIColor.White
            };

            _rightView = new UIView
            {
                //BackgroundColor = UIColor.Red
            };

            _lblName = new UILabel
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Bold),
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            _imgView = new UIImageView
            {
                //BackgroundColor = UIColor.Green,
                Image = UIImage.FromBundle("recipePic2.jpg")
            };

            _lblCategory = new UILabel
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Bold),
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            _lblDesc = new UILabel
            {
                TextColor = UIColor.LightGray,
                Font = UIFont.SystemFontOfSize(12f, UIFontWeight.Bold),
                Lines = 3,
                LineBreakMode = UILineBreakMode.TailTruncation
            };


            BackgroundColor = UIColor.Clear;

            ContentView.AddSubviews(_leftView, _rightView, _imgView, _lblName, _lblCategory, _lblDesc);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.DelayBind(
                () =>
            {
                this.AddBindings(_lblName, "Text Name");
                this.AddBindings(_lblCategory, "Text Category");
                this.AddBindings(_lblDesc, "Text Description");
            });
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            ContentView.AddConstraints(
                _leftView.AtLeftOf(ContentView),
                _leftView.AtTopOf(ContentView),
                _leftView.AtBottomOf(ContentView),
                _leftView.Height().EqualTo(IMAGE_HEIGHT + 80),
                _leftView.WithRelativeWidth(ContentView, 0.4f),

                _imgView.AtTopOf(_leftView, 3 * PADDING),
                _imgView.WithSameCenterX(_leftView),
                _imgView.Width().EqualTo(IMAGE_WIDTH),
                _imgView.Height().EqualTo(IMAGE_HEIGHT),

                _lblCategory.Below(_imgView, PADDING),
                _lblCategory.WithSameLeft(_imgView),
                _lblCategory.WithSameWidth(_leftView),

                _rightView.AtRightOf(ContentView),
                _rightView.AtTopOf(ContentView),
                _rightView.AtBottomOf(ContentView),
                _rightView.WithRelativeWidth(ContentView, 0.6f),
                _rightView.WithSameHeight(_leftView),

                _lblName.AtLeftOf(_rightView, PADDING),
                _lblName.AtTopOf(_rightView, 3 * PADDING),
                _lblName.AtRightOf(_rightView, PADDING),

                _lblDesc.Below(_lblName, PADDING),
                _lblDesc.AtLeftOf(_rightView, PADDING),
                _lblDesc.AtRightOf(_rightView, PADDING)
            );
        }
    }
}
