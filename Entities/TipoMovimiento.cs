using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class TipoMovimiento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tm_id_tipo_movimiento { get; set; }

    public char tm_codigo { get; set; }

    public string tm_descripcion { get; set; }
}

