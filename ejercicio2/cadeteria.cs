using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Cadeteria
{
    private string nombre;
    private string telefono;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    private List<Cadete> listadoCadetes = new List<Cadete>();
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

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
}