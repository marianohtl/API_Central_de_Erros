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
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectsService ProjectsService, IMapper mapper)
        {
            _projectsService = ProjectsService;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ProjectsDTO>> Get()
        {
            var project = _projectsService.Projects().ToList();
            if(project.Any())
            {
                var retorno = _mapper.Map<List<ProjectsDTO>>(project);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProjectsDTO> Get(int id)
        {
            var project = _projectsService.ProjectsById(id);
            if (project != null)
            {
                var retorno = _mapper.Map<ProjectsDTO>(project);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/Projects
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProjectsDTO> Post([FromBody] ProjectsDTO projects)
        {
            var value = _mapper.Map<Projects>(projects);
            var project = _projectsService.Salvar(value);
            if (project != null)
            {
                var retorno = _mapper.Map<ProjectsDTO>(project);
                return Ok(retorno);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProjectsDTO> Put([FromBody] ProjectsDTO projects)
        {
            var value = _mapper.Map<Projects>(projects);
            var project = _projectsService.Atualizar(value);
            if (project != null)
            {
                var retorno = _mapper.Map<ProjectsDTO>(project);
                return Ok(project);
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
            var retorno = _projectsService.Deletar(id);
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
