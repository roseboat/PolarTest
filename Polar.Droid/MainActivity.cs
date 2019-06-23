using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Polar.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public string newsSource = "BBC";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            ImageView polar = FindViewById<ImageView>(Resource.Id.polar_id);
            Button button = FindViewById<Button>(Resource.Id.button_id);
            TextView newsText = FindViewById<TextView>(Resource.Id.news_text);

            Spinner spinner = (Spinner)FindViewById(Resource.Id.spinner1);
            // Create an ArrayAdapter using the string array and a default spinner layout
            var adapter = ArrayAdapter.CreateFromResource(this,
                    Resource.Array.news_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            button.Click += delegate
            {
                Bundle bundle = new Bundle();
                bundle.PutString("newsSource", this.newsSource);
                HomeFragment fragment = new HomeFragment();
                fragment.Arguments = bundle;
                newsText.Visibility = ViewStates.Invisible;
                button.Visibility = ViewStates.Invisible;
                polar.Visibility = ViewStates.Invisible;
                spinner.Visibility = ViewStates.Invisible;

                this.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).AddToBackStack(null).Commit();
            };
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            this.newsSource = spinner.GetItemAtPosition(e.Position).ToString();
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

