using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Text;

namespace Community.Application.Dapper
{
    public static class DapperHandle
    {
        private static IConfiguration configuration = null;

        //public static DapperQueryHandle<T> CreateQueryHandle<T>(string sql, T objectCon) where T 
        //{
        //    return new DapperQueryHandle<T>(sql, objectCon);
        //}


        //public static SqlConnection OpenConnection()
        //{
        //    if (configuration == null)
        //    {
        //        var config = new ConfigurationBuilder();
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
        //        configuration = config.Build();
        //    }
        //    var connectionStr = configuration.GetConnectionString("MySqlStrings");
           
        //    return sqlConnection;
        //}
    }
}
