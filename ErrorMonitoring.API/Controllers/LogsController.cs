using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ErrorMonitoring.API.DTOs;
using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorMonitoring.API.Controllers
{
    [Route("api/Logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;
        private readonly IMapper _mapper;

        public LogsController(ILogsService logsService, IMapper mapper)
        {
            _logsService = logsService;
            _mapper = mapper;
        }

        // GET: api/Logs
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<LogsDTO>> Get()
        {
            var log = _logsService.Logs().ToList();
            if(log.Any())
            {
                var retorno = _mapper.Map<List<LogsDTO>>(log);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Logs/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LogsDTO> Get(int id)
        {
            var log = _logsService.LogsById(id);
            if (log != null)
            {
                var retorno = _mapper.Map<LogsDTO>(log);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Logs
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LogsDTO> Post([FromBody] LogsDTO logs)
        {
            var value = _mapper.Map<Logs>(logs);
            var log = _logsService.Salvar(value);
            if (log != null)
            {
                var retorno = _mapper.Map<LogsDTO>(log);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Logs/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LogsDTO> Put([FromBody] LogsDTO logs)
        {
            var value = _mapper.Map<Logs>(logs);
            var log = _logsService.Atualizar(value);
            if (log != null)
            {
                var retorno = _mapper.Map<LogsDTO>(log);
                return Ok(log);
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
            var retorno = _logsService.Deletar(id);
            if (retorno)
            {
                return Ok("Deletado com sucesso!");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
