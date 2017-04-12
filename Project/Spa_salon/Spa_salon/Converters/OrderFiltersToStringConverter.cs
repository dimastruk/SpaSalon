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
    public class OrderFiltersToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = (OrderFilters)value;

            switch(filter)
            {
                case OrderFilters.Actuality:
                    return "Актуальність";
                    
                case OrderFilters.Date:
                    return "Дата";
                    
                case OrderFilters.FirstName:
                    return "Ім'я";
                    
                case OrderFilters.LastName:
                    return "Прізвище";
                    
                case OrderFilters.PhoneNumber:
                    return "Номер телефону";
                    
                case OrderFilters.Time:
                    return "Час";
                    ;
                case OrderFilters.TotalPrice:
                    return "Сума (UAH)";
                default:
                    return "Unknown";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = (string)value;

            if (filter == "Актуальність")
                return OrderFilters.Actuality;
            if (filter == "Дата")
                return OrderFilters.Date;
            if (filter == "Ім'я")
                return OrderFilters.FirstName;
            if (filter == "Прізвище")
                return OrderFilters.LastName;
            if (filter == "Номер телефону")
                return OrderFilters.PhoneNumber;
            if (filter == "Час")
                return OrderFilters.Time;
            if (filter == "Сума (UAH)")
                return OrderFilters.TotalPrice;

            return null;
        }
    }
}