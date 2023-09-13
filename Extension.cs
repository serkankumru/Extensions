using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(x.GetDays("hata"));

            string s1 = "12345677";
            string s2 = "12345";
            string s3 = "123";

            string result = s1.Substring(0, 6);
            result = s2.ControlledSub(6, "");
            result = s3.ControlledSub(2, "");
            Console.WriteLine(result);
            string s = "12";

            int x2;
            x2 = ExtensionMethodsSimple.ToInt(s);//normal ExtensionMethodsSimple dan çagrılıyor
            x2 = s.ToInt(4);//string extension

            Console.WriteLine(x);
            Console.Read();
        }
    }



    public static class ExtensionMethodsSimple
    {
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt(this string value, int eklenecek)
        {
            return Convert.ToInt32(value) + eklenecek;
        }
        public static int ToInt(this string value, int eklenecek, int cikarilacak)
        {
            return Convert.ToInt32(value) + eklenecek - cikarilacak;
        }

        public static string ControlledSub(this string value, int lenght, string deVal)
        {
            if (string.IsNullOrWhiteSpace(value))
                return deVal;
            string resuld = value;
            if (lenght <= value.Length)
            {
                resuld = resuld.Substring(0, lenght);
            }
            return resuld;
        }

        public static string GetDays(this int s, string message)
        {
            string result;
            if (s > 7 || s < 1)
                return message;
            if (s == 1)
                result = "pazartesi";
            else if (s == 2)
                result = "salı";
            else if (s == 3)
                result = "çarşamba";
            else if (s == 4)
                result = "perşembe";
            else if (s == 5)
                result = "cuma";
            else if (s == 6)
                result = "cumartesi";
            else
                result = "pazar";

            return result;
        }
    }
}
