using Intive.BikeRental.Repository.Interfaces;
using Intive.BikeRental.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Intive.BikeRental.Repository
{
    public class DataAccessHelper : IDataAccessHelper
    {
        private SqlDatabase _db;
        private int _commandTimeout;

        public DataAccessHelper(string connectionStringKey)
        {
            ExceptionHandler.Execute(this, "DataAccessHelper", () =>
            {
                _db = new SqlDatabase(ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString);
                var key = ConfigurationManager.AppSettings["CommandTimeout"];
                _commandTimeout = (key != null) ? int.Parse(key) : 120;
            });
        }

        public T ExecuteReader<T>(IDataReader dr, Action<SqlDatabase, DbCommand, SqlParameter[]> commandAction, SqlParameter[] parameters, Func<IDataReader, T> func, int? customTimeout = null)
        {
            return ExceptionHandler.Execute(
                this,
                "ExecuteReader",
                () =>
                {
                    T result;

                    result = func(dr);
                    dr.Dispose();

                    return result;
                });
        }

        public T ExecuteReader<T>(IDataReader dr, SqlParameter[] parameters, Func<IDataReader, T> func, int? customTimeout = null)
        {
            return ExceptionHandler.Execute(
                this,
                "ExecuteReader",
                () => ExecuteReader(
                    dr,
                    (database, cmd, prms) =>
                    {
                        cmd.CommandTimeout = customTimeout.HasValue ? customTimeout.Value : _commandTimeout;
                        foreach (var p in parameters)
                        {
                            switch (p.Direction)
                            {
                                case ParameterDirection.Input:
                                    database.AddInParameter(cmd, p.ParameterName, p.DbType, p.Value);
                                    break;
                                case ParameterDirection.Output:
                                    database.AddOutParameter(cmd, p.ParameterName, p.DbType, p.Size);
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                        }
                    },
                    parameters,
                    func));
        }
    }
}