using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrincaBackEnd.Models.Response;
using TrincaBackEnd.Models.Entities;
using TrincaBackEnd.Repositories;

namespace TrincaBackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/Participante")]
    public class ParticipanteController : Controller
    {
        private readonly ParticipanteRepositorie _participanteRepositorie;

        public ParticipanteController()
        {
            this._participanteRepositorie = new ParticipanteRepositorie();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_participanteRepositorie.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{churrasId}")]
        public IActionResult Get(int churrasId)
        {
            try
            {
                return Ok(_participanteRepositorie.GetById(churrasId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Participante participante)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_participanteRepositorie.Create(participante));
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

        [HttpPut]
        public IActionResult Put([FromBody]Participante participante)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_participanteRepositorie.Update(participante));
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
                _participanteRepositorie.Delete(id);
                return Ok(new ReturnResponse
                {
                    Valido = true,
                    Mensagem = "Participante removido com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}