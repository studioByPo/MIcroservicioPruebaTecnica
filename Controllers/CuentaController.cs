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

namespace MicroservicioPrueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentaController : Controller
{
    private IAppDBContext _context;
    private IMapper _mapper;

    public CuentaController(IAppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{numeroCuenta}")]
    public async Task<IActionResult> Get(string numeroCuenta)
    {
        var res = await _context.Cuenta.Where(w => w.cu_numero == numeroCuenta).FirstOrDefaultAsync();
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
    public async Task<CuentaDto> Post(CuentaDto cuentas)
    {
        var idtf = await _context.Cliente.Where(w => w.cl_id_cliente == cuentas.cliente).FirstOrDefaultAsync();
        if (idtf == null)
        {
            throw new Exception("No se puede crear la cuenta. Cliente No Encontrado.");
        }

        var idtc = await _context.TipoCuenta.Where(w => w.tc_id_tipo_cuenta == cuentas.tipo).FirstOrDefaultAsync();
        if (idtc == null)
        {
            throw new Exception("No se puede crear la cuenta. Tipo de Cuenta No Definido.");
        }

        Cuenta objCuenta = new Cuenta();
        objCuenta.cu_numero = cuentas.numero;
        objCuenta.cu_cliente = cuentas.cliente;
        objCuenta.cu_tipo = cuentas.tipo;
        objCuenta.cu_saldo = cuentas.saldo;
        objCuenta.cu_estado = cuentas.estado;

        _context.Cuenta.Add(objCuenta);
        await _context.SaveChangesAsync();

        return cuentas;
    }

    [HttpPut("{numeroCuenta}")]
    public async Task<IActionResult> Put(CuentaDto cuentas, string numeroCuenta)
    {
        if (numeroCuenta != cuentas.numero)
        {
            throw new Exception();
        }

        var res = await _context.Cuenta.Where(w => w.cu_numero == numeroCuenta).FirstOrDefaultAsync();

        if (res == null)
        {
            return NotFound();
        }
        else
        {
            res.cu_numero = cuentas.numero;
            res.cu_cliente = cuentas.cliente;
            res.cu_tipo = cuentas.tipo;
            res.cu_saldo = cuentas.saldo;
            res.cu_estado = cuentas.estado;
            await _context.SaveChangesAsync();
            return Ok(res);
        }

    }

    [HttpDelete("{numeroCuenta}")]
    public async Task<IActionResult> Delete(string numeroCuenta)
    {
        var res = await _context.Cuenta.Where(w => w.cu_numero == numeroCuenta).FirstOrDefaultAsync();

        if (res == null)
        {
            return NotFound();
        }
        else
        {
            _context.Cuenta.Remove(res);
            await _context.SaveChangesAsync();
            return Ok(numeroCuenta);
        }
    }
}