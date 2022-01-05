using RecipeApi.Models;

namespace RecipeApi.Services
{
	public interface IRecipeService
	{
		void CreateRecipe(Recipe recipe);
		void DeleteRecipe(string name);
		void UpdateRecipe(string name, Recipe recipeDto);
		Recipe GetRecipe(string name);
	}
}
