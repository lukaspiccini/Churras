using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrincaBackEnd.Models.Request;
using TrincaBackEnd.Repositories;
using TrincaBackEnd.Models.Response;
using TrincaBackEnd.Models.Entities;

namespace TrincaBackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Churras")]
    public class ChurrasController : ControllerBase
    {
        private readonly ChurrasRepositorie _churrasRepositorie;

        public ChurrasController()
        {
            this._churrasRepositorie = new ChurrasRepositorie();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_churrasRepositorie.GetAll());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_churrasRepositorie.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]ChurrasRequest churras)
        {
            try
            {
                if(ModelState.IsValid)
                    return Ok(_churrasRepositorie.Create(churras));
                else
                    return BadRequest(new ReturnResponse {
                        Valido = false,
                        Mensagem = "Erro no objeto enviado para o servidor. Favor validá-lo."
                    });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Churras churras)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_churrasRepositorie.Update(churras));
                else
                    return BadRequest(new ReturnResponse
                    {
                        Valido = false,
                        Mensagem = "Erro no objeto enviado para o servidor. Favor validá-lo."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _churrasRepositorie.Delete(id);
                return Ok(new ReturnResponse {
                    Valido = true,
                    Mensagem = "Churras removido com sucesso! Mas pense bem antes de cancelar um churrasco!!!!!!!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}