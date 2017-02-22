using System;
using System.Text;

namespace JclunaOficial
{
    /// <summary>
    /// Funciones (extension) de utilidad para strings
    /// </summary>
    public static class UString
    {
        /// <summary>
        /// Códificación de caracteres latinos (ISO-8859-1)
        /// </summary>
        public static readonly Encoding Latin = Encoding.GetEncoding("ISO-8859-1");

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
            // limpiar y convertir a mayúsculas
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
            // limpiar y convertir a minúsculas
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
            // limpiar string
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

        /// <summary>
        /// Convertir un string a un string en Base64
        /// </summary>
        /// <param name="value">String a procesar</param>
        /// <returns></returns>
        public static string Base64Convert(this string value)
        {
            // limpiar string
            var result = value.Clean();
            if (result.Length > 0) // convertir a Base64 un texto plano
                result = Convert.ToBase64String(Latin.GetBytes(result));
            return result;
        }

        /// <summary>
        /// Extraer un string desde un string en Base64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64Extract(this string value)
        {
            // limpiar string
            var result = value.Clean();
            if (result.Length > 0) // extraer el texto plano de un string en Base64
                result = Latin.GetString(Convert.FromBase64String(result));
            return result;
        }

        /// <summary>
        /// Extraer la fecha en formato ISO-8601 de un objeto <see cref="DateTime"/>
        /// </summary>
        /// <param name="value">Objeto <see cref="DateTime"/> a procesar</param>
        /// <param name="excludeTime">Excluir la hora de la fecha</param>
        /// <param name="excludeSeconds">Excluir los segundos de la hora</param>
        /// <returns>Regresa un string con formato ISO-8601 (yyyy-MM-ddTHH:mm:ss)</returns>
        public static string DateTo(this DateTime value, bool excludeTime = false, bool excludeSeconds = false)
        {
            // verificar que value tenga fecha asignada
            var result = string.Empty;
            if (value.Equals(DateTime.MinValue))
                return result; // no hay fecha

            // formatear la fecha en base al ISO-8601
            result = string.Format("{0:yyyy-MM-dd}", value);

            // integrar la hora y minutos
            if (excludeTime == false)
            {
                result += string.Format("T{0:HH:mm}", value);

                // integrar los segundos
                if (excludeSeconds == false)
                    result += string.Format(":{0:ss}", value);
            }
            return result;
        }
    }
}
