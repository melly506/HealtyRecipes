namespace RecipeManagement.Domain.RecipeIngridients.Dtos;

using Destructurama.Attributed;

public sealed record RecipeIngridientDto
{
    public Guid Id { get; set; }
    public int Count { get; set; }
}
