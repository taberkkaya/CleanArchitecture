using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;

namespace CleanArch.StarterKit.Application.Services;
public interface IExampleService
{
    Task CreateAsync(CreateExampleCommand request, CancellationToken cancellationToken);

}
