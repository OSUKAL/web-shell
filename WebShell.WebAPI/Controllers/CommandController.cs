using Microsoft.AspNetCore.Mvc;
using WebShell.Application.Services;
using WebShell.Domain.DTOs;

namespace WebShell.WebAPI.Controllers;

[ApiController]
public class CommandController : ControllerBase
{
    private readonly ICommandService _commandService;

    public CommandController(ICommandService commandService)
    {
        _commandService = commandService;
    }

    [HttpGet("commands/get")]
    public async Task<IEnumerable<CommandDTO>> GetCommands()
    {
        var command = await _commandService.GetCommands();
        return command;
    }

    [HttpGet("commands/get-location")]
    public async Task<CommandResultDTO> GetCurrentLocationInitial()
    {
        return await _commandService.GetCurrentLocationInitial();
    }

    [HttpPost("commands/post")]
    public async Task<CommandResultDTO> CreateCommand(CommandDTO command)
    {
        return await _commandService.CreateCommand(command);
    }
}