using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Pedido
{   
    private int numero;
    private string observacion;
    private Cliente cliente;
    private string estado;

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }

    public Pedido(int numero, string observacion, Cliente cliente, string estado)
    {
        this.Numero = numero;
        this.Observacion = observacion;
        this.Cliente = cliente;
        this.Estado = estado;
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"Dirección del Cliente: {Cliente.Direccion}");
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"Nombre del Cliente: {Cliente.Nombre}");
        Console.WriteLine($"Teléfono del Cliente: {Cliente.Telefono}");
    }

    public string ObtenerEstado()
    {
        return Estado;
    }
}