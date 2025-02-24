namespace RecipeManagement.Domain.FoodTypes.Models;

using Destructurama.Attributed;

public sealed record FoodTypeForCreation
{
    public string Name { get; set; }
}
