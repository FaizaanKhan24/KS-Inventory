using System;
using System.ComponentModel;
using KSInventory.CustomControllers;
using KSInventory.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry),typeof(BorderlessEntryRenderer))]
namespace KSInventory.Droid.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(Control != null)
            {
                Control.Background = null;
            }
        }
    }
}
