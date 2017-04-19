using Spa_salon.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Spa_salon.Converters
{
    class ClientFiltersToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = (ClientFilters)value;

            switch(filter)
            {
                case ClientFilters.LastName:
                    return "Прізвище";
                case ClientFilters.FirstName:
                    return "Ім'я";
                case ClientFilters.PhoneNumber:
                    return "Номер телефону";
                default:
                    return "Unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = (string)value;

            if (filter == "Прізвище")
                return ClientFilters.LastName;
            if (filter == "Ім'я")
                return ClientFilters.FirstName;
            if (filter == "Номер телефону")
                return ClientFilters.PhoneNumber;

            return null;
        }
    }
}
