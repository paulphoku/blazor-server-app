﻿
namespace DataAcessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameter);
        Task SaveData<T>(string sql, T parameter);
    }
}