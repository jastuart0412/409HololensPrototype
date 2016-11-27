using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Security.Principal;
using System.Globalization;

namespace HololensPrototype
{
    public class VisibilityConverter : IValueConverter
    {
         #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("VisibilityConverter called:");
            Console.WriteLine(value.ToString() + " " + parameter.ToString());
            var principal = value as IPrincipal;
            if (principal != null)
            {
                return principal.IsInRole((string)parameter) ? Visibility.Visible : Visibility.Collapsed;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
