// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Polar.iOS
{
    [Register ("NewsController")]
    partial class NewsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView NewsControllerView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NewsControllerView != null) {
                NewsControllerView.Dispose ();
                NewsControllerView = null;
            }
        }
    }
}