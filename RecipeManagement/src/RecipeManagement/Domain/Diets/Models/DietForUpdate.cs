namespace RecipeManagement.Domain.Diets.Models;

using Destructurama.Attributed;

public sealed record DietForUpdate
{
    public string Name { get; set; }
}
