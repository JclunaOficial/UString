# UString

Es una libreria creada con Microsoft .NET v4.0 y compilada con el nombre JclunaOficial.UString.dll, 
el cual contiene funciones para manipular `strings` con el objetivo reducir el código para evaluar 
el estado de una cadena.

Las funciones son publicas (`public`) y compartidas (`static`) para que se puedan consumir sin necesidad 
de crear una instancia de la clase `UString`; adicionalmente se pueden accesar a las funciones como 
metodos extendidos (`extension method`) con los tipos de datos `string` y `DateTime`.

### Requerimientos

* **Microsoft Visual Studio Community 2015**, _de preferencia trabajar con la actualización más reciente del IDE_.
* **Microsoft .NET v4.0+**, _seguramente incluido en VS2015 pero probablemente se quiera compilar usando la linea de comandos_.
* **Xamarin Studio**, _en caso de querer compilar en otra plataforma (Linux o Mac), aunque el compilado con Windows se puede consumir en otras plataformas_.

El proyecto esta creado con VS2015 Community y .NET v4.0, pero se pueden copiar los bytes (código) a otros 
IDEs para compilar y generar la libreria, prosupuesto configurando los ajustes necesarios para tener el 
producto final.

### Compilado

Si solo quieres la versión compilada de la libreria, entonces la puedes descargar haciendo 
<a target="_blank" href="https://www.dropbox.com/sh/dk5x9x4733xb3ea/AADVJLizScmX0UTfe3J4ywbZa?dl=0"
title="Dropbox">click aquí</a>. Vas a encontrar todas las versiones que se han generado 
(Release y Debug); recomiendo uses la más reciente.

### Ejemplo (C-Sharp)

En el siguiente bloque de código se muestra el como se trabaja con las funciones en modo `extension method`; pero también se pueden ejecutar como funciones estaticas de la siguiente forma: `UString.Clean()`

```csharp
using JclunaOficial; // importar el namespace
using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // limpiar un string con valor nulo (null/nothing)
            string stringDummy = null;
            Console.WriteLine(stringDummy.Clean());
            // > resultado: string.Empty

            // asignar valor al string dummy para las siguientes pruebas
            stringDummy = "   string    con eSpacios     inTermedios    ";

            Console.WriteLine("limpiar el string de forma simple");
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy.Clean());
            // > resultado: 'string    con eSpacios     inTermedios'

            Console.WriteLine("limpiar el string y truncandolo a 15 caracteres");
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy.Clean(15));
            // > resultado: 'string    con e'

            Console.WriteLine("limpiar, truncar y convertir a mayúsculas");
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy.Upper(22));
            // > resultado: 'STRING    CON ESPACIOS'

            Console.WriteLine("limpiar, truncar y convertir a minúsculas");
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy.Lower(8));
            // > resultado: 'string  '

            Console.WriteLine("limpiar y quitar espacios intermedios");
            stringDummy = stringDummy.SingleSpace();
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy);
            // > resultado: 'string con eSpacios inTermedios'

            Console.WriteLine("codificar a Base64");
            stringDummy = stringDummy.Base64Convert();
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy);
            // > resultado: 'c3RyaW5nIGNvbiBlU3BhY2lvcyBpblRlcm1lZGlvcw=='

            Console.WriteLine("decodificar de Base64 y convertir a minúsculas");
            stringDummy = stringDummy.Base64Extract();
            Console.WriteLine("> resultado: '{0}'\r\n", stringDummy.Lower());
            // > resultado: 'string con espacios intermedios'

            var dateDummy = DateTime.Now;
            Console.WriteLine("convertir {0} a string con formato ISO-8859-1", dateDummy);
            Console.WriteLine("> resultado: '{0}'\r\n", dateDummy.DateTo());
            // > resultado: '2017-02-23T17:17:58' (o similar)

            Console.WriteLine("convertir {0} a string con formato ISO-8859-1 sin tiempo", dateDummy);
            Console.WriteLine("> resultado: '{0}'\r\n", dateDummy.DateTo(true));
            // > resultado: '2017-02-23' (o similar)

            stringDummy = "1979-03-14";
            dateDummy = stringDummy.DateFrom();
            Console.WriteLine("convertir '{0}' a DateTime", stringDummy);
            Console.WriteLine("> resultado: '{0}'\r\n", dateDummy);
            // > resultado: '1979-03-14 00:00:00' (o similar)

            stringDummy = "1960-02-12T17:38";
            dateDummy = stringDummy.DateFrom();
            Console.WriteLine("convertir '{0}' a DateTime", stringDummy);
            Console.WriteLine("> resultado: '{0}'\r\n", dateDummy);
            // > resultado: '1960-02-12 17:38:00' (o similar)
        }
    }
}

```
