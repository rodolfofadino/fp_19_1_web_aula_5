using fpReceitas.Api.Custom;
using fpReceitas.Core.Contexts;
using fpReceitas.Core.Migrations;
using fpReceitas.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpReceitas.Api.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("default")]
    //[CustomAuthorize(teste:"Oi")]
    [Authorize]

    public class ReceitasController: Controller
    {
        private ReceitaContext _context;

        public ReceitasController(ReceitaContext receitaContext)
        {
            _context = receitaContext;
        }
        //[HttpGet("")]
        //public IEnumerable<Receita> Get()
        //{
        //    //var teste = false;
        //    //if (teste == false)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    return _context.Receitas.ToList();
        //}

        //[HttpGet("")]
        //public ActionResult Get()
        //{
        //    return Ok( _context.Receitas.ToList());
        //}


        //[HttpGet("")]
        //public ActionResult<IEnumerable<Receita>> Get()
        //{

        //    //return StatusCode(StatusCodes.Status200OK, _context.Receitas.ToList());
        //    return Ok(_context.Receitas.ToList());
        //}

        //[HttpGet("")]
        //public ActionResult<IEnumerable<Receita>> Get([FromQuery]MinhaBusca busca)
        //{
        //    var a = ModelState.IsValid;

        //    //return StatusCode(StatusCodes.Status200OK, _context.Receitas.ToList());
        //    return Ok(_context.Receitas.ToList());
        //}

       [HttpGet("")]
       public ActionResult<IEnumerable<Receita>> Get()
       {

            //var c = _context.Receitas.FirstOrDefault(a => a.Nome == "temaki");
            //var b = _context.Receitas.SingleOrDefault(a => a.Nome.Contains('a'));

            return Ok(_context.Receitas.ToList());
       }

        [HttpGet("{id}")]
        public ActionResult<Receita> Get(int id)
        {
            return Ok(_context.Receitas.FirstOrDefault(a=>a.Id==id));
        }


        [HttpPost("")]
        public ActionResult<Receita> PostReceita([FromBody]Receita receita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(receita);
            _context.SaveChanges();

            return Created($"/api/receitas/{receita.Id}", receita);
        }

        [HttpPatch("{id}")]
        public ActionResult<Receita> PatchReceita(int id,[FromBody]Receita model, [FromHeader]MinhaBusca headers)
        {
            var receita = _context.Receitas.FirstOrDefault(a => a.Id == id);
            if (string.IsNullOrWhiteSpace( model.Nome))
                receita.Nome = model.Nome;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<Receita> PutReceita(int id, [FromBody]Receita model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(model);
        }

    }
}
