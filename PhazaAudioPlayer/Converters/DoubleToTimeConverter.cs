using System;
using System.Globalization;
using System.Windows.Data;

namespace PhazaAudioPlayer.Converters;

public class DoubleToTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var seconds = (double)value;

        return TimeSpan.FromSeconds(Math.Round(seconds)).ToString(@"mm\:ss");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}