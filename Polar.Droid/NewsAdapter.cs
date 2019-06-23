using Android.Icu.Text;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace Polar.Droid
{
    public class NewsAdapter:RecyclerView.Adapter
    {
  
        public List<NewsItem> mNewsItems;

   
        public NewsAdapter(List<NewsItem> newsItems)
        {
            mNewsItems = newsItems;
        }

        public override int ItemCount => mNewsItems.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var holder2 = (NewsItemViewHolder)holder;
         
            holder2.Date.Text = mNewsItems[position].Date.ToString("dd MMM HH:mm:ss");
            holder2.Headline.Text = mNewsItems[position].Headline;
            holder2.Preamble.Text = mNewsItems[position].Preamble;
            holder2.Image.SetImageResource(mNewsItems[position].PhotoID);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.news_item, parent, false);
            return new NewsItemViewHolder(itemView);
        }
    }

    public class NewsItemViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Date { get; set; }
        public TextView Headline { get; set; }
        public TextView Preamble { get; set; }
        public NewsItemViewHolder(View itemview) : base(itemview)
        {
            Image = ItemView.FindViewById<ImageView>(Resource.Id.image_id);
            Date = ItemView.FindViewById<TextView>(Resource.Id.date);
            Headline = itemview.FindViewById<TextView>(Resource.Id.headline);
            Preamble = itemview.FindViewById<TextView>(Resource.Id.preamble);
        }
    }

}


