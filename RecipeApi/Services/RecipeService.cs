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
			//TODO Map so there is a GUID
			recipes.InsertOne(recipe);
		}

		public void DeleteRecipe(Guid id)
		{
			var recipe = recipes.Find(r => r.Id == id.ToString()).FirstOrDefault();
			
			if (recipe != null)
			{
				recipes.DeleteOne(r => r.Id == recipe.Id);
			}
		}
	}
}
