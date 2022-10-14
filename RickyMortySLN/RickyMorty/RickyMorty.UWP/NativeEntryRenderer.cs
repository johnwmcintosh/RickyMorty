using RickyMorty.Core;
using RickyMorty.UWP;
using System.ComponentModel;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NativeEntry), typeof(NativeEntryRenderer))]
namespace RickyMorty.UWP
{
    public class NativeEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
                Control.FontStyle = Windows.UI.Text.FontStyle.Oblique;
        }
    }
}
