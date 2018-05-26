using Microsoft.AspNetCore.Mvc;

namespace ExemploActionResult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private CatalogoContext _contexto;

        public CatalogoController(CatalogoContext context)
        {
            _contexto = context;
        }

        [HttpGet("produtos/{codigo}")]
        public ActionResult<Produto> GetProduto(string codigo)
        {
            Produto prod = null;
            if (codigo.StartsWith("PROD"))
                prod = _contexto.ObterItem<Produto>(codigo);

            if (prod != null)
                return prod;
            else
            {
                return NotFound(
                    "Código de produto inválido ou item inexistente.");
            }
        }

        [HttpGet("servicos/{codigo}")]
        public ActionResult<Servico> GetServico(string codigo)
        {
            Servico serv = null;
            if (codigo.StartsWith("SERV"))
                serv = _contexto.ObterItem<Servico>(codigo);

            if (serv != null)
                return serv;
            else
            {
                return NotFound(
                    new
                    {
                        Mensagem = "Código de serviço inválido ou item inexistente.",
                        Erro = true
                    });
            }
        }
    }
}