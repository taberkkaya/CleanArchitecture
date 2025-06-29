using CleanArch.StarterKit.Domain.Entities;
using CleanArch.StarterKit.Domain.Repositories;
using CleanArch.StarterKit.Persistance.Context;
using GenericRepository;

namespace CleanArch.StarterKit.Persistance.Repositories;
public sealed class ExampleRepository : Repository<Example, AppDbContext>, IExampleRepository
{
    public ExampleRepository(AppDbContext context) : base(context)
    {
    }
}
