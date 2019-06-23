using System;
using System.Collections.Generic;
using Polar.iOS.Models;
using UIKit;

namespace Polar.iOS
{
    internal class NewsCollectionViewSource : UICollectionViewSource
    {
        private NewsController controller;
        private List<NewsItemModel> items;

        public NewsCollectionViewSource(NewsController newsController, List<NewsItemModel> newsItems)
        {
            this.controller = newsController;
            this.items = newsItems;
            this.controller.CollectionView.RegisterNibForCell(NewsCollectionViewCell.Nib, NewsCollectionViewCell.Key);

        }

        public override System.nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section) {

            return items.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = (NewsCollectionViewCell)collectionView.DequeueReusableCell(NewsCollectionViewCell.Key, indexPath);
            cell.UpdateRow(items, indexPath); 
            return cell;
        }


    }
}
