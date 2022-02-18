using RecipeApi.Models;

namespace RecipeApi.Services
{
	internal static class RecipeServiceUtils
	{
		public static RecipeDto MapToDto(CreateRecipe recipe)
		{
			var db = new RecipeDto()
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

		public static Recipe MapToRecipe(RecipeDto recipeDb)
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

		public static List<Recipe> MapToRecipeList(List<RecipeDto> recipeDbList)
		{
			var recipeList = new List<Recipe>();

			foreach (var recipeDb in recipeDbList)
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
				recipeList.Add(dto);
			}
			
			return recipeList;
		}
	}
}
