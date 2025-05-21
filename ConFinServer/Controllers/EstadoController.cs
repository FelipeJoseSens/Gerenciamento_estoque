using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        //private static List<Estado> lista = new List<Estado>();
        private readonly AppDbContext _context;

        public EstadoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<List<Estado>> GetEstado()
        {
            var lista = await _context.Estado
                        .OrderBy(e => e.Sigla)
                        .ToListAsync();
            //select * from estado order by sigla
            return lista;
        }

        /*[HttpGet("Estado2")]
        public string Estado(string valor)
        {
            //var valor = "Teste";
            return valor;
        }

        [HttpGet]
        [Route("Lista")]
        public List<Estado> EstadoLista()
        {
            return lista;
        }*/

        [HttpPost]
        public async Task<IActionResult> PostEstado([FromBody] Estado estado)
        {
            try
            {
                await _context.Estado.AddAsync(estado);
                //insert into estado (sigla,nome) values("","")
                await _context.SaveChangesAsync();
                return Ok("Estado cadastrado com sucesso!");
            }
            catch (Exception ex) { 
                return BadRequest("Erro ao incluir estado. " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutEstado([FromBody] Estado estado)
        {
            var estadoExiste = await _context.Estado
                                .Where(l => l.Sigla == estado.Sigla)
                                .FirstOrDefaultAsync();
            if(estadoExiste != null)
            {
                try
                {
                    estadoExiste.Nome = estado.Nome;
                    _context.Estado.Update(estadoExiste);
                    //update estado set nome = "" where sigla = ""
                    await _context.SaveChangesAsync();
                    return Ok("Estado alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar estado. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Estado não encontrado!");
            }
            
        }

        /*[HttpDelete]
        public string DeleteEstado(Estado estado)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == estado.Sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
                return "Estado excluído com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }

        }

        [HttpDelete("Exclui2")]
        public string DeleteEstado2([FromQuery] string sigla)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
                return "Estado excluído com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }

        }

        [HttpDelete("Exclui3")]
        public string DeleteEstado3([FromHeader] string sigla)
        {
            var estadoExiste = lista
                                .Where(l => l.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                lista.Remove(estadoExiste);
                return "Estado excluído com sucesso!";
            }
            else
            {
                return "Estado não encontrado!";
            }

        }*/

        [HttpDelete("{sigla}")]
        public async Task<IActionResult> DeleteEstado([FromRoute] string sigla)
        {
            var estadoExiste = await _context.Estado
                                .Where(l => l.Sigla == sigla)
                                .FirstOrDefaultAsync();
            if (estadoExiste != null)
            {
                try
                {
                    _context.Estado.Remove(estadoExiste);
                    //delete from estado where sigla = ""
                    await _context.SaveChangesAsync();
                    return Ok("Estado excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir estado. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Estado não encontrado!");
            }

        }
    }
}
