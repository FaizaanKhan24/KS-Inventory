using System;
using System.ComponentModel;
using KSInventory.CustomControllers;
using KSInventory.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessPicker), typeof(BorderlessPickerRenderer))]
namespace KSInventory.Droid.Renderers
{
    public class BorderlessPickerRenderer : PickerRenderer
    {
        public BorderlessPickerRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.Background = null;
            }
        }
    }
}
