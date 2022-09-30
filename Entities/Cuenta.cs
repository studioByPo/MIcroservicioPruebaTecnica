using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class Cuenta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int cu_id_cuenta { get; set; }

    public string cu_numero { get; set; }

    [ForeignKey("Cliente")]
    public int cu_cliente { get; set; }
    public Cliente Cliente { get; set; }

    [ForeignKey("TipoCuenta")]
    public int cu_tipo { get; set; }
    public TipoCuenta TipoCuenta { get; set; }

    public decimal cu_saldo { get; set; }

    public char cu_estado { get; set; }
}

