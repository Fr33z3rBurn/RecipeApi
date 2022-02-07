using MongoDB.Driver;
using RecipeApi.Models;
using RecipeApi.Models.API;
using System.Security.Cryptography;

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

		public bool AuthenticateUser(LoginUser loginUser)
		{
			var user = users.Find(x => x.Email == loginUser.Email).Single(); //tolower?

			bool passwordCorrect = true;

			using (var hmac = new HMACSHA512(user.PasswordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginUser.Password));
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != user.PasswordHash[i])
					{
						passwordCorrect = false;
					}
				}
			}

			return passwordCorrect;
		}
	}
}
