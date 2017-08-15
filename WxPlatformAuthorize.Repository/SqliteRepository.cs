﻿using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Dommel;

namespace WxPlatformAuthorize.Repository
{
    public class SqliteRepository : IRepository
    {
        private string _connectionString;
        public SqliteRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString;
        }
        public void Insert<T>(T obj) where T : class
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Insert(obj);
            }
        }

        public T QueryFirst<T>(string sql, object param = null) where T : class
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                return con.Query<T>(sql, param).FirstOrDefault();
            }
        }
    }
}
