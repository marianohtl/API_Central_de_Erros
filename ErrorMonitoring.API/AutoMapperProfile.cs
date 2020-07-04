using AutoMapper;
using ErrorMonitoring.API.DTOs;
using ErrorMonitoring.Dominio.Entidades;

namespace ErrorMonitoring.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Environments, EnvironmentsDTO>().ReverseMap();
            CreateMap<Events, EventsDTO>().ReverseMap();
            CreateMap<Logs, LogsDTO>().ReverseMap();
            CreateMap<Projects, ProjectsDTO>().ReverseMap();
            CreateMap<ProjectsEnvironments, ProjectsEnvironmentsDTO>().ReverseMap();
        }        
    
    }
}
