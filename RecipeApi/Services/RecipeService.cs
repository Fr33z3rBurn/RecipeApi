using MongoDB.Driver;
using RecipeApi.Models;

namespace RecipeApi.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IMongoCollection<RecipeDto> recipes;

		public RecipeService(IRecipeDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			recipes = database.GetCollection<RecipeDto>(settings.RecipesCollectionName);
		}

		public void CreateRecipe(Recipe recipeDto)
		{
			var recipe = RecipeServiceUtils.MapToDto(recipeDto);
			recipes.InsertOne(recipe);
		}

		public void DeleteRecipe(string name)
		{
			var recipe = recipes.Find(r => r.RecipeName == name).FirstOrDefault();
			
			if (recipe != null)
			{
				recipes.DeleteOne(r => r.Id == recipe.Id);
			}
		}

		public void UpdateRecipe(string name, Recipe recipeDto)
		{
			var existingRecipeId = recipes.Find(r => r.RecipeName == name).SingleOrDefault().Id;
			var recipe = RecipeServiceUtils.MapToDto(recipeDto);
			
			recipes.ReplaceOne(r => r.Id == existingRecipeId, recipe);
		}

		public Recipe GetRecipe(string name)
		{
			var recipe = recipes.Find(r => r.RecipeName == name).Single();
			
			return RecipeServiceUtils.MapToRecipe(recipe);

		}
	}
}
