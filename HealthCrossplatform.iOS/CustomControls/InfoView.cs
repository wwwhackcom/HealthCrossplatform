﻿using Cirrious.FluentLayouts.Touch;
using MvvmCross.Plugin.Color.Platforms.Ios;
using HealthCrossplatform.Core;
using UIKit;

namespace HealthCrossplatform.iOS.CustomControls
{
    public class InfoView : BaseView
    {
        public UILabel Label { get; set; }

        public UILabel Information { get; set; }

        public UIView Line { get; set; }

        public InfoView()
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

            Information = new UILabel
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Semibold),
                Lines = 5,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            Line = new UIView
            {
                BackgroundColor = UIColor.LightGray
            };

            AddSubviews(Label, Information, Line);
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            this.AddConstraints(
                Label.AtLeftOf(this, 8f),
                Label.WithSameCenterY(this),
                Label.WithRelativeWidth(this, .4f),

                Information.AtRightOf(this, 8f),
                Information.AtTopOf(this, 8f),
                Information.WithRelativeWidth(this, .55f),

                Line.Below(Information, 8f),
                Line.AtLeftOf(this),
                Line.AtRightOf(this),
                Line.AtBottomOf(this),
                Line.Height().EqualTo(.5f)
            );
        }
    }
}
