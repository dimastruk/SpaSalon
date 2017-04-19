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
    public class WorkerFiltersToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = (WorkerFilters)value;

            switch(filter)
            {
                case WorkerFilters.Address:
                    return "Адреса";
                case WorkerFilters.DateOfBirth:
                    return "Дата народження";
                case WorkerFilters.FirstName:
                    return "Ім'я";
                case WorkerFilters.IdNumber:
                    return "Ідентифікаційний номер";
                case WorkerFilters.LastName:
                    return "Прізвище";
                case WorkerFilters.MedicalbookNumber:
                    return "Номер медичної картки";
                case WorkerFilters.MiddleName:
                    return "По-батькові";
                case WorkerFilters.PassportNumber:
                    return "Паспорт";
                case WorkerFilters.PhoneNumber:
                    return "Номер телефону";
                case WorkerFilters.Position:
                    return "Посада";
                case WorkerFilters.WorkbookNumber:
                    return "Номер трудової книги";
                default:
                    return "Unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filter = (string)value;

            if (filter == "Адреса")
                return WorkerFilters.Address;
            if (filter == "Дата народження")
                return WorkerFilters.DateOfBirth;
            if (filter == "Ім'я")
                return WorkerFilters.FirstName;
            if (filter == "Ідентифікаційний номер")
                return WorkerFilters.IdNumber;
            if (filter == "Прізвище")
                return WorkerFilters.LastName;
            if (filter == "Номер медичної картки")
                return WorkerFilters.MedicalbookNumber;
            if (filter == "По-батькові")
                return WorkerFilters.MiddleName;
            if (filter == "Паспорт")
                return WorkerFilters.PassportNumber;
            if (filter == "Номер телефону")
                return WorkerFilters.PhoneNumber;
            if (filter == "Посада")
                return WorkerFilters.Position;
            if (filter == "Номер трудової книги")
                return WorkerFilters.WorkbookNumber;

            return null;
        }
    }
}
