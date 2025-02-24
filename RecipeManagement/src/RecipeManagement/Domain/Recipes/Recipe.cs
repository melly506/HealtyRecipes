namespace RecipeManagement.Domain.Recipes;

using System.ComponentModel.DataAnnotations;
using RecipeManagement.Domain.FoodTypes;
using RecipeManagement.Domain.Diets;
using RecipeManagement.Domain.Seasons;
using RecipeManagement.Domain.DishTypes;
using RecipeManagement.Domain.Comments;
using RecipeManagement.Domain.UserFavorites;
using RecipeManagement.Domain.RecipeIngridients;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using RecipeManagement.Exceptions;
using RecipeManagement.Domain.Recipes.Models;
using RecipeManagement.Domain.Recipes.DomainEvents;
using RecipeManagement.Domain.RecipeIngridients;
using RecipeManagement.Domain.RecipeIngridients.Models;
using RecipeManagement.Domain.UserFavorites;
using RecipeManagement.Domain.UserFavorites.Models;
using RecipeManagement.Domain.Comments;
using RecipeManagement.Domain.Comments.Models;
using RecipeManagement.Domain.DishTypes;
using RecipeManagement.Domain.DishTypes.Models;
using RecipeManagement.Domain.Seasons;
using RecipeManagement.Domain.Seasons.Models;
using RecipeManagement.Domain.Diets;
using RecipeManagement.Domain.Diets.Models;
using RecipeManagement.Domain.FoodTypes;
using RecipeManagement.Domain.FoodTypes.Models;


public class Recipe : BaseEntity
{
    [Required]
    public string Name { get; private set; }

    [Required]
    public string ImageUrl { get; private set; }

    [Required]
    public int CookingTime { get; private set; }

    public string Description { get; private set; }

    [Required]
    public string Instructions { get; private set; }

    [Required]
    public int LikesCount { get; private set; } = 0;

    public bool IsDraft { get; private set; } = false;

    [Required]
    public string AuthorId { get; private set; }

    private readonly List<RecipeIngridient> _recipeIngridients = new();
    public IReadOnlyCollection<RecipeIngridient> RecipeIngridients => _recipeIngridients.AsReadOnly();

    private readonly List<UserFavorite> _userFavorites = new();
    public IReadOnlyCollection<UserFavorite> UserFavorites => _userFavorites.AsReadOnly();

    private readonly List<Comment> _comments = new();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public DishType DishType { get; private set; }

    public Season Season { get; private set; }

    public Diet Diet { get; private set; }

    public FoodType FoodType { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Recipe Create(RecipeForCreation recipeForCreation)
    {
        var newRecipe = new Recipe();

        newRecipe.Name = recipeForCreation.Name;
        newRecipe.ImageUrl = recipeForCreation.ImageUrl;
        newRecipe.CookingTime = recipeForCreation.CookingTime;
        newRecipe.Description = recipeForCreation.Description;
        newRecipe.Instructions = recipeForCreation.Instructions;
        newRecipe.LikesCount = recipeForCreation.LikesCount;
        newRecipe.IsDraft = recipeForCreation.IsDraft;
        newRecipe.AuthorId = recipeForCreation.AuthorId;

        newRecipe.QueueDomainEvent(new RecipeCreated(){ Recipe = newRecipe });
        
        return newRecipe;
    }

    public Recipe Update(RecipeForUpdate recipeForUpdate)
    {
        Name = recipeForUpdate.Name;
        ImageUrl = recipeForUpdate.ImageUrl;
        CookingTime = recipeForUpdate.CookingTime;
        Description = recipeForUpdate.Description;
        Instructions = recipeForUpdate.Instructions;
        LikesCount = recipeForUpdate.LikesCount;
        IsDraft = recipeForUpdate.IsDraft;
        AuthorId = recipeForUpdate.AuthorId;

        QueueDomainEvent(new RecipeUpdated(){ Id = Id });
        return this;
    }

    public Recipe AddRecipeIngridient(RecipeIngridient recipeIngridient)
    {
        _recipeIngridients.Add(recipeIngridient);
        return this;
    }
    
    public Recipe RemoveRecipeIngridient(RecipeIngridient recipeIngridient)
    {
        _recipeIngridients.RemoveAll(x => x.Id == recipeIngridient.Id);
        return this;
    }

    public Recipe AddUserFavorite(UserFavorite userFavorite)
    {
        _userFavorites.Add(userFavorite);
        return this;
    }
    
    public Recipe RemoveUserFavorite(UserFavorite userFavorite)
    {
        _userFavorites.RemoveAll(x => x.Id == userFavorite.Id);
        return this;
    }

    public Recipe AddComment(Comment comment)
    {
        _comments.Add(comment);
        return this;
    }
    
    public Recipe RemoveComment(Comment comment)
    {
        _comments.RemoveAll(x => x.Id == comment.Id);
        return this;
    }

    public Recipe SetDishType(DishType dishType)
    {
        DishType = dishType;
        return this;
    }

    public Recipe SetSeason(Season season)
    {
        Season = season;
        return this;
    }

    public Recipe SetDiet(Diet diet)
    {
        Diet = diet;
        return this;
    }

    public Recipe SetFoodType(FoodType foodType)
    {
        FoodType = foodType;
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Recipe() { } // For EF + Mocking
}
