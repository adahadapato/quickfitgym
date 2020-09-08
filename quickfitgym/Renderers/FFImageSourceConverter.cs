using System;
using System.Globalization;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace quickfitgym
{
    public class FFImageSourceConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceString = value as string;
            return new DataUrlImageSource(sourceString);
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
