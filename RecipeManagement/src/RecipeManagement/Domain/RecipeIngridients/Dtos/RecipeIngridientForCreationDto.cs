namespace RecipeManagement.Domain.RecipeIngridients.Dtos;

using Destructurama.Attributed;

public sealed record RecipeIngridientForCreationDto
{
    public int Count { get; set; }
}
