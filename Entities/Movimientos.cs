using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroservicioPrueba.Entities;

public class Movimientos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int mo_id_movimiento { get; set; }

    public DateTime mo_fecha { get; set; }

    [ForeignKey("Cuenta")]
    public int mo_id_cuenta { get; set; }
    public Cuenta Cuenta { get; set; }

    [ForeignKey("TipoMovimiento")]
    public int mo_tipo { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }

    public decimal mo_valor { get; set; }

    public decimal mo_saldo_final { get; set; }
}

