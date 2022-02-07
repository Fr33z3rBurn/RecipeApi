using RecipeApi.Models.API;

namespace RecipeApi.Services
{
	public interface IUserService
	{
		void CreateNewUser(RegisterUser registerUser);
		bool AuthenticateUser(LoginUser loginUser);
	}
}
