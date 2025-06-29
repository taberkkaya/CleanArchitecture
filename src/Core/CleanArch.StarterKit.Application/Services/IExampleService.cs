using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
using CleanArch.StarterKit.Application.Feature.Examples.Queries.GetAllExample;
using CleanArch.StarterKit.Domain.Entities;

namespace CleanArch.StarterKit.Application.Services;
public interface IExampleService
{
    Task CreateAsync(CreateExampleCommand request, CancellationToken cancellationToken);
    Task<IList<Example>> GetAllAsync(GetAllExampleQuery request,CancellationToken cancellationToken);
}
