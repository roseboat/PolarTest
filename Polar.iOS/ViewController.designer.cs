// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Polar.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIPickerView NewsPicker { get; set; }


        [Outlet]
        UIKit.UITextField TopicText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GetNewsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView HomeImage { get; set; }


        [Action ("GetNewsButton_TouchUpInside:")]
        partial void GetNewsButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (GetNewsButton != null) {
                GetNewsButton.Dispose ();
                GetNewsButton = null;
            }

            if (HomeImage != null) {
                HomeImage.Dispose ();
                HomeImage = null;
            }
        }
    }
}