using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AbankHW12.Models
{
    public class DynamicMaskedStringConverter : IMultiValueConverter // без stackoverflow я бы это никогда не написал
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var passportNum = values[1] as string;

            if (passportNum == null) { return "not found"; }
            if (values[0] is bool canChange && canChange)
            {
                
                

                int len = passportNum.Length + 1;


                return new string('*', len);
            }
            else
            {
                
                return values[1];
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
