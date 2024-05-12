using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.Helpers
{
    public static class ChecktToUserSetGoodValue
    {
        public static bool String_ToInt (string value, int minRange, int maxRange)
        {
            bool IsOk=false;
            Int32.TryParse(value,out int intParse);
            if (intParse!=0 && intParse<maxRange && intParse>minRange) 
            {
                IsOk=true;
            }

            return IsOk;
        }

        public static bool String_ToFloat (string value, float minRange, float maxRange)
        {
            bool IsOk = false;
            float.TryParse(value, out float floatParse);
            if (floatParse != 0 && floatParse < maxRange && floatParse > minRange)
            {
                IsOk = true;
            }

            return IsOk;
        }

        public static bool String_ToDateTime (string value, string format)
        {
            bool IsOK = DateTime.TryParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture, 
                                                System.Globalization.DateTimeStyles.None, out DateTime tempDate); 
            return IsOK;

        }
    }
}
