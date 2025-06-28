using System.Runtime.CompilerServices;
using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Domain.Dtos;
using MediatR;

namespace CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
public sealed record CreateExampleCommand(
    string Value1,
    int Value2,
    bool Value3
    ) : IRequest<MessageResponse>;

internal sealed class CreateExampleCommandHandler : IRequestHandler<CreateExampleCommand, MessageResponse>
{
    private readonly IExampleService _exampleService;

    public CreateExampleCommandHandler(IExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    public async Task<MessageResponse> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
    { 
        await _exampleService.CreateAsync(request, cancellationToken);
        return new("Example created successfully");
    }
}
