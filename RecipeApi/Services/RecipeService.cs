using MongoDB.Driver;
using RecipeApi.Models;

namespace RecipeApi.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IMongoCollection<Recipe> recipes;

		public RecipeService(IRecipeDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			recipes = database.GetCollection<Recipe>(settings.RecipesCollectionName);
		}

		public void CreateRecipe(Recipe recipe)
		{
			recipes.InsertOne(recipe);
		}
	}
}
