using Foundation;
using Polar.iOS;
using System;
using System.Linq;
using UIKit;

namespace Polar.iOS
{
    public partial class ViewController : UIViewController
    {

        public string normalNewsSource = "BBC";
        public string queryTopic;
        public string[] newsSources = new string[] { "BBC", "The Sun", "Fox News", "The New York Times", "The Independent", "Houston Chronicle"};

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NewsPicker.DataSource = new NewsPickerDataSource(newsSources);
            NewsPicker.Delegate = new NewsPickerDelegate(newsSources);
            NewsPicker.Model = new MyNewsPicker(this);

        }

        partial void GetNewsButton_TouchUpInside(UIButton sender)
        {

            this.queryTopic = TopicText.Text;
            if (!normalNewsSource.Equals(null) || !normalNewsSource.Equals(""))
            {
                this.PerformSegue("NewsViewSegue", sender: Self);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var vc = segue.DestinationViewController as NewsController;
            vc.normalNewsSource = this.normalNewsSource;
            vc.queryTopic = this.queryTopic;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

public class NewsPickerDataSource : UIPickerViewDataSource
{

    private string[] data;

    public NewsPickerDataSource(string [] newsSources)
    {
        this.data = newsSources;
    }

    public override nint GetComponentCount(UIPickerView pickerView)
    {
        return 1;
    }

    public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
    {
        return data.Count();
    }
}

public class NewsPickerDelegate: UIPickerViewDelegate
{

    private string[] data;

    public NewsPickerDelegate(string[] newsSources)
    {
        this.data = newsSources;
    }
    public override string GetTitle(UIPickerView pickerView, nint row, nint component)
    {
        return data[(int)row];
    }
    //public override void Selected(UIPickerView pickerView, nint row, nint component)
    //{
      
    //}

}
public class MyNewsPicker : UIPickerViewModel
{
    ViewController viewController;

    public MyNewsPicker(ViewController view)
    {
        this.viewController = view;
    }
    public override nint GetComponentCount(UIPickerView pickerView)
    {
        return 1;
    }
    public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
    {
        return viewController.newsSources.Count();
    }
    public override string GetTitle(UIPickerView pickerView, nint row, nint component)
    {
        return viewController.newsSources[(int)row];
    }
    public override void Selected(UIPickerView pickerView, nint row, nint component)
    {
        string s = viewController.newsSources[(int)pickerView.SelectedRowInComponent(0)];
        viewController.normalNewsSource = s;

    }

}