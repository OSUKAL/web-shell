using WebShell.Domain.DTOs;

namespace WebShell.Application.Services;

public interface ICommandService
{
    public Task<IEnumerable<CommandDTO>> GetCommands();
    public Task<CommandResultDTO> CreateCommand(CommandDTO command);

    public Task<CommandResultDTO> GetCurrentLocationInitial();
}