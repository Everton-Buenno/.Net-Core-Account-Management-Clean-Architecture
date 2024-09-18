using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _contaService;
        public ContasController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarConta([FromBody] CriarContaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _contaService.AdicionarConta(request);
            if (result.Error)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("{numeroConta}/{agencia}")]
        public async Task<IActionResult> ObterConta(string numeroConta, string agencia)
        {
            var conta = await _contaService.ObterConta(numeroConta, agencia);

            if (conta == null)
                return NotFound(new { Message = "Conta não encontrada." });

            return Ok(conta);
        }

        [HttpPost("depositar")]
        public async Task<IActionResult> RealizarDeposito([FromQuery] string numeroConta, [FromQuery] string agencia, [FromQuery] decimal valor)
        {
            if (valor <= 0)
                return BadRequest(new { Message = "O valor do depósito deve ser positivo." });

            var result = await _contaService.RealizarDeposito(numeroConta, agencia, valor);

            if (result.Error)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("sacar")]
        public async Task<IActionResult> RealizarSaque([FromQuery] string numeroConta, [FromQuery] string agencia, [FromQuery] decimal valor)
        {
            if (valor <= 0)
                return BadRequest(new { Message = "O valor do saque deve ser positivo." });

            var result = await _contaService.RealizarSaque(numeroConta, agencia, valor);

            if (result.Error)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("aplicar-rendimento")]
        public async Task<IActionResult> AplicarRendimento([FromQuery] decimal taxa, [FromQuery] string agencia, [FromQuery] string numeroConta)
        {
            var result = await _contaService.AplicarRendimento(taxa, agencia, numeroConta);

            if (result.Error)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpPost("aplicar-taxas-juros")]
        public async Task<IActionResult> AplicarTaxaJuros([FromQuery] decimal taxa, [FromQuery] string agencia, [FromQuery] string numeroConta)
        {
            var result = await _contaService.AplicarTaxaJuros(taxa, agencia, numeroConta);

            if (result.Error)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
