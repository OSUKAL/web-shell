using AutoMapper;
using WebShell.Application.Middlewares;
using WebShell.Domain.DTOs;
using WebShell.Domain.Models;
using WebShell.Infrastructure.Repositories;

namespace WebShell.Application.Services;

public class CommandService : ICommandService
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;


    public CommandService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CommandDTO>> GetCommands()
    {
        var commandsToMap = await _unitOfWork.CommandRepository.GetEntityListAsync();
        var commands = _mapper.Map<IEnumerable<CommandDTO>>(commandsToMap);
        return commands;
    }

    public async Task<CommandResultDTO> CreateCommand(CommandDTO commandInput)
    {
        var command = _mapper.Map<CommandModel>(commandInput);


        _unitOfWork.CommandRepository.PostEntity(command);
        await _unitOfWork.SaveAsync();
        var result = new CommandResultDTO();
        result.ResultOfCommand = await PowershellMiddleware.PSCommandRun(commandInput.Command);
        result.CurrentLocation = await PowershellMiddleware.GetCurrentLocation();
        return result;
    }

    public async Task<CommandResultDTO> GetCurrentLocationInitial()
    {
        var result = new CommandResultDTO();
        result.CurrentLocation = await PowershellMiddleware.GetCurrentLocation();
        result.ResultOfCommand = "Web-Shell";
        return result;
    }
}