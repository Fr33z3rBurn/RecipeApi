using MongoDB.Driver;
using RecipeApi.Models;
using RecipeApi.Models.API;

namespace RecipeApi.Services
{
	public class UserService : IUserService
	{
		private readonly IMongoCollection<UserDto> users;

		public UserService(IUserDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			users = database.GetCollection<UserDto>(settings.UsersCollectionName);
		}

		public void CreateNewUser(RegisterUser registerUser)
		{
			var user = UserServiceUtils.MapRegisterToDto(registerUser);
			users.InsertOne(user);
		}
	}
}
