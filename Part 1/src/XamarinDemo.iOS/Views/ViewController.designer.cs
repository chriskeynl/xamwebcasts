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

namespace XamarinDemo.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonUpload { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelCountries { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelDevelopers { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Spinner { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonUpload != null) {
                ButtonUpload.Dispose ();
                ButtonUpload = null;
            }

            if (Label != null) {
                Label.Dispose ();
                Label = null;
            }

            if (LabelCountries != null) {
                LabelCountries.Dispose ();
                LabelCountries = null;
            }

            if (LabelDevelopers != null) {
                LabelDevelopers.Dispose ();
                LabelDevelopers = null;
            }

            if (Spinner != null) {
                Spinner.Dispose ();
                Spinner = null;
            }
        }
    }
}