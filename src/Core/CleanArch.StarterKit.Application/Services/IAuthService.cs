using CleanArch.StarterKit.Application.Feature.Auth.Commands.Register;

namespace CleanArch.StarterKit.Application.Services;
public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
}
