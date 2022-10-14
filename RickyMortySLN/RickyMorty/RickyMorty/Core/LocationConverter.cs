using RickyMorty.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RickyMorty.Core
{
    public class LocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(Location))
                {
                    Location loc = (Location)value;
                    return $"We are in the {loc.Dimension}!";
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
