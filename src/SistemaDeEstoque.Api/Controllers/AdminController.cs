namespace SistemaDeEstoque.Api.Controllers;

public class AdminController : SistemaDeEstoqueController
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(RespostaPerfilAdminJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPerfil()
    {
        var resposta = await _mediator.Send(new RecuperarPerfilAdminQuery());

        return Ok(resposta);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RespostaAdminRegistradoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarAdmin([FromBody] RegistrarAdminCommand requisicao)
    {
        var resposta = await _mediator.Send(requisicao);

        return Created(string.Empty, resposta);
    }

    [HttpPut]
    [Route("alterar-senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AlterarSenha([FromBody] AlterarSenhaAdminCommand requisicao)
    {
        await _mediator.Send(requisicao);

        return NoContent();
    }
}
