using RecipeApi.Models;

namespace RecipeApi.Services
{
	internal static class RecipeServiceUtils
	{
		public static RecipeDb MapDtoToDb(Recipe recipe)
		{
			var db = new RecipeDb()
			{
				OwnerUserId = recipe.OwnerUserId,
				IsPoolRecipe = recipe.IsPoolRecipe,
				CreatedFromPool	= recipe.CreatedFromPool,
				RecipeName = recipe.RecipeName,
				RecipeNationality = recipe.RecipeNationality,
				Ingredients = recipe.Ingredients,
				Steps = recipe.Steps,
				PrepTimeMinutes = recipe.PrepTimeMinutes,
				CookTimeMinutes = recipe.CookTimeMinutes,
				ReadyInMinutes = recipe.ReadyInMinutes,
				Creator	= recipe.Creator,
				Notes = recipe.Notes,
				OriginalSource = recipe.OriginalSource,
				ApprovalStatus = recipe.ApprovalStatus,
			};

			return db;
		}
	}
}
