// programs.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EspacioCadeteria;

class Program
{
    static void Main()
    {
        // ----- cargar datos -------

        // Cargar datos cadetes CSV
        // CSV Id, Nombre, Direccion, Telefono
        List<Cadete> cadetes = File.ReadAllLines("cadetes.csv")
            .Skip(1) // Saltar la primera línea si contiene encabezados
            .Select(line =>
            {
                var values = line.Split(',');
                return new Cadete(
                    values[1],  // nombre
                    values[2],  // direccion
                    values[3]   // telefono
                );
            })
            .ToList();

        // Cargar datos pedidos CSV
        // CSV: Numero, Observacion, Cliente, Estado
        List<Pedido> pedidos = File.ReadAllLines("pedidos.csv")
            .Skip(1)
            .Select(line =>
            {
                var values = line.Split(',');
                var cliente = new Cliente(values[2], "", "", ""); // Modificar si es necesario
                return new Pedido(
                    int.Parse(values[0]),  // numero
                    values[1],            // observacion
                    cliente,
                    values[3]             // estado
                );
            })
            .ToList();

        // instancia Cadeteria tp2
        Cadeteria cadeteria = new Cadeteria("Nombre de la Cadetería", "Teléfono de la Cadetería");

        // Asignar cadetes a la Cadeteria tp2
        cadeteria.ListadoCadetes = cadetes;

        // Asignar pedidos a la Cadeteria tp2
        cadeteria.ListadoPedidos = pedidos;

        // ------- interfaz --------
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("(1) Dar de alta un pedido");
            Console.WriteLine("(2) Asignar un pedido a un cadete");
            Console.WriteLine("(3) Cambiar estado de un pedido");
            Console.WriteLine("(4) Reasignar un pedido a otro cadete");
            Console.WriteLine("(5) Mostrar informe de pedidos");
            Console.WriteLine("(6) Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Dar de alta un pedido
                    Console.WriteLine("Ingrese número del pedido:");
                    int numeroPedido = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese observación:");
                    string observacion = Console.ReadLine();

                    Console.WriteLine("Ingrese nombre cliente:");
                    string nombreCliente = Console.ReadLine();

                    // Crear un nuevo cliente
                    var cliente = new Cliente(nombreCliente, "Dirección", "Teléfono", "Datos de referencia de dirección");

                    // Crear un nuevo pedido
                    var nuevoPedido = new Pedido(numeroPedido, observacion, cliente, "pendiente");

                    // Agregar pedido a la lista de pedidos de la Cadeteria
                    cadeteria.AgregarPedido(nuevoPedido);
                    Console.WriteLine("Pedido creado y agregado correctamente.");
                    break;

                case 2:
                    // Asignar un pedido a un cadete
                    Console.WriteLine("Ingrese el número del pedido que desea asignar:");
                    int numeroPedidoAsignar = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el ID del cadete al que desea asignar el pedido:");
                    int idCadeteAsignar = int.Parse(Console.ReadLine());

                    // Buscar el pedido y el cadete por número y ID, respectivamente
                    var pedidoAsignar = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedidoAsignar);
                    var cadeteAsignar = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadeteAsignar);

                    if (pedidoAsignar != null && cadeteAsignar != null)
                    {
                        // Asignar el cadete al pedido
                        cadeteria.AsignarCadeteAPedido(idCadeteAsignar, numeroPedidoAsignar);
                        Console.WriteLine("Pedido asignado correctamente al cadete.");
                    }
                    else
                    {
                        Console.WriteLine("Pedido o cadete no encontrados. Verificar números y ID.");
                    }
                    break;

                case 3:
                    // Cambiar estado de un pedido
                    Console.WriteLine("Ingrese el número del pedido que desea cambiar de estado:");
                    int numeroPedidoCambiarEstado = int.Parse(Console.ReadLine());

                    // Buscar el pedido por número
                    var pedidoCambiarEstado = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedidoCambiarEstado);

                    if (pedidoCambiarEstado != null)
                    {
                        Console.WriteLine("Ingrese nuevo estado del pedido:");
                        string nuevoEstado = Console.ReadLine();
                        pedidoCambiarEstado.Estado = nuevoEstado;
                        Console.WriteLine("Estado del pedido actualizado.");
                    }
                    else
                    {
                        Console.WriteLine("Pedido no encontrado. Verifique número de pedido.");
                    }
                    break;

                case 4:
                    // Reasignar un pedido a otro cadete
                    Console.WriteLine("Ingrese el número del pedido que desea reasignar:");
                    int numeroPedidoReasignar = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el ID del nuevo cadete para reasignar el pedido:");
                    int idNuevoCadete = int.Parse(Console.ReadLine());

                    // Buscar pedido y nuevo cadete por número y ID
                    var pedidoReasignar = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == numeroPedidoReasignar);
                    var nuevoCadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);

                    if (pedidoReasignar != null && nuevoCadete != null)
                    {
                        // Reasignar el pedido al nuevo cadete
                        cadeteria.ReasignarPedidoAPedido(idNuevoCadete, numeroPedidoReasignar);
                        Console.WriteLine("Pedido reasignado.");
                    }
                    else
                    {
                        Console.WriteLine("Pedido o cadete no encontrados. Verificar números y ID.");
                    }
                    break;

                case 5:
                    // Mostrar informe de pedidos
                    Console.WriteLine("----------Informe de pedidos:---------");

                    foreach (var cadete in cadeteria.ListadoCadetes)
                    {
                        Console.WriteLine($"Cadete: {cadete.Nombre}");
                        Console.WriteLine($"Monto Ganado: {cadeteria.JornalACobrar(cadete.Id):C}");
                        Console.WriteLine($"Cantidad de Envíos: {cadeteria.CantidadEnviosCadete(cadete.Id)}");
                        Console.WriteLine($"Envíos Promedio: {cadeteria.PromedioEnviosCadete(cadete.Id):C}");
                        Console.WriteLine();
                    }

                    // cantidad total envios
                    Console.WriteLine($"Total Envíos Realizados: {cadeteria.CantidadTotalEnvios}");

                    // promedio envios
                    decimal promedioEnvios = cadeteria.ListadoCadetes.Count > 0 ?
                        (decimal)cadeteria.CantidadTotalEnvios / cadeteria.ListadoCadetes.Count : 0;
                    Console.WriteLine($"Promedio Envíos por Cadete: {promedioEnvios:F2}");
                    break;

                case 6:
                    // Salir del programa
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}
