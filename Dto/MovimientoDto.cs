using MicroservicioPrueba.Entities;

namespace MicroservicioPrueba.Dto;

public class MovimientoDto
{
    public int id_cuenta { get; set; }

    public decimal valor { get; set; }

    public decimal saldo_final { get; set; }
}
