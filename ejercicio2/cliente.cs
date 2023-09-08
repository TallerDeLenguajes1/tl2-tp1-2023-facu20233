// cliente.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EspacioCadeteria;


class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;

    public string Nombre1 { get => nombre; set => nombre = value; }
    public string Direccion1 { get => direccion; set => direccion = value; }
    public string Telefono1 { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion1 { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.Nombre1 = nombre;
        this.Direccion1 = direccion;
        this.Telefono1 = telefono;
        this.DatosReferenciaDireccion1 = datosReferenciaDireccion;
    }

    // agregar
    public string Nombre
    {
        get { return Nombre1; }
    }

    public string Direccion
    {
        get { return Direccion1; }
    }

    public string Telefono
    {
        get { return Telefono1; }
    }

    public string DatosReferenciaDireccion
    {
        get { return DatosReferenciaDireccion1; }
    }

    
}
