// pedidos.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EspacioCadeteria;

class Pedido
{   
    private int numero;
    private string observacion;
    private Cliente cliente;
    private string estado;
    private Cadete cadeteAsignado; //referencia a Cadete tp2

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }

    //propiedad Cadete asignado tp2
    public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

    public Pedido(int numero, string observacion, Cliente cliente, string estado)
    {
        this.Numero = numero;
        this.Observacion = observacion;
        this.Cliente = cliente;
        this.Estado = estado;
         this.CadeteAsignado = null; // Inicialmente ningún cadete tp2
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"Dirección del Cliente: {Cliente.Direccion}");
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"Nombre del Cliente: {Cliente.NombreCliente}");
        Console.WriteLine($"Teléfono del Cliente: {Cliente.Telefono}");
    }

    public string ObtenerEstado()
    {
        return Estado;
    }
}