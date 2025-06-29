using CleanArch.StarterKit.Application.Feature.Auth.Commands.Register;
using CleanArch.StarterKit.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.StarterKit.Presentation.Controllers;
public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
