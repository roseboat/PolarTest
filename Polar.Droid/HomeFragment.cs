
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Polar.SuperNewsService.NewsFacade.Contracts;
using Polar.SuperNewsService.NewsFacade.Implementation;
using SuperNewsService.NewsFacade.Contracts.Models;


namespace Polar.Droid
{
    public class HomeFragment : Fragment
    {

        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private NewsAdapter mAdapter;
        private List<NewsItem> mNewsItems;
        private string newsSource;
        private INewsInterface newsInterface;

        public HomeFragment()
        {
            this.mNewsItems = new List<NewsItem>();
            this.newsInterface = new NewsImplementation();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.newsSource = savedInstanceState.GetString("newsSource");
            this.mNewsItems.Add(new NewsItem("Test", "test", Resource.Drawable.placeholder, DateTime.Now));


            GetNews(newsSource).ContinueWith(t =>
            {
                var result = t.Result;
                foreach (Newsitem item in result)
                {
                    this.mNewsItems.Add(new NewsItem(item.Title, item.Description, Resource.Drawable.placeholder, item.PublishedDate));
                }

            }
            );

            //try
            //{
            //    if (!newsSource.Equals(null) || !newsSource.Equals(""))
            //    {
            //        List<Newsitem> newsItems = newsInterface.GetPolarNews("Trump", newsSource);

            //        foreach (Newsitem item in newsItems)
            //        {
            //            this.mNewsItems.Add(new NewsItem(item.Title, item.Description, Resource.Drawable.placeholder));
            //        }

            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
        }

        private async Task<List<Newsitem>> GetNews(string newsSource)
        {
            var newsItems = new List<Newsitem>();

            try
            {
                if (!newsSource.Equals(null) || !newsSource.Equals(""))
                {
                    newsItems = await newsInterface.GetPolarNews("Trump", newsSource);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return newsItems;
        }



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            View view = inflater.Inflate(Resource.Layout.home_layout, null);
            this.Activity.SetContentView(view);

            TextView source = (TextView)view.FindViewById(Resource.Id.nav_label);
            source.Text = "Source: " + newsSource;

            mRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView);
            mAdapter = new NewsAdapter(mNewsItems);
            mRecyclerView.SetAdapter(mAdapter);
            mRecyclerView.ScrollToPosition(0);
            mLayoutManager = new LinearLayoutManager(this.Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            return view;

        }
    }
}
