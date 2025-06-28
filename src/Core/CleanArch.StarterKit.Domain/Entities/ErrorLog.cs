using CleanArch.StarterKit.Domain.Abstractions;

namespace CleanArch.StarterKit.Domain.Entities;
public sealed class ErrorLog : Entity
{
    public string ErrorMessage { get; set; } = string.Empty;
    public string StackTrace { get; set; } = string.Empty;
    public string RequestPath { get; set; } = string.Empty;
    public string RequestMethod { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
