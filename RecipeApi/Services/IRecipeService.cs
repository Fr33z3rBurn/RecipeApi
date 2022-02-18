using RecipeApi.Models;

namespace RecipeApi.Services
{
	public interface IRecipeService
	{
		void CreateRecipe(CreateRecipe recipe);
		void DeleteRecipe(string name);
		void UpdateRecipe(string name, CreateRecipe recipeDto);
		Recipe GetRecipe(string name);
		List<Recipe> SearchByName(string name);
		Recipe GetRandomRecipe();
	}
}
