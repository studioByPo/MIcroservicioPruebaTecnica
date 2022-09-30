using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicioPrueba.Entities;
using MicroservicioPrueba.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MicroservicioPrueba.Dto;

namespace MicroservicioPrueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : Controller
{
    private IAppDBContext _context;
    private IMapper _mapper;

    public ClienteController(IAppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{identificacion}")]
    public async Task<IActionResult> Get(string identificacion)
    {
        var res = await _context.Cliente.Where(w => w.pr_identificacion == identificacion).FirstOrDefaultAsync();
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
    public async Task<ClienteDto> Post(ClienteDto clientes)
    {
        var mapCliente = _mapper.Map<Cliente>(clientes);

        _context.Cliente.Add(mapCliente);
        await _context.SaveChangesAsync();

        return clientes;
    }

    [HttpPut("{identificacion}")]
    public async Task<IActionResult> Put(ClienteDto clientes, string identificacion)
    {
        if(identificacion != clientes.identificacion)
        {
            throw new Exception();
        }

        var res = await _context.Cliente.Where(w => w.pr_identificacion == identificacion).FirstOrDefaultAsync();

        if (res == null)
        {
            return NotFound();
        }
        else
        {
            var mapCliente = _mapper.Map<Cliente>(clientes);
            await _context.SaveChangesAsync();
            return Ok(res);
        }

    }

    [HttpDelete("{identificacion}")]
    public async Task<IActionResult> Delete(string identificacion)
    {
        var res = await _context.Cliente.Where(w => w.pr_identificacion == identificacion).FirstOrDefaultAsync();

        if (res == null)
        {
            return NotFound();
        }
        else
        {
            _context.Cliente.Remove(res);
            await _context.SaveChangesAsync();
            return Ok(identificacion);
        }
    }
}