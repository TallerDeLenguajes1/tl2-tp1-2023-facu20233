// cliente.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EspacioCadeteria;

 class Cliente
{
    public string NombreCliente {get; set;}
    public string Direccion {get; set;}
    public string Telefono {get; set;}
    public string DatosReferenciaDireccion {get; set;}

    public Cliente(string nombreCliente, string direccion, string telefono, string datosReferenciaDireccion)
    {
        NombreCliente = nombreCliente;
        Direccion = direccion;
        Telefono = telefono;
        DatosReferenciaDireccion = datosReferenciaDireccion;
    }

}





    
    

