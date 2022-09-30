using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MicroservicioPrueba.Entities;
using MicroservicioPrueba.Interfaces;
using Microsoft.EntityFrameworkCore;
using MicroservicioPrueba.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MicroservicioPrueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientoController : Controller
{
    private IAppDBContext _context;
    private IMapper _mapper;

    public MovimientoController(IAppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{idMovimiento}")]
    public async Task<IActionResult> Get(int idMovimiento)
    {
        var res = await _context.Movimientos.Select(w => w.mo_id_movimiento == idMovimiento).FirstOrDefaultAsync();
        if (res == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(res);
        }
    }

    [HttpPost]
    public async Task<MovimientoDto> Post(MovimientoDto movs)
    {
        var cuenta = await _context.Cuenta.Where(w => w.cu_id_cuenta == movs.id_cuenta).FirstOrDefaultAsync();
        var parametros = await _context.Parametros.Where(w => w.par_id_parametro == 1).FirstOrDefaultAsync();
        int valorParametro = int.Parse(parametros.par_valor);

        if (cuenta == null)
        {
            throw new Exception("No se puede realizar el movimiento. Cuenta no Encontrada.");
        }
        if (cuenta.cu_estado != 'A')
        {
            throw new Exception("No se puede realizar el movimiento. Cuenta no se encuentra activa.");
        }
        if (cuenta.cu_saldo < movs.valor)
        {
            throw new Exception("No se puede realizar el movimiento. Saldo Insuficiente.");
        }
        if (movs.valor == 0)
        {
            throw new Exception("No se puede realizar el movimiento. El valor de la transaccion no puede ser 0.");
        }
        if (movs.valor < 0)
        {
            var movDiario = _context.Movimientos.Where(w => w.mo_id_cuenta == cuenta.cu_id_cuenta && w.mo_fecha.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && w.mo_tipo == 2);
            decimal sumaMonto = 0;

            foreach (var saldos in movDiario)
            {
                sumaMonto += saldos.mo_valor;
            }

            if (sumaMonto > valorParametro)
            {
                throw new Exception("No se puede realizar el movimiento. El monto de la transaccion excede el monto diario permitido.");
            }
        }

        Movimientos objMov = new Movimientos();
        objMov.mo_id_cuenta = movs.id_cuenta;
        objMov.mo_fecha = DateTime.Now.Date;
        if(movs.valor < 0)
        {
            objMov.mo_tipo = 2;
        }
        else
        {
            objMov.mo_tipo = 1;
        }
        objMov.mo_id_cuenta = movs.id_cuenta;
        objMov.mo_valor = movs.valor;
        objMov.mo_saldo_final = (cuenta.cu_saldo + movs.valor);

        _context.Movimientos.Add(objMov);
        cuenta.cu_saldo = (cuenta.cu_saldo + movs.valor);
        await _context.SaveChangesAsync();

        return movs;
    }

}