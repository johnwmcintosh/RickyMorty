using RickyMorty.UWP;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("RickyMorty")]
[assembly: ExportEffect(typeof(NativeFocusEffect), nameof(NativeFocusEffect))]
namespace RickyMorty.UWP
{
    public class NativeFocusEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            (Control as FormsTextBox).BackgroundFocusBrush = new SolidColorBrush(Color.Gainsboro).ToBrush();
        }

        protected override void OnDetached()
        {
            (Control as FormsTextBox).BackgroundFocusBrush = new SolidColorBrush(Color.Transparent).ToBrush();
        }
    }
}
