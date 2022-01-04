using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RecipeApi.Models;

namespace RecipeApi.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IMongoCollection<RecipeDb> recipes;

		public RecipeService(IRecipeDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			recipes = database.GetCollection<RecipeDb>(settings.RecipesCollectionName);
		}

		public void CreateRecipe(Recipe recipeDto)
		{
			var recipe = RecipeServiceUtils.MapDtoToDb(recipeDto);
			recipes.InsertOne(recipe);
		}

		public void DeleteRecipe(Guid id)
		{
			var recipe = recipes.Find(r => r.Id == id).FirstOrDefault();
			
			if (recipe != null)
			{
				recipes.DeleteOne(r => r.Id == recipe.Id);
			}
		}
	}
}
