using System;
namespace MicroservicioPrueba.Dto;

public class ReporteDto
{
    public DateTime fecha { get; set; }
    public string cliente { get; set; }
    public string cuenta { get; set; }
    public string tipoCuenta { get; set; }
    public char estadoCuenta { get; set; }
    public decimal movimiento{ get; set; }
    public decimal saldoFinal { get; set; }
}

