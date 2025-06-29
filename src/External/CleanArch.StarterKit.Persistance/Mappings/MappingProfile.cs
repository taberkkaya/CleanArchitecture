using AutoMapper;
using CleanArch.StarterKit.Application.Feature.Auth.Commands.Register;
using CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
using CleanArch.StarterKit.Domain.Entities;

namespace CleanArch.StarterKit.Persistance.Mappings;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateExampleCommand, Example>();
        CreateMap<RegisterCommand, User>();
    }
}
