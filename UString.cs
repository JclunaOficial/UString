using System;

namespace Jcluna
{
    public static class UString
    {
        /// <summary>
        /// Limpiar y truncar un string
        /// </summary>
        /// <param name="value">String a procesar</param>
        /// <param name="length">Longitud a truncar el String</param>
        /// <returns></returns>
        public static string Clean(this string value, int length = 0)
        {
            // remover los espacios al inicio y final del string
            var result = string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
                result = value.Trim();

            // truncar el string si length es mayor a cero
            if (length > 0 && result.Length > length)
                result = result.Substring(0, length);

            // string procesado
            return result;
        }

        /// <summary>
        /// Limpiar, truncar y convertir un string a mayúsculas
        /// </summary>
        /// <param name="value">String a procesar</param>
        /// <param name="length">Longitud a truncar el String</param>
        /// <returns></returns>
        public static string Upper(this string value, int length = 0)
        {
            // consumir función Clean() y convertir a mayúsculas
            return value.Clean(length).ToUpper();
        }

        /// <summary>
        /// Limpiar, truncar y convertir un string a minúsculas
        /// </summary>
        /// <param name="value">String a procesar</param>
        /// <param name="length">Longitud a truncar el String</param>
        /// <returns></returns>
        public static string Lower(this string value, int length = 0)
        {
            // consumir función Clean() y convertir a minúsculas
            return value.Clean(length).ToLower();
        }

        /// <summary>
        /// Reemplazar multiples espacios a uno solo y truncar un string
        /// </summary>
        /// <param name="value">String a procesar</param>
        /// <param name="length">Longitud a truncar el String</param>
        /// <returns></returns>
        public static string SingleSpace(this string value, int length)
        {
            // cosumir función Clean() para remover espacios inicial/final
            var result = value.Clean();
            if (result.Length > 0)
            {
                while (true)
                {
                    // localizar espacios dobles y reemplazar por un espacio
                    if (result.IndexOf("  ", StringComparison.Ordinal) <= -1)
                        break; // ya no hay espacios dobles

                    // reemplazar espacio doble por un espacio
                    result = result.Replace("  ", " ");
                }

                // truncar el string si length es mayor a cero
                if (length > 0 && result.Length > length)
                    result = result.Substring(0, length);
            }

            // string procesado
            return result;
        }
    }
}
