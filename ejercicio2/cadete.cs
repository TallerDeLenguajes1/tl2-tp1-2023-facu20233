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
    
    public Cadete(string nombre, string direccion, string telefono)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public decimal CalcularJornal()
    {
        decimal jornalBase = 500; // Define el jornal base
        int cantidadPedidos = ListadoPedidos.Count; // Cantidad de pedidos asignados

        // Calcula el jornal total
        decimal jornalTotal = jornalBase * cantidadPedidos;

        return jornalTotal;
    }

    // public Cadete(int id, string nombre, string direccion, string telefono)
    // {
    //     this.Id = id;
    //     this.Nombre = nombre;
    //     this.Direccion = direccion;
    //     this.Telefono = telefono;
    // }

    // modificar
    // public decimal JornalACobrar()
    // {
    //     decimal jornalBase = 500; 
    //     int cantidadPedidos = ListadoPedidos.Count; //cant pedidos asignados

    //     // Calcula el jornal 
    //     decimal jornalTotal = jornalBase * cantidadPedidos;

    //     return jornalTotal;
    // }

    // sacar
    // public void AgregarPedido(Pedido pedido)
    // {
    //     ListadoPedidos.Add(pedido);
    // }

    // public void EliminarPedido(Pedido pedido)
    // {
    //     ListadoPedidos.Remove(pedido);
    // }

// public string Estado()
// {
//     //ver tiene pedidos asignados
//     if (ListadoPedidos.Count > 0)
//     {
//         return "Activo";
//     }
//     else
//     {
//         return "Inactivo";
//     }
// }


}


