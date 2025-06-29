using AutoMapper;
using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
using CleanArch.StarterKit.Application.Feature.Examples.Queries.GetAllExample;
using CleanArch.StarterKit.Application.Services;
using CleanArch.StarterKit.Domain.Entities;
using CleanArch.StarterKit.Domain.Repositories;
using CleanArch.StarterKit.Persistance.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.StarterKit.Persistance.Services;
public sealed class ExampleService : IExampleService
{
    private readonly AppDbContext _context;
    private readonly IExampleRepository _exampleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ExampleService(AppDbContext context, IMapper mapper, IExampleRepository exampleRepository, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _exampleRepository = exampleRepository;
        _unitOfWork = unitOfWork;
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

        //await _context.Set<Example>().AddAsync(example,cancellationToken);
        //await _context.SaveChangesAsync(cancellationToken);

        await _exampleRepository.AddAsync(example, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Example>> GetAllAsync(GetAllExampleQuery request, CancellationToken cancellationToken)
    {
        IList<Example> examples = 
            await _exampleRepository
            .GetAll()
            .ToListAsync(cancellationToken);
        return examples;
    }
}
