using System;
using Android.Widget;
using KSInventory.CustomControllers;
using KSInventory.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessSearchbar),typeof(BorderlessSearchbarRenderer))]
namespace KSInventory.Droid.Renderers
{
    public class BorderlessSearchbarRenderer : SearchBarRenderer
    {
        public BorderlessSearchbarRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                var color = global::Xamarin.Forms.Color.LightGray;
                var searchView = Control as SearchView;

                int searchPlateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
                Android.Views.View searchPlateView = searchView.FindViewById(searchPlateId);
                searchPlateView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
