using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.StarterKit.Presentation.Abstractions;

[ApiController]
[Route("api/[controller]")] 
public abstract class ApiController : ControllerBase
{
    public readonly IMediator _mediator;
    public ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
