using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private static List<Cidade> lista = new List<Cidade>();
        private readonly AppDbContext _context;

        public CidadeController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetCidade()
        {
            try
            {
                var lista = _context.Cidade
                        .Include(c => c.Estado)
                        .OrderBy(c => c.Nome)
                        .ToList();
                /*select * from cidade
                join estado on estadosigla = sigla
                order by nome*/
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao consultar Cidade. " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostCidade([FromBody] Cidade cidade)
        {
            try
            {
                _context.Cidade.Add(cidade);
                _context.SaveChanges();
                return Ok("Cidade cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir Cidade. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutCidade([FromBody] Cidade cidade)
        {
            try
            {
                var cidadeExiste = _context.Cidade
                                   .Where(l => l.Codigo == cidade.Codigo)
                                   .FirstOrDefault();
                if (cidadeExiste != null)
                {
                    cidadeExiste.Nome = cidade.Nome;
                    cidadeExiste.Estado = cidade.Estado;
                    _context.Cidade.Update(cidadeExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Cidade não encontrada!");
                }
                return Ok("Cidade alterada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar Cidade. " + ex.Message);
            }
        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteCidade([FromRoute] int codigo)
        {
            try
            {
                var cidadeExiste = _context.Cidade
                                   .Where(l => l.Codigo == codigo)
                                   .FirstOrDefault();
                if (cidadeExiste != null)
                {
                    _context.Cidade.Remove(cidadeExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Cidade não encontrada!");
                }

                return Ok("Cidade excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir Cidade. " + ex.Message);
            }
        }

    }
}
