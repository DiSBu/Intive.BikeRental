using Intive.BikeRental.Model;
using Intive.BikeRental.Repository.Interfaces;
using Intive.BikeRental.Repository.Transformers;
using Intive.BikeRental.Utility;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intive.BikeRental.Repository
{
    public class CustomerRepository : BaseRepository<CustomerFieldParameter>, ICustomerRepository
    {
        #region Constructor
        public CustomerRepository()
        {
            Initialize(RepositoryName);
        }

        public string RepositoryName
        {
            get { return "CustomerRepository"; }
        }
        #endregion

        public IList<Customer> GetAllCustomers()
        {
            return ExceptionHandler.Execute(
                this,
                "CustomerRepository => GetAllCustomers",
                () => DbHelper.ExecuteReader(GetFakeCustomersDataReader(), null, dr => new CustomerTransformer().Transform(dr).ToList()));
        }

        private IDataReader GetFakeCustomersDataReader()
        {
            IDataReader dr = new DataTableReader(GetFakeCustomers());
            return dr;
        }

        private static DataTable GetFakeCustomers()
        {
            DataTable table = new DataTable();

            DataColumn idColumn = table.Columns.Add("CustomerId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("LastName", typeof(string));

            table.PrimaryKey = new DataColumn[] { idColumn };

            table.Rows.Add(new object[] { 1, "James", "Bond"});
            table.Rows.Add(new object[] { 2, "Anakin", "Skywalker" });
            table.Rows.Add(new object[] { 3, "Luke", "Skywalker" });

            return table;
        }
    }
}