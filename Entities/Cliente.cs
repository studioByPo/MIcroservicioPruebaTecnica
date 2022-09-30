using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class Cliente : Persona
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int cl_id_cliente { get; set; }

    public string cl_password { get; set; }

    public bool cl_estado { get; set; }
}

