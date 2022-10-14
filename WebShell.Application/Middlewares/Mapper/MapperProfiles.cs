using AutoMapper;
using WebShell.Domain.DTOs;
using WebShell.Domain.Models;

namespace WebShell.Application.Middlewares.Mapper
{
    public class CommandPostProfile : Profile
    {
        public CommandPostProfile()
        {
            CreateMap<CommandDTO, CommandModel>();
        }
    }

    public class CommandGetProfile : Profile
    {
        public CommandGetProfile()
        {
            CreateMap<CommandModel, CommandDTO>();
        }
    }
}
