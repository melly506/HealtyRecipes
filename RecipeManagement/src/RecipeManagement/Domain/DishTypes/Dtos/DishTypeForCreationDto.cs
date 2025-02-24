namespace RecipeManagement.Domain.DishTypes.Dtos;

using Destructurama.Attributed;

public sealed record DishTypeForCreationDto
{
    public string Name { get; set; }
}
