using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chamadosTeste.data;
using chamadosTeste.Models;

namespace chamadosTeste.Controllers
{
    [ApiController]
    [Route("v1/chamado")]

    public class ChamadoController : ControllerBase
    {
        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Chamado>> Post([FromServices] data.dataContext context, [FromBody]Chamado model)
        {
            if (ModelState.IsValid)
            {
                context.Chamado.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Chamado>>> Get([FromServices] data.dataContext context) {

            var chamado = await context.Chamado.Include(x => x.Chamado).ToListAsync();
            if(chamado.dataFim != null)
            {
                chamado.finalizado = true;
            }
            chamado.quantidadedeAcoes += 1;
            return chamado;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Chamado>> GetById([FromServices] data.dataContext context, int id)
        {
            var chamado = await context.Chamado.Include(x => x.Chamado)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (chamado.dataFim != null)
            {
                chamado.finalizado = true;
            }
            chamado.quantidadedeAcoes += 1;
            return chamado;
        }

        [HttpGet]
        [Route("acao/{id:int}")]

        public async Task<ActionResult<List<Chamado>>> GetByAcoes([FromServices] data.dataContext context, int id)
        {
            var chamado = await context.Chamado
                .Include(x => x.Acoes)
                .AsNoTracking()
                .Where(x => x.AcoesId == id)
                .ToListAsync();

            if (chamado.dataFim != null)
            {
                chamado.finalizado = true;
            }
            chamado.quantidadedeAcoes += 1;
            return acoes;
        }

        [HttpDelete("{id:int}")]
        [Route("chamado/{id:int}")]

        public async Task<ActionResult<List<Chamado>>> DeleteChamado(int id)
        {

            try
            {
                var ChamadoDelete = await Chamado.GetChamado(id);
                if (ChamadoDelete == null)
                {
                    return NotFound($"ChamadoDelete com Id = {id} not found");
                }

                await chamadoTeste.ChamadoDelete(id);

            }
            catch
            {

            }

        [HttpPut("{id:int}")]
        [Route("chamado/{id:int}")]

        public async Task<ActionResult<List<Chamado>>> DeleteChamado(int id)
        {

            try
            {
                var ChamadoAlter = await Chamado.GetChamado(id);
                if (ChamadoAlter == null)
                {
                    return NotFound($"ChamadoDelete com Id = {id} not found");
                }

                await ChamadoAlter.ChamadoAlter(id);

            }
            catch
            {

            }

            [HttpPut("{id:int}")]
        public async Task<ActionResult<Chamado>> UpdateChamado(int id, Chamado update)
        {
            try
            {
                if(id != UpdateChamado(int id, Chamado chamado){
                    return BadRequest("Update");
                }
            }
            catch
            {
                return $StatusCode($StatusCodes.Status500InternalServerError, "Erro em atualizar os dado")
            }
        }
        }

    }
}