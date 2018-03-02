using System;
using System.Data;
using System.Data.SqlClient;

namespace Intive.BikeRental.Utility
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CreateFieldAttribute : Attribute
    {
        public DbType Type { get; set; }

        public ParameterDirection Direction { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public SqlParameter Process(object value)
        {
            return new SqlParameter { ParameterName = Name ?? value.ToString(), DbType = Type, Direction = Direction, Size = (Size != 0) ? Size : default(int) };
        }
    }
}