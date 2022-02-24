using RecipeApi.Models.API;

namespace RecipeApi.Services
{
	public interface IUserService
	{
		void CreateNewUser(RegisterUser registerUser);
		RecipeWebUser AuthenticateUser(LoginUser loginUser);
	}
}
