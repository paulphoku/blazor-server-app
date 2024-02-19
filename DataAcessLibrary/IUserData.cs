using DataAcessLibrary.Models;

namespace DataAcessLibrary
{
	public interface IUserData
	{
		Task<List<UserModel>> GetUser(UserModel user);
		Task<List<UserModel>> GetUsers();
		Task InsertUser(UserModel user);
		Task UpdateUser(UserModel user);
	}
}