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
    [Register ("UploadView")]
    partial class UploadView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonUpload { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TextCurrentLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonUpload != null) {
                ButtonUpload.Dispose ();
                ButtonUpload = null;
            }

            if (TextCurrentLocation != null) {
                TextCurrentLocation.Dispose ();
                TextCurrentLocation = null;
            }

            if (TextName != null) {
                TextName.Dispose ();
                TextName = null;
            }
        }
    }
}