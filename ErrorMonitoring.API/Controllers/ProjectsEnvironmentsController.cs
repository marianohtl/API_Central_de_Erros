using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ProjectsEnvironmentsController : ControllerBase
    {
        private readonly IProjectsEnvironmentsService _projectsEnvironmentsService;
        private readonly IMapper _mapper;
        public ProjectsEnvironmentsController(IProjectsEnvironmentsService projectsEnvironmentsService, IMapper mapper)
        {
            _projectsEnvironmentsService = projectsEnvironmentsService;
            _mapper = mapper;
        }

        // GET: api/ProjectsEnvironments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ProjectsEnvironmentsDTO>> GetAll()
        {
            var _projectsEnvironments = _projectsEnvironmentsService.ProjectsEnvironments().ToList();
            if (_projectsEnvironments != null)
            {

                var retorno = _mapper.Map<List<EnvironmentsDTO>>(_projectsEnvironments);
                return Ok(retorno);

            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/ProjectsEnvironments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProjectsEnvironmentsDTO> GetById(int id)
        {
            var _projectsenvironments = _projectsEnvironmentsService.GetById(id);
            if (_projectsenvironments != null)
            {

                var retorno = _mapper.Map<List<ProjectsEnvironmentsDTO>>(_projectsenvironments);
                return Ok(retorno);

            }
            else
            {
                return NoContent();
            }
        }
        // POST: api/ProjectsEnvironments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] ProjectsEnvironmentsDTO projectsEnvironments)
        {
            var value = _mapper.Map<ProjectsEnvironments>(projectsEnvironments);
            var _projectsEnvironments = _projectsEnvironmentsService.Save(value);

            if (_projectsEnvironments != null)
            {
                return Ok(_mapper.Map<ProjectsEnvironmentsDTO>(_projectsEnvironments));
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/ProjectsEnvironments/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put([FromBody] ProjectsEnvironmentsDTO projectsEnvironmentsDTO)
        {
            var value = _mapper.Map<ProjectsEnvironments>(projectsEnvironmentsDTO);
            var _projectsEnvironments = _projectsEnvironmentsService.Update(value);
            if (_projectsEnvironments != null)
            {
                return Ok(_mapper.Map<ProjectsEnvironmentsDTO>(projectsEnvironmentsDTO));
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
            var retorno = _projectsEnvironmentsService.Delete(id);
            if (retorno == true)
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
