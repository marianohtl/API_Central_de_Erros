using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorMonitoring.API.DTOs;
using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorMonitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnvironmentsController : ControllerBase
    {
        private readonly IEnvironmentsService _environmentsService;
        private readonly IMapper _mapper;

        public EnvironmentsController(IEnvironmentsService environmentsService, IMapper mapper)
        {
            _environmentsService = environmentsService;
            _mapper = mapper;
        }

        // GET: api/Environments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<EnvironmentsDTO>> GetAll()
        {
            var _environments = _environmentsService.Environments().ToList();
            if (_environments != null)
            {

                var retorno = _mapper.Map<List<EnvironmentsDTO>>(_environments);
                return Ok(retorno);

            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Environments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EnvironmentsDTO> GetById(int id)
        {
            var _environments = _environmentsService.GetById(id);
            if (_environments != null)
            {

                var retorno = _mapper.Map<List<EnvironmentsDTO>>(_environments);
                return Ok(retorno);

            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Environments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EnvironmentsDTO> Post([FromBody] EnvironmentsDTO environment)
        {
            var value = _mapper.Map<Environments>(environment);
            var _environments = _environmentsService.Save(value);

            if (_environments != null)
            {
                return Ok(_mapper.Map<EnvironmentsDTO>(_environments));
            }
            else
            {
                return NoContent();
            }
        }
        // PUT: api/Environments/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Environments> Put([FromBody] EnvironmentsDTO environment)
        {
            var value = _mapper.Map<Environments>(environment);
            var _environments = _environmentsService.Update(value);

            if (_environments != null)
            {
                return Ok(_mapper.Map<EnvironmentsDTO>(_environments));
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Delete(int id)
        {
            var retorno = _environmentsService.Delete(id);

            if (retorno)
            {
                return Ok("Deletado com sucesso");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
