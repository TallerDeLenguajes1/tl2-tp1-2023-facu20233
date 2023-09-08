// programs.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EspacioCadeteria;


class Program
{
    static void Main()
    {
        //-----cargar datos-------

        // Cargar datos cadetes CSV
        // CSV Id, Nombre, Direccion, Telefono
        List<Cadete> cadetes = File.ReadAllLines("cadetes.csv")
            .Skip(1) // Saltar la primera línea si contiene encabezados
            .Select(line =>
            {
                var values = line.Split(',');
                return new Cadete(
                    int.Parse(values[0]),
                    values[1],
                    values[2],
                    values[3]
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
                    int.Parse(values[0]),
                    values[1],
                    cliente,
                    values[3]
                );
            })
            .ToList();

        // ---interfaz------
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
                    // dar de alta un pedido
                    Console.WriteLine("Ingrese número del pedido:");
                    int numeroPedido = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Ingrese observación:");
                    string observacion = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese nombre cliente:");
                    string nombreCliente = Console.ReadLine();

                    // datos del cliente, como dirección y teléfono.

                    // Crear un nuevo cliente
                    var cliente = new Cliente(nombreCliente, "Dirección", "Teléfono", "Datos de referencia de dirección");

                    // var cliente = new Cliente
                    // {
                    //     Nombre = nombreCliente,
                    //     // Asigna los otros datos del cliente aquí.
                    // };

                    // Crear un nuevo pedido
                    var nuevoPedido = new Pedido(numeroPedido, "vacio", cliente, "pendiente");

                    // var nuevoPedido = new Pedido
                    // {
                    //     Numero = numeroPedido,
                    //     Observacion = observacion,
                    //     Cliente = cliente,
                    //     Estado = "Pendiente" // establecer el estado inicial aquí.
                    // };

                    // Agregar pedido, lista de pedidos
                    pedidos.Add(nuevoPedido);
                    break;

                case 2:
                    // Lógica para asignar un pedido a un cadete
                    Console.WriteLine("Ingrese el número del pedido que desea asignar:");
                    int numeroPedidoAsignar = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el ID cadete al que desea asignar el pedido:");
                    int idCadeteAsignar = int.Parse(Console.ReadLine());

                    // Buscar el pedido y el cadete por número y ID, respectivamente
                    var pedidoAsignar = pedidos.FirstOrDefault(p => p.Numero == numeroPedidoAsignar);
                    var cadeteAsignar = cadetes.FirstOrDefault(c => c.Id == idCadeteAsignar);

                    if (pedidoAsignar != null && cadeteAsignar != null)
                    {
                        // Asignar el pedido al cadete
                        cadeteAsignar.AgregarPedido(pedidoAsignar);
                        Console.WriteLine("Pedido asignado correctamente al cadete.");
                    }
                    else
                    {
                        Console.WriteLine("Pedido o cadete no encontrados. Verificar numeros y ID");
                    }
                    break;

                case 3:
                    // cambiar estado pedido
                    Console.WriteLine("Ingrese el número del pedido que desea cambiar de estado:");
                    int numeroPedidoCambiarEstado = int.Parse(Console.ReadLine());

                    // Buscar el pedido por número
                    var pedidoCambiarEstado = pedidos.FirstOrDefault(p => p.Numero == numeroPedidoCambiarEstado);

                    if (pedidoCambiarEstado != null)
                    {
                        Console.WriteLine("Ingrese nuevo estado pedido:");
                        string nuevoEstado = Console.ReadLine();
                        pedidoCambiarEstado.Estado = nuevoEstado;
                        Console.WriteLine("Estado pedido actualizado");
                    }
                    else
                    {
                        Console.WriteLine("Pedido no encontrado. Verifique numero pedido.");
                    }
                    break;

                case 4:
                    // reasignar a otro cadete
                    Console.WriteLine("Ingrese numero del pedido que desea reasignar:");
                    int numeroPedidoReasignar = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese ID del nuevo cadete para reasignar el pedido:");
                    int idNuevoCadete = int.Parse(Console.ReadLine());

                    // Buscar pedido y nuevo cadete por numero y ID
                    var pedidoReasignar = pedidos.FirstOrDefault(p => p.Numero == numeroPedidoReasignar);
                    var nuevoCadete = cadetes.FirstOrDefault(c => c.Id == idNuevoCadete);

                    if (pedidoReasignar != null && nuevoCadete != null)
                    {
                        // Eliminar pedido del cadete anterior
                        foreach (var cadete in cadetes)
                        {
                            if (cadete.ListadoPedidos.Contains(pedidoReasignar))
                            {
                                cadete.ListadoPedidos.Remove(pedidoReasignar);
                                break; // Salir del bucle una vez encontrado el cadete 
                            }
                        }

                        // Asignar el pedido al nuevo cadete
                        nuevoCadete.AgregarPedido(pedidoReasignar);
                        Console.WriteLine("Pedido reasignado");
                    }
                    else
                    {
                        Console.WriteLine("Pedido o cadete no encontrados. Verifique numeros y ID");
                    }
                    break;

                case 5:
                    // mostrar el informe de pedidos
                    Console.WriteLine("----------Informe de pedidos:---------");

                    int totalEnvios = 0; //total de envíos

                    foreach (var cadete in cadetes)
                    {
                        decimal montoGanado = cadete.JornalACobrar();
                        int cantidadEnvios = cadete.ListadoPedidos.Count;
                        decimal enviosPromedio = cantidadEnvios > 0 ? montoGanado / cantidadEnvios : 0;

                        Console.WriteLine($"Cadete: {cadete.Nombre}");
                        Console.WriteLine($"Monto Ganado: {montoGanado:C}");
                        Console.WriteLine($"Cantidad de Envíos: {cantidadEnvios}");
                        Console.WriteLine($"Envíos Promedio: {enviosPromedio:C}");
                        Console.WriteLine();

                        totalEnvios += cantidadEnvios; // Sumar envíos del cadete al total
                    }

                    // cantidad total envios
                    Console.WriteLine($"Total Envíos Realizados: {totalEnvios}");

                    // promedio envios
                    decimal promedioEnvios = cadetes.Count > 0 ? (decimal)totalEnvios / cadetes.Count : 0;
                    Console.WriteLine($"Promedio Envíos por Cadete: {promedioEnvios:F2}");
                    break;


                case 6:
                    // Salir programa
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

        }
        

    }
}
