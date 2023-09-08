// cadete.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EspacioCadeteria;


class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos = new List<Pedido>();
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
    }

    public decimal JornalACobrar()
    {
        return ListadoPedidos.Count * 500;
    }

    public void AgregarPedido(Pedido pedido)
    {
        ListadoPedidos.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido)
    {
        ListadoPedidos.Remove(pedido);
    }

    public string Estado()
    {
        return ListadoPedidos.Any() ? "Activo" : "Inactivo";
    }
}
