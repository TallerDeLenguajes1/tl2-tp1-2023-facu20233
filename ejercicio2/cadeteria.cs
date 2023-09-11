// cadeteria.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EspacioCadeteria;


class Cadeteria
{
    private string nombre;
    private string telefono;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    private List<Cadete> listadoCadetes = new List<Cadete>();
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    // Lista de pedidos tp2
    private List<Pedido> listadoPedidos = new List<Pedido>();
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
    }

    public void AgregarCadete(Cadete cadete)
    {
        ListadoCadetes.Add(cadete);
    }

    public void EliminarCadete(Cadete cadete)
    {
        ListadoCadetes.Remove(cadete);
    }

    // tp2
    public void AgregarPedido(Pedido pedido)
    {
        ListadoPedidos.Add(pedido);
    }

    // tp2
    public void EliminarPedido(Pedido pedido)
    {
        ListadoPedidos.Remove(pedido);
    }

    // tp2
    public decimal JornalACobrar(int cadeteId)
    {
        // Buscar ID
        Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == cadeteId);

        if (cadete != null)
        {
            // Calcular jornal
            decimal jornalCadete = cadete.JornalACobrar(); // Usar el método del cadete
            return jornalCadete;
        }
        else
        {
            throw new InvalidOperationException("Cadete no encontrado.");
        }
    }

    // tp2
    public void AsignarCadeteAPedido(int cadeteId, int pedidoId)
    {
        // Buscar cadete ID
        Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == cadeteId);

        // Buscar pedido ID
        Pedido pedido = ListadoPedidos.FirstOrDefault(p => p.Numero == pedidoId);

        if (cadete != null && pedido != null)
        {
            // Asignar cadete al pedido
            pedido.CadeteAsignado = cadete;
        }
        else
        {
            throw new InvalidOperationException("Cadete o pedido no encontrado.");
        }
    }

    // tp2
    public void ReasignarPedidoAPedido(int nuevoCadeteId, int pedidoId)
    {
        // Buscar pedido por número
        Pedido pedido = ListadoPedidos.FirstOrDefault(p => p.Numero == pedidoId);

        // Buscar nuevo cadete por ID
        Cadete nuevoCadete = ListadoCadetes.FirstOrDefault(c => c.Id == nuevoCadeteId);

        if (pedido != null && nuevoCadete != null)
        {
            // Asignar nuevo cadete al pedido
            pedido.CadeteAsignado = nuevoCadete;
        }
        else
        {
            throw new InvalidOperationException("Pedido o cadete no encontrado.");
        }
    }

    // tp2
    public int CantidadEnviosCadete(int cadeteId)
    {
        // Buscar ID
        Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == cadeteId);

        if (cadete != null)
        {
            // Contar los pedidos asignados al cadete
            int cantidadEnvios = ListadoPedidos.Count(p => p.CadeteAsignado != null && p.CadeteAsignado.Id == cadeteId);
            return cantidadEnvios;
        }
        else
        {
            throw new InvalidOperationException("Cadete no encontrado.");
        }
    }

    // tp2
    public decimal PromedioEnviosCadete(int cadeteId)
    {
        // Buscar ID
        Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == cadeteId);

        if (cadete != null)
        {
            // Calcular el promedio de envíos del cadete
            int cantidadEnvios = CantidadEnviosCadete(cadeteId);
            decimal jornalCadete = cadete.JornalACobrar(); // Usar el método del cadete
            if (cantidadEnvios > 0)
            {
                decimal promedio = jornalCadete / cantidadEnvios;
                return promedio;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            throw new InvalidOperationException("Cadete no encontrado.");
        }
    }

    // tp2
    public int CantidadTotalEnvios
    {
        get
        {
            // Contar la cantidad total de pedidos
            return ListadoPedidos.Count;
        }
    }
}