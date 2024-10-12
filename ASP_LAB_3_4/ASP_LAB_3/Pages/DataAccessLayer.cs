using System.Data;
using System.Data.SqlClient;

namespace ASP_LAB_3.Pages
{
    public class DataAccessLayer
    {
        private readonly string _connectionString;

        public DataAccessLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable GetData(string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                conn.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetAuthors()
        {
            string query = "SELECT * FROM AuthorsView";
            return GetData(query);
        }

        public DataTable GetGenres()
        {
            string query = "SELECT * FROM GenresView";
            return GetData(query);
        }

        public DataTable GetCustomers()
        {
            string query = "SELECT * FROM CustomersView";
            return GetData(query);
        }

        public DataTable GetSales()
        {
            string query = "SELECT * FROM SalesView";
            return GetData(query);
        }

        public DataTable GetOrders()
        {
            string query = "SELECT * FROM OrdersView";
            return GetData(query);
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}