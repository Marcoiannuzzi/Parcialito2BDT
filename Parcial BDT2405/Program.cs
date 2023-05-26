
// Parcial BDT 24 de Mayo 2023

string[] codigoArticulo = new string[10] { "A01", "A02", "A03", "A04", "A05", "A06", "A07", "A08", "A09", "A10" };
int[] stockArticulo = new int[10] { 15, 20, 5, 4, 6, 8, 9, 7, 10, 10 };
int[] precioArticulo = new int[10] { 100, 200, 550, 250, 1500, 120, 1555, 980, 1540, 100 };
int ultimaFactura = 12506;
int cantidadDeItems;
int totalVendido = 0;
int contadorFacturas = 0;
int facturaConMasItems = 0;
int articuloMasVendido;


var nuevaVenta = Continuar();

while (nuevaVenta == "S")
{
    string agregarItem;
    int maxItem = 0;
    ultimaFactura++;
    contadorFacturas ++;
    var facturaVenta = ultimaFactura;
    cantidadDeItems = 0;
    var totalFacturaActutal = 0;
    do
    {
        totalFacturaActutal += IngresarItem();
        Console.WriteLine($"El Total parcial es de ${totalFacturaActutal}");
        agregarItem = Continuar();

    } while (agregarItem == "s");

    if(cantidadDeItems > maxItem)
    {
        facturaConMasItems = facturaVenta;
    }

    Console.WriteLine($"El total de la factura {facturaVenta} es de {totalFacturaActutal}");
    Console.WriteLine($"El total de Items de por cada articulo es de {cantidadDeItems}");

    totalVendido += totalFacturaActutal;
    nuevaVenta = Continuar();
}

Console.WriteLine($"El total vendido es de {totalVendido}");
Console.WriteLine($"La cantidad de facturas emitidas fue de {contadorFacturas}");
Console.WriteLine($"La factura con mas items fue: {facturaConMasItems}");


int IngresarItem()
{
    int venta = 0;
    int cant = 0;
    Console.WriteLine("Ingrese el codigo del Articulo");
    var res = Console.ReadLine().ToUpper();

    for(int i = 0; i < codigoArticulo.Length; i++)
    {
        if (codigoArticulo[i] == res)
        {
            Console.WriteLine($"Articulo: {codigoArticulo[i]}, Stock: {stockArticulo[i]}, Precio: ${precioArticulo[i]}");
            cant = IngresarCantidadVendida();
            while(cant > stockArticulo[i])
            {
                Console.WriteLine($"Solo hay {stockArticulo[i]} unidades del articulo {codigoArticulo[i]}");
                cant = IngresarCantidadVendida();
            }
            var confirmar = Continuar();
            if(confirmar == "S")
            {
                Console.WriteLine("Resumen de operacion:");
                Console.WriteLine("");
                Console.WriteLine($"{cant} unidades de {codigoArticulo[i]}");
                Console.WriteLine($"");
                Console.WriteLine($"Total a abonar: {precioArticulo[i]*cant}");
                var concretar = Continuar();
                if (concretar == "S")
                {
                    stockArticulo[i] -= cant;
                    venta = precioArticulo[i] * cant;
                    cantidadDeItems += cant;
                }
            }
        }
    }
    return venta;
}

int IngresarCantidadVendida()
{
    Console.WriteLine("Ingrese la cantidad deseada");
    var res = Console.ReadLine();
    var esNum = int.TryParse(res, out int result);
    while (!esNum && (result < 0))
    {
        Console.WriteLine("Error, Vuelva a ingresar la cantidad");
        res = Console.ReadLine();
    }
    return result;
}


string Continuar()
{
    Console.WriteLine("Desea continuar? (S/N)");
    var res = Console.ReadLine().ToUpper();

    while (res != "S" && res != "N")
    {
        Console.WriteLine("Error, vuelva a ingresar la respuesta. (S/N)");
        res = Console.ReadLine();
    }

    return res;
}

