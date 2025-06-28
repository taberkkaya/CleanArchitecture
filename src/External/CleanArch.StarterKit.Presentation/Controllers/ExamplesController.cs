using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
using CleanArch.StarterKit.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.StarterKit.Presentation.Controllers;
public class ExamplesController : ApiController
{
    public ExamplesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateExampleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
