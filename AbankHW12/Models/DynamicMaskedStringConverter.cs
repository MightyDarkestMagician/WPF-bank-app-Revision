using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AbankHW12.Models
{
    /// <summary>
    /// Класс DynamicMaskedStringConverter реализует интерфейс IMultiValueConverter для условного маскирования строк,
    /// в частности, номеров паспортов в зависимости от условий.
    /// 
    /// Принцип работы:
    /// Конвертер использует массив значений, где первый элемент массива определяет, можно ли изменять строку,
    /// а второй элемент — это сама строка, подлежащая маскировке.
    /// 
    /// Конвертер возвращает маскированную строку, если условие изменения (canChange) истинно, и исходную строку в противном случае.
    /// 
    /// Конвертер также проверяет на наличие недопустимых или пустых входных данных, возвращая сообщение об ошибке в таких случаях.
    /// 
    /// Использование:
    /// Может быть использован в пользовательском интерфейсе для защиты чувствительных данных от отображения,
    /// например, в полях форм, где необходимо скрыть номер паспорта от неавторизированного просмотра.
    /// 
    /// Метод ConvertBack не поддерживается, так как обратное преобразование маскированных данных обычно не требуется и не безопасно.
    /// </summary>

    public class DynamicMaskedStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)                    // Проверка на нулевой или неполный массив значений
                return "Invalid data";

            var passportNumber = values[1] as string;                   // Приведение второго элемента массива к строке, предполагается номер паспорта
                                                                        // Удаление лишнего + 1 в строке с маскировкой: Это было изменено для соответствия длине исходного номера паспорта без добавления дополнительного символа

            if (string.IsNullOrWhiteSpace(passportNumber))              // Заменяет простую проверку null и учитывает случаи, когда строка содержит только пробелы
                return "Not found";

            if (values[0] is bool canChange && canChange)               // Проверка, разрешено ли изменение (маскирование)
            {
                return new string('*', passportNumber.Length);          // Возвращение маскированной строки равной по длине номеру паспорта
            }
            else
            {
                return passportNumber;                                  // Возвращение оригинальной строки, если изменение не разрешено
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack is not supported.");                                       // Не поддерживается обратное преобразование 
        }
    }
}
