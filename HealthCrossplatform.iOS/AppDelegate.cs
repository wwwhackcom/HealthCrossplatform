﻿using Foundation;
using HealthCrossplatform.Core;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Plugin.Color.Platforms.Ios;
using UIKit;

namespace HealthCrossplatform.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            CustomizeAppearance();

            return result;
        }

        private void CustomizeAppearance()
        {
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(17f, UIFontWeight.Semibold)
            });
            UINavigationBar.Appearance.Translucent = false;
            UINavigationBar.Appearance.BarTintColor = AppColors.PrimaryColor.ToNativeColor();
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BackgroundColor = AppColors.PrimaryColor.ToNativeColor();
            UINavigationBar.Appearance.BackIndicatorImage = new UIImage();

            UITabBar.Appearance.BackgroundColor = AppColors.PrimaryColor.ToNativeColor();
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = AppColors.AccentColor.ToNativeColor()
            }, UIControlState.Selected);

            UITextField.Appearance.TintColor = AppColors.AccentColor.ToNativeColor();
            UITextView.Appearance.TintColor = AppColors.AccentColor.ToNativeColor();
            UIButton.Appearance.SetTitleColor(AppColors.AccentColor.ToNativeColor(), UIControlState.Highlighted);
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}

