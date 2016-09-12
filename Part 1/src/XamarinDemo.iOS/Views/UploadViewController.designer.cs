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
    [Register ("UploadViewController")]
    partial class UploadViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonUpload { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextUsername { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonUpload != null) {
                ButtonUpload.Dispose ();
                ButtonUpload = null;
            }

            if (TextLocation != null) {
                TextLocation.Dispose ();
                TextLocation = null;
            }

            if (TextUsername != null) {
                TextUsername.Dispose ();
                TextUsername = null;
            }
        }
    }
}