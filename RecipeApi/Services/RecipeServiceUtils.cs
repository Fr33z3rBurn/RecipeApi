using RecipeApi.Models;

namespace RecipeApi.Services
{
	internal static class RecipeServiceUtils
	{
		public static RecipeDb MapDtoToDb(Recipe recipe)
		{
			var db = new RecipeDb()
			{
				Id = recipe.Id,
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

		public static Recipe MapToRecipeDto(RecipeDb recipeDb)
		{
			var dto = new Recipe()
			{
				Id = recipeDb.Id,
				OwnerUserId = recipeDb.OwnerUserId,
				IsPoolRecipe = recipeDb.IsPoolRecipe,
				CreatedFromPool = recipeDb.CreatedFromPool,
				RecipeName = recipeDb.RecipeName,
				RecipeNationality = recipeDb.RecipeNationality,
				Ingredients = recipeDb.Ingredients,
				Steps = recipeDb.Steps,
				PrepTimeMinutes = recipeDb.PrepTimeMinutes,
				CookTimeMinutes = recipeDb.CookTimeMinutes,
				ReadyInMinutes = recipeDb.ReadyInMinutes,
				Creator = recipeDb.Creator,
				Notes = recipeDb.Notes,
				OriginalSource = recipeDb.OriginalSource,
				ApprovalStatus = recipeDb.ApprovalStatus
			};

			return dto;
		}
	}
}
