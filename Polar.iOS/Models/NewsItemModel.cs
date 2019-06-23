using System;
namespace Polar.iOS.Models
{
    public class NewsItemModel
    {
        public NewsItemModel()
        {
        }
        public string PhotoID { get; set; }
        public string Headline { get; set; }
        public string Preamble { get; set; }
        public string SourceName { get; set; }
        public DateTime ArticleDate { get; set; }
    }
}
