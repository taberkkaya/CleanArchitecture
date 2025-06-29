using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Domain.Entities;
using MediatR;

namespace CleanArch.StarterKit.Application.Feature.Examples.Queries.GetAllExample;
public sealed record GetAllExampleQuery() : IRequest<IList<Example>>;

internal sealed class GetAllExampleQueryHandler : IRequestHandler<GetAllExampleQuery, IList<Example>>
{
    private readonly IExampleService _exampleService;

    public GetAllExampleQueryHandler(IExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    public async Task<IList<Example>> Handle(GetAllExampleQuery request, CancellationToken cancellationToken)
    {
        IList<Example> examples = await _exampleService.GetAllAsync(request, cancellationToken);
        return examples;
    }
}
