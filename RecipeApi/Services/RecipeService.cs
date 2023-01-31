using MongoDB.Bson;
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

		public void CreateRecipe(CreateRecipe recipeDto)
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

		public void UpdateRecipe(string name, CreateRecipe recipeDto)
		{
			var existingRecipeId = recipes.Find(r => r.RecipeName == name).SingleOrDefault().Id;
			var recipe = RecipeServiceUtils.MapToDto(recipeDto);
			
			recipes.ReplaceOne(r => r.Id == existingRecipeId, recipe);
		}

		public Recipe GetRandomRecipe()
		{
			//TODO make more performant way to do this
			var Filter = Builders<RecipeDto>.Filter.Empty;
			long count = recipes.CountDocuments(Filter);
			//var allRecipes = recipes.Find(Builders<RecipeDto>.Filter.Empty).ToList();
			var allRecipes = recipes.Find(Builders<RecipeDto>.Filter.Where(r => r.IsPoolRecipe == true)).ToList();

			Random random = new Random();
			int randomRecipeNumber = random.Next(0, Convert.ToInt32(count));

			return RecipeServiceUtils.MapToRecipe(allRecipes[randomRecipeNumber]);
		}

		public Recipe GetRecipe(string name)
		{
			var recipe = recipes.Find(r => r.RecipeName == name).Single();

			return RecipeServiceUtils.MapToRecipe(recipe);
		}

		public List<Recipe> SearchByName(string name)
		{
			var recipeList = recipes.Find(r => r.RecipeName.ToLower().Contains(name.ToLower())).ToList();

			return RecipeServiceUtils.MapToRecipeList(recipeList);
		}
	}
}
