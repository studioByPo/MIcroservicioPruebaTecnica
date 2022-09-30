using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class Persona
{
    public string pr_nombre { get; set; }

    public char pr_genero { get; set; }

    public int pr_edad { get; set; }

    public string pr_identificacion { get; set; }

    public string pr_direccion { get; set; }

    public string pr_telefono { get; set; }
}

