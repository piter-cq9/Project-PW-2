using System.Globalization;

// ===== Boleta de consumo (proyecto de prueba) =====

Console.WriteLine("=== SISTEMA DE CONSUMO ===");

Console.Write("Nombre del cliente: ");
string cliente = Console.ReadLine() ?? "Cliente";

int cantidadProductos = LeerEntero("Cuantos productos distintos consumio? ");

string[] nombres = new string[cantidadProductos];
decimal[] precios = new decimal[cantidadProductos];
int[] cantidades = new int[cantidadProductos];
decimal[] subtotales = new decimal[cantidadProductos];

decimal total = 0;

for (int i = 0; i < cantidadProductos; i++)
{
    Console.WriteLine($"\n--- Producto {i + 1} ---");
    Console.Write("Nombre: ");
    nombres[i] = Console.ReadLine() ?? "Producto";
    precios[i] = LeerDecimal("Precio unitario: ");
    cantidades[i] = LeerEntero("Cantidad: ");

    // MULTIPLICACION: precio x cantidad
    subtotales[i] = precios[i] * cantidades[i];

    // SUMA: acumular el total
    total = total + subtotales[i];
}

decimal descuentoPorcentaje = LeerDecimal("\nDescuento en % (0 si no hay): ");
decimal descuento = total * descuentoPorcentaje / 100;

// RESTA: total menos descuento
decimal totalAPagar = total - descuento;

int personas = LeerEntero("Entre cuantas personas se divide la cuenta? ");
if (personas < 1) personas = 1;

// DIVISION: total entre personas
decimal porPersona = totalAPagar / personas;

// ===== Boleta =====
Console.WriteLine("\n========================================");
Console.WriteLine("            BOLETA DE CONSUMO");
Console.WriteLine("========================================");
Console.WriteLine($"Cliente: {cliente}");
Console.WriteLine($"Fecha:   {DateTime.Now:dd/MM/yyyy HH:mm}");
Console.WriteLine("----------------------------------------");
Console.WriteLine($"{"Producto",-16}{"Cant",5}{"P.Unit",9}{"Subtotal",10}");
Console.WriteLine("----------------------------------------");

for (int i = 0; i < cantidadProductos; i++)
{
    Console.WriteLine($"{nombres[i],-16}{cantidades[i],5}{precios[i],9:F2}{subtotales[i],10:F2}");
}

Console.WriteLine("----------------------------------------");
Console.WriteLine($"{"Total consumo:",-30}{total,10:F2}");
Console.WriteLine($"{"Descuento (" + descuentoPorcentaje + "%):",-30}{"-" + descuento.ToString("F2"),10}");
Console.WriteLine($"{"TOTAL A PAGAR:",-30}{totalAPagar,10:F2}");
Console.WriteLine("----------------------------------------");
Console.WriteLine($"Dividido entre {personas} persona(s): {porPersona:F2} c/u");
Console.WriteLine("========================================");
Console.WriteLine("        Gracias por su visita!");
Console.WriteLine("========================================");

Console.WriteLine("\nPresione una tecla para salir...");
Console.ReadKey();

// ===== Funciones auxiliares =====

static int LeerEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
            return valor;
        Console.WriteLine("Valor invalido, intente de nuevo.");
    }
}

static decimal LeerDecimal(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string texto = (Console.ReadLine() ?? "").Replace(',', '.');
        if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor) && valor >= 0)
            return valor;
        Console.WriteLine("Valor invalido, intente de nuevo.");
    }
}
