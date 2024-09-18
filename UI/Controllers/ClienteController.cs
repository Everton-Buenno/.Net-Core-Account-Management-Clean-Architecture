using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente([FromBody] ClienteInput clienteInput)
        {
            if (clienteInput == null)
                return BadRequest("Cliente inválido.");

            var cliente = new Domain.Entities.Cliente(
                clienteInput.Nome,
                clienteInput.Cpf,
                clienteInput.Endereco,
                clienteInput.Profissao
            );

            var resultado = await _clienteService.AdicionarCliente(cliente);

            if (resultado == null)
                return StatusCode(500, "Erro ao adicionar cliente.");

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarClientePorId(Guid id)
        {
            var cliente = await _clienteService.BuscarClientePorId(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(cliente);
        }


        [HttpGet]
        public async Task<IActionResult> BuscarTodosClientes()
        {
            return Ok(await _clienteService.BuscarTodosClientes());
        }
    }
}
