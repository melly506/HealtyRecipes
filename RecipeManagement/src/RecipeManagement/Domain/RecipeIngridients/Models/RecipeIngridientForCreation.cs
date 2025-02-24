namespace RecipeManagement.Domain.RecipeIngridients.Models;

using Destructurama.Attributed;

public sealed record RecipeIngridientForCreation
{
    public int Count { get; set; }
}
