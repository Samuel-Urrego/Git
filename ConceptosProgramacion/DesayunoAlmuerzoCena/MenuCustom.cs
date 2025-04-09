using System;

class Program
{
    static void Main()
    {
        // Declaración de variables con ; al final
        string desayuno1 = "Café Con Leche";
        string desayuno2 = "Café Grone";
        string desayuno3 = "Calentado";
        string desayuno4 = "Empanada";
        string desayuno5 = "Pan de Bono";
        string desayuno6 = "Calentado de Frijoles";
        string desayuno7 = "Tierra Querida";
        string desayuno8 = "Cuca Rosada";
        string desayuno9 = "Cuca Amarilla";
        string desayuno10 = "Cuca Negra";
        string desayuno11 = "Empanada de Lechona";

        Console.WriteLine("Vamos a empezar a seleccionar los ingredientes del menú? (Si/No)");
        string iniciar = Console.ReadLine(); 

        if (iniciar == "Si")  
        {
            Console.WriteLine("Café con leche? (Si/No)");
            string opcion1 = Console.ReadLine();

            if (opcion1 == "Si") 
            {
                Console.WriteLine("Has seleccionado: " + desayuno1);
            }
            else
            {
                Console.WriteLine("No has seleccionado Café con Leche.");
            }
        }
        else
        {
            Console.WriteLine("Programa finalizado.");
        }
    }
}
