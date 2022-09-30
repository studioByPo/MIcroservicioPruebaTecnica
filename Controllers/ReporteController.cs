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
using System.Security.Authentication;

namespace MicroservicioPrueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReporteController : Controller
{
    private IAppDBContext _context;
    private IMapper _mapper;

    public ReporteController(IAppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{fechaInicial}/{fechaFinal}/{identificacion}")]
    public async Task<IActionResult> Get(string fechaInicial, string fechaFinal, string identificacion)
    {
        List<ReporteDto> listaReporte = new List<ReporteDto>();
        ReporteDto objReporte = new ReporteDto();
        var cliente = await _context.Cliente.Where(w => w.pr_identificacion == identificacion).FirstOrDefaultAsync();
        var cuentas = _context.Cuenta.Where(w => w.cu_cliente == cliente.cl_id_cliente);

        foreach(var objCuenta in cuentas)
        {
            var tipoCuenta = await _context.TipoCuenta.Where(w => w.tc_id_tipo_cuenta == objCuenta.cu_tipo).FirstOrDefaultAsync();
            var movs = _context.Movimientos.Where(w => w.mo_fecha >= Convert.ToDateTime(fechaInicial) && w.mo_fecha <= Convert.ToDateTime(fechaFinal) && objCuenta.cu_id_cuenta == w.mo_id_cuenta);
            foreach(var objMov in movs)
            {
                objReporte.fecha = objMov.mo_fecha;
                objReporte.cliente = cliente.pr_nombre;
                objReporte.cuenta = objCuenta.cu_numero;
                objReporte.tipoCuenta = tipoCuenta.tc_descripcion;
                objReporte.estadoCuenta = objCuenta.cu_estado;
                objReporte.movimiento = objMov.mo_valor;
                objReporte.saldoFinal = objMov.mo_saldo_final;

                listaReporte.Add(objReporte);
            }
        }

        return (IActionResult)listaReporte;
    }
}
