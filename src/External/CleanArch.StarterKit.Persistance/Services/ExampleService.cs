using AutoMapper;
using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Domain.Entities;
using CleanArch.StarterKit.Persistance.Context;

namespace CleanArch.StarterKit.Persistance.Services;
public sealed class ExampleService : IExampleService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public ExampleService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateExampleCommand request, CancellationToken cancellationToken)
    {
        //Example example = new()
        //{
        //    Value1 = request.Value1,
        //    Value2 = request.Value2,
        //    Value3 = request.Value3
        //};

        Example example = _mapper.Map<Example>(request);

        await _context.Set<Example>().AddAsync(example,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
