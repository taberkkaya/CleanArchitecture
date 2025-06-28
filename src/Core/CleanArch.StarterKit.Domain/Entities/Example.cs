using CleanArch.StarterKit.Domain.Abstractions;

namespace CleanArch.StarterKit.Domain.Entities;
public sealed class Example : Entity
{
    public string Value1 { get; set; } = string.Empty;
    public int Value2 { get; set; }
    public bool Value3 { get; set; }
}
