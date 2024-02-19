using DataAcessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibrary
{
	public class UserData : IUserData
	{
		private readonly ISqlDataAccess _db;

		public UserData(ISqlDataAccess db)
		{
			_db = db;
		}

		public Task<List<UserModel>> GetUsers()
		{
			string sql = "SELECT * FROM _USER";
			return _db.LoadData<UserModel, dynamic>(sql, new { });
		}

		public Task<List<UserModel>> GetUser(UserModel user)
		{
			string sql = "SELECT * FROM _USER WHERE username = @username";
			return _db.LoadData<UserModel, dynamic>(sql, new { user.username });
		}

		public Task InsertUser(UserModel user)
		{
			user.datecreated = DateTime.Now;
			user.dateupdated = DateTime.Now;

			string sql = @"EXEC addUser @username, @password, @datecreated, @dateupdated";
			return _db.SaveData(sql, user);
		}

		public Task UpdateUser(UserModel user)
		{
			user.dateupdated = DateTime.Now;

			string sql = @"EXEC updateUser @username, @password, @dateupdated";
			return _db.SaveData(sql, user);
		}
	}
}
