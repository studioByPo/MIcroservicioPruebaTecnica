using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class TipoCuenta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tc_id_tipo_cuenta { get; set; }

    public char tc_codigo { get; set; }

    public string tc_descripcion { get; set; }
}

