using System;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Definir valores base
        decimal valorSMLV = 1500000;
        decimal valorHora = valorSMLV / 160;
        decimal valorHoraDominical = valorHora * 2;
        CultureInfo cultura = new CultureInfo("en-US");

        // Pedir nombre
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        // Validar ingreso de horas trabajadas (máximo 624)
        decimal horasTrabajadas = LeerDecimal("Ingrese la cantidad de horas trabajadas (Máx: 624): ", 0, 624);

        // Validar si trabajó horas dominicales
        int preguntaHorasDominicales = LeerEntero("¿Trabajó horas dominicales? (1=Sí / 2=No): ", 1, 2);

        decimal horasDominicales = 0;
        if (preguntaHorasDominicales == 1)
        {
            // Validar horas dominicales (máximo 96 y que la suma no supere 720)
            horasDominicales = LeerDecimal($"Ingrese la cantidad de horas trabajadas los domingos (Máx: 96, Total no mayor a {720 - horasTrabajadas}): ", 0, Math.Min(96, 720 - horasTrabajadas));

            decimal totalSalario = (horasTrabajadas * valorHora) + (horasDominicales * valorHoraDominical);
            totalSalario = Math.Max(totalSalario, valorSMLV);

            Console.WriteLine($"\n📋 Resumen de nómina para {nombre}");
            Console.WriteLine($"Horas normales: {horasTrabajadas} x {valorHora:C} = {(horasTrabajadas * valorHora):C}");
            Console.WriteLine($"Horas en domingo: {horasDominicales} x {valorHoraDominical:C} = {(horasDominicales * valorHoraDominical):C}");
            Console.WriteLine($"💰 Total a pagar: {totalSalario:C}");
        }
        else
        {
            decimal totalSalario = Math.Max(valorHora * horasTrabajadas, valorSMLV);

            Console.WriteLine($"\n📋 Resumen de nómina para {nombre}");
            Console.WriteLine($"Horas normales: {horasTrabajadas} x {valorHora:C} = {(horasTrabajadas * valorHora):C}");
            Console.WriteLine($"💰 Total a pagar: {totalSalario:C}");
        }
    }

    // Función para leer y validar números decimales con un rango permitido
    static decimal LeerDecimal(string mensaje, decimal min, decimal max)
    {
        decimal numero;
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine().Trim();

            // Verifica que la entrada tenga solo un punto decimal y solo números
            if (Regex.IsMatch(entrada, @"^-?\d+(\.\d+)?$") &&
                decimal.TryParse(entrada, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out numero) &&
                numero >= min && numero <= max)
            {
                return numero;
            }
            Console.WriteLine($"❌ Error: Ingrese un número decimal válido entre {min} y {max}.");
        }
    }

    // Función para leer y validar números enteros dentro de un rango
    static int LeerEntero(string mensaje, int min, int max)
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine().Trim();

            if (int.TryParse(entrada, out numero) && numero >= min && numero <= max)
            {
                return numero;
            }
            Console.WriteLine($"❌ Error: Ingrese un número válido entre {min} y {max}.");
        }
    }
}
