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
            if(value is Sizes)
            {
                Sizes productSize = (Sizes)value;
                switch (productSize)
                {
                    case Sizes.Small:
                        {
                            return "S";
                        }
                    case Sizes.Medium:
                        {
                            return "M";
                        }
                    case Sizes.Large:
                        {
                            return "L";
                        }
                    case Sizes.XL:
                        {
                            return "XL";
                        }
                    case Sizes.XXL:
                        {
                            return "XXL";
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
            if(value is string)
            {
                string productSize = (string)value;
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
