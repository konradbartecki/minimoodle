using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhoneApp1
{

	public class ThemeLogoConverter : IValueConverter
	{
		#region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {


            if( (Visibility)App.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible )
                return new BitmapImage(new Uri("/PhoneApp1;component/Assets/Logo/White.png", UriKind.Relative));
            else
                return new BitmapImage(new Uri("/PhoneApp1;component/Assets/Logo/Black.png", UriKind.Relative));
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
	}
}