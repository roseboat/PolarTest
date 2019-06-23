using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Polar.Droid
{

    public class NewsItem {
        public string Headline { get; set; }
        public string Preamble { get; set; }
        public DateTime Date { get; set; }
        public int PhotoID { get; set;  }

        public NewsItem(string headline, string preamble, int photoId, DateTime date) {
            this.Headline = headline;
            this.Preamble = preamble;
            this.Date = date;
            this.PhotoID = photoId;
            
         } 
    }
}
