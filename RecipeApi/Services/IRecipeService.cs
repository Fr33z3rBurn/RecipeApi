using RecipeApi.Models;

namespace RecipeApi.Services
{
	public interface IRecipeService
	{
		void CreateRecipe(Recipe recipe);
		void DeleteRecipe(Guid id);
	}
}
