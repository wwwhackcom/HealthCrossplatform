using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace HealthCrossplatform.iOS.Views.Cells.DashboardCell
{
    public class NameTableViewCell : BaseTableViewCell
    {
        private const float PADDING = 24f;

        private UILabel _lblName;
        private UILabel _lblDesc;
        private UILabel _lblStatus;
        private UILabel _lblRecommendation;

        public NameTableViewCell(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateView()
        {
            base.CreateView();

            SelectionStyle = UITableViewCellSelectionStyle.None;

            _lblName = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Bold),
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            _lblDesc = new UILabel
            {
                TextColor = UIColor.LightGray,
                Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Bold),
                Lines = 3,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            _lblStatus = new UILabel
            {
                TextColor = UIColor.Red,
                Font = UIFont.SystemFontOfSize(16f, UIFontWeight.Bold),
                Lines = 1,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            _lblRecommendation = new UILabel
            {
                TextColor = UIColor.LightGray,
                Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Bold),
                Lines = 3,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            BackgroundColor = UIColor.Clear;
            ContentView.AddSubview(_lblName);
            ContentView.AddSubview(_lblDesc);
            ContentView.AddSubview(_lblStatus);
            ContentView.AddSubview(_lblRecommendation);
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.DelayBind(
                () =>
            {
                this.AddBindings(_lblName, "Text Name");
                this.AddBindings(_lblDesc, "Text Description");
                this.AddBindings(_lblStatus, "Text Status");
                this.AddBindings(_lblRecommendation, "Text Recommendation");
            });
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            ContentView.AddConstraints(
                _lblName.AtLeftOf(ContentView, PADDING),
                _lblName.AtTopOf(ContentView, PADDING / 2 + 5),
                _lblName.AtRightOf(ContentView, PADDING),
                _lblDesc.Below(_lblName, PADDING / 4),
                _lblDesc.AtLeftOf(ContentView, PADDING),
                _lblDesc.AtRightOf(ContentView, PADDING),
                _lblStatus.AtLeftOf(ContentView, PADDING),
                _lblStatus.Below(_lblDesc, PADDING / 4),
                _lblStatus.AtRightOf(ContentView, PADDING),
                _lblStatus.AtLeftOf(ContentView, PADDING),
                _lblRecommendation.Below(_lblStatus, PADDING / 4),
                _lblRecommendation.AtLeftOf(ContentView, PADDING),
                _lblRecommendation.AtRightOf(ContentView, PADDING),
                _lblRecommendation.AtBottomOf(ContentView, PADDING / 2)
            );
        }
    }
}
