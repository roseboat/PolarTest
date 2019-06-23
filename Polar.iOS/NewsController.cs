using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Polar.iOS.Models;
using UIKit;
using SuperNewsService.NewsFacade.Contracts.Models;
using Polar.SuperNewsService.NewsFacade.Contracts;
using Polar.SuperNewsService.NewsFacade.Implementation;

namespace Polar.iOS
{
    public partial class NewsController : UICollectionViewController
    {
        public string normalNewsSource;
        public string queryTopic;
        public INewsInterface newsInterface;


        public NewsController(IntPtr handle) : base(handle)
        {
        }

  
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.newsInterface = new NewsImplementation();
            try
            {

                if (!normalNewsSource.Equals(null) || !normalNewsSource.Equals(""))
                {
                    List<Newsitem> newsItems = await newsInterface.GetPolarNews(queryTopic, normalNewsSource);

                    var data = new List<NewsItemModel>();

                    foreach (Newsitem item in newsItems)
                    {
                        data.Add(new NewsItemModel() { Headline = item.Title, ArticleDate = item.PublishedDate, Preamble = item.Description, PhotoID= "placeholder.jpg", SourceName = "Source: "+ item.SourceName });
                    }


                    data.Add(new NewsItemModel() { Headline = "test", ArticleDate = DateTime.Now, Preamble = "test test test test test test test test test test test test test test test test test test test test test test test test test test test test ", PhotoID = "placeholder.jpg", SourceName = "Source: " + "FakeNews" });
                    data.Add(new NewsItemModel() { Headline = "test", ArticleDate = DateTime.Now, Preamble = "test test test test test test test test test test test test test test test test test test test test test test test test test test test test ", PhotoID = "placeholder.jpg", SourceName = "Source: " + "FakeNews" });
                    data.Add(new NewsItemModel() { Headline = "test", ArticleDate = DateTime.Now, Preamble = "test test test test test test test test test test test test test test test test test test test test test test test test test test test test ", PhotoID = "placeholder.jpg", SourceName = "Source: " + "FakeNews" });
                    data.Add(new NewsItemModel() { Headline = "test", ArticleDate = DateTime.Now, Preamble = "test test test test test test test test test test test test test test test test test test test test test test test test test test test test ", PhotoID = "placeholder.jpg", SourceName = "Source: " + "FakeNews" });
                    data.Add(new NewsItemModel() { Headline = "test", ArticleDate = DateTime.Now, Preamble = "test test test test test test test test test test test test test test test test test test test test test test test test test test test test ", PhotoID = "placeholder.jpg", SourceName = "Source: " + "FakeNews" });
                    data.Add(new NewsItemModel() { Headline = "test", ArticleDate = DateTime.Now, Preamble = "test test test test test test test test test test test test test test test test test test test test test test test test test test test test ", PhotoID = "placeholder.jpg", SourceName = "Source: " + "FakeNews" });

                    this.NewsControllerView.Source = new NewsCollectionViewSource(this, data);

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

