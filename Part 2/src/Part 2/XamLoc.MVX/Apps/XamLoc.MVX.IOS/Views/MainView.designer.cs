// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamLoc.MVX.IOS
{
    [Register ("MainView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BackgroundView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonDevelopers { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonUpload { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextCountries { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextCountriesCount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextCurrentLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextDevelopers { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextDevelopersCount { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityIndicator != null) {
                ActivityIndicator.Dispose ();
                ActivityIndicator = null;
            }

            if (BackgroundView != null) {
                BackgroundView.Dispose ();
                BackgroundView = null;
            }

            if (ButtonDevelopers != null) {
                ButtonDevelopers.Dispose ();
                ButtonDevelopers = null;
            }

            if (ButtonUpload != null) {
                ButtonUpload.Dispose ();
                ButtonUpload = null;
            }

            if (TextCountries != null) {
                TextCountries.Dispose ();
                TextCountries = null;
            }

            if (TextCountriesCount != null) {
                TextCountriesCount.Dispose ();
                TextCountriesCount = null;
            }

            if (TextCurrentLocation != null) {
                TextCurrentLocation.Dispose ();
                TextCurrentLocation = null;
            }

            if (TextDevelopers != null) {
                TextDevelopers.Dispose ();
                TextDevelopers = null;
            }

            if (TextDevelopersCount != null) {
                TextDevelopersCount.Dispose ();
                TextDevelopersCount = null;
            }
        }
    }
}