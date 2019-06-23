using System;
using System.Collections.Generic;
using Foundation;
using Polar.iOS.Models;
using UIKit;

namespace Polar.iOS
{
    public partial class NewsCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("NewsItemCell");
        public static readonly UINib Nib;

        static NewsCollectionViewCell()
        {
            Nib = UINib.FromName("NewsCollectionViewCell", NSBundle.MainBundle);

        }

        protected NewsCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateRow(List<NewsItemModel> items, NSIndexPath indexPath)
        {
            NewsImage.Image = UIImage.FromFile(items[indexPath.Row].PhotoID);
            HeadlineText.Text = items[indexPath.Row].Headline;
            PreambleText.Text = items[indexPath.Row].Preamble;
            DateText.Text = (items[indexPath.Row].ArticleDate).ToString();
            SourceLable.Text = items[indexPath.Row].SourceName;
        }
    }
}
