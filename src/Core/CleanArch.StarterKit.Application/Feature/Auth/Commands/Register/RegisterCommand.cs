using System.Runtime.CompilerServices;
using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Domain.Dtos;
using CleanArch.StarterKit.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.StarterKit.Application.Feature.Auth.Commands.Register;
public sealed record RegisterCommand(
    string Email,
    string UserName,
    string FirstName,
    string LastName,
    string Password
    ) : IRequest<MessageResponse>;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authService.RegisterAsync(request);
        return new("Kullanıcı kaydı tamamlandı!");
    }
}
