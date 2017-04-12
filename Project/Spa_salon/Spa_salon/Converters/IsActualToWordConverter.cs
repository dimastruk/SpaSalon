using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Spa_salon.Converters
{
    public class IsActualToWordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nonActualString = "Виконано";
            string isActualString = "Не виконано";

            if((bool)value == true)
            {
                return isActualString;
            }
            else
            {
                return nonActualString;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
