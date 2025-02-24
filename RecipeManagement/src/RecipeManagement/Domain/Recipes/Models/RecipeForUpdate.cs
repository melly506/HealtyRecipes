namespace RecipeManagement.Domain.Recipes.Models;

using Destructurama.Attributed;

public sealed record RecipeForUpdate
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int CookingTime { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public int LikesCount { get; set; }
    public bool IsDraft { get; set; }
    public string AuthorId { get; set; }

}
