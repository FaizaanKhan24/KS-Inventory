using System;
using System.Globalization;
using KSInventory.Models.Enums;
using Xamarin.Forms;

namespace KSInventory.Converters
{
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.ToString() is string)
            {
                string productSize = value.ToString();
                switch (productSize)
                {
                    case "Small":
                        {
                            return "S";
                        }
                    case "Medium":
                        {
                            return "M";
                        }
                    case "Large":
                        {
                            return "L";
                        }
                    case "XL":
                        {
                            return "XL";
                        }
                    case "XXL":
                        {
                            return "XXL";
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
