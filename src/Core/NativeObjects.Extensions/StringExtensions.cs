namespace ProcessManager.Core.NativeObjects.Extensions
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string EncodeHexadecimal(this string inputString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte num in Encoding.UTF8.GetBytes(inputString))
                stringBuilder.Append(num.ToString("X2"));
            return stringBuilder.ToString();
        }

        public static string DecodeHexadecimal(this string inputString)
        {
            byte[] bytes = new byte[inputString.Length / 2];
            for (int index = 0; index < bytes.Length; ++index)
                bytes[index] = Convert.ToByte(inputString.Substring(index * 2, 2), 16);
            return Encoding.UTF8.GetString(bytes);
        }

        public static bool IsHexadecimal(this string value)
        {
            Regex regex = new Regex("^[a-fA-F0-9]+$", RegexOptions.IgnoreCase);
            return value != null && regex.IsMatch(value);
        }
    }
}
