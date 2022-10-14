using System.Management.Automation;
using System.Text;

namespace WebShell.Application.Middlewares;

public static class PowershellMiddleware
{
    private static readonly PowerShell _ps = PowerShell.Create();

    public static async Task<string> GetCurrentLocation()
    {
        _ps.AddScript("Get-Location");
        var stringBuilder = new StringBuilder();
        var results = await _ps.InvokeAsync().ConfigureAwait(false);
        foreach (var item in results)
            stringBuilder.AppendLine(item.ToString());
        return stringBuilder.ToString();
    }

    public static async Task<string> PSCommandRun(string script)
    {
        _ps.AddScript(script);
            _ps.AddCommand("Out-String");
            var stringBuilder = new StringBuilder();
            var results = await _ps.InvokeAsync().ConfigureAwait(false);
            foreach (var item in results)
                stringBuilder.AppendLine(item.ToString());
            if (_ps.HadErrors)
            {
                
                var error = _ps.Streams.Error.Last().ToString();
                _ps.Commands.Clear();
                _ps.Streams.Error.Clear();
                return error;
            }
            else
            {
                return stringBuilder.ToString();
            }
            
    }
}