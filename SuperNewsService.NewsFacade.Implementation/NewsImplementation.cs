using SuperNewsService.NewsFacade.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperNewsService.NewsFacade.Contracts.Models;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch;
using System.Threading.Tasks;
using Polar.SuperNewsService.NewsFacade.Contracts;

namespace Polar.SuperNewsService.NewsFacade.Implementation
{
    public class NewsImplementation : INewsInterface
    {
        private readonly NewsSearchClient client;
        private List<string> RightNews = new List<string> {  "The Telegraph", "Fox News", "The Sun" };
        private List<string> LeftNews = new List<string> { "BBC", "The New York Times", "The Independent"};

        public NewsImplementation()
        {
            client = new NewsSearchClient(new ApiKeyServiceClientCredentials("4fa7760d760f43c193545adc6c28f4cc"));
            client.Endpoint = "https://api.cognitive.microsoft.com/";
        }

        //private Dictionary<string, string> sources = new Dictionary<string, string> { { "BBC", "The Sun"}, { "CNN", "Fox" } };

    
        public async Task<List<Newsitem>> GetPolarNews(string query, string preferences)
        {
            try
            {
                var newsResult = await client.News.SearchAsync(query);

                var response = new List<Newsitem>();

                var polarNews = new List<string>();

                if (RightNews.Contains(preferences))
                {
                    polarNews = LeftNews;
                }
                else if (LeftNews.Contains(preferences))
                {
                    polarNews = RightNews;
                }


                //newsResult.Value.ToList().ForEach(item =>
                //{
                //    if (item.Provider.Any(provider => { if (sources.ContainsKey(preferences)) { return provider.Name == sources[preferences]; } else return false; }))
                //    {
                //        response.Add(new Newsitem()
                //        {
                //            Title = item.Name,
                //            Description = item.Description,
                //            PublishedDate = DateTime.Parse(item.DatePublished),
                //            SourceName = item.Provider.FirstOrDefault()?.Name,
                //        });
                //    }
                //}
                //);



                newsResult.Value.ToList().ForEach(item =>
                {
                    if (item.Provider.Any(provider => { return polarNews.Contains(provider.Name); }))
                {
                    response.Add(new Newsitem()
                    {
                        Title = item.Name,
                        Description = item.Description,
                        PublishedDate = DateTime.Parse(item.DatePublished),
                        SourceName = item.Provider.FirstOrDefault()?.Name,
                    });
                }
            });


                return response;
            }
            catch(Exception ex)
            {
                return new List<Newsitem>();
            }
        }
    }
}
