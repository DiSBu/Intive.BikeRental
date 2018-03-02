using System;
using System.Data;
using System.Data.SqlClient;

namespace Intive.BikeRental.Repository.Interfaces
{
    public interface IDataAccessHelper
    {
        T ExecuteReader<T>(IDataReader dr, SqlParameter[] parameters, Func<IDataReader, T> func, int? customTimeout = null);
    }
}