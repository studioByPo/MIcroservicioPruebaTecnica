using MicroservicioPrueba.Entities;

namespace MicroservicioPrueba.Dto;

public class CuentaDto
{
    public string numero { get; set; }

    public int cliente { get; set; }

    public int tipo { get; set; }

    public decimal saldo { get; set; }

    public char estado { get; set; }
}
