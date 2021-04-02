using System;
using System.Globalization;
using Xamarin.Forms;

namespace KSInventory.Converters
{
    public class SafetyStockColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int stockForSale = int.Parse(value.ToString());
                if (stockForSale > 0)
                    return Color.Black;
                else
                    return Color.Red;
            }
            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
