using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class Parametros
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int par_id_parametro { get; set; }

    public string par_descripcion { get; set; }

    public string par_valor { get; set; }
    
}

