using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AbankHW12.Models
{
    public class DynamicMaskedStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return "Invalid data";

            var passportNumber = values[1] as string;                                                               // Удаление лишнего + 1 в строке с маскировкой: Это было изменено для соответствия длине исходного номера паспорта без добавления дополнительного символа

            if (string.IsNullOrWhiteSpace(passportNumber))                                                          // Заменяет простую проверку null и учитывает случаи, когда строка содержит только пробелы
                return "Not found";

            if (values[0] is bool canChange && canChange)
            {
                return new string('*', passportNumber.Length);
            }
            else
            {
                return passportNumber;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack is not supported.");
        }
    }
}
