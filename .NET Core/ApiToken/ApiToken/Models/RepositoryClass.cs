using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ApiToken.Models
{
    public interface IRepositoryClass
    {
        bool Add(ProductModel pdt);
        bool Edit(ProductModel pdt);
        ProductModel GetOldDetail(int pdtId);
        List<ProductModel> GetAllProducts();
    }
    public class RepositoryClass:IRepositoryClass
    {
        private readonly IConfiguration _configuration;
        //private readonly string connectionString;

        public RepositoryClass(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public List<ProductModel> GetAllProducts()
        {
            string connectionString = _configuration.GetConnectionString("MyConn");
            List<ProductModel> products = new List<ProductModel>();
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand("GetAllProducts", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductModel product = new ProductModel();
                    product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                    product.Active = reader.GetString(reader.GetOrdinal("Active"));

                    products.Add(product);
                }
            }

            return products;
        }

        public bool Add(ProductModel pdt)
        {
            string connectionString = _configuration.GetConnectionString("MyConn");
            //string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("XC_Ki_InsertProduct", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductName", pdt.ProductName);
            command.Parameters.AddWithValue("@Active", pdt.Active);
            conn.Open();
            command.ExecuteNonQuery();

            return true;
        }
        public bool Edit(ProductModel pdt)
        {
            string connectionString = _configuration.GetConnectionString("MyConn");
            //string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("XC_Ki_UpdateProduct", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", pdt.Id);
            command.Parameters.AddWithValue("@ProductName", pdt.ProductName);
            command.Parameters.AddWithValue("@Active", pdt.Active);
            conn.Open();
            command.ExecuteNonQuery();
            return true;
        }
        public ProductModel GetOldDetail(int pdtId)
        {
            string connectionString = _configuration.GetConnectionString("MyConn");
            //string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("GetProductById", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", pdtId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                product.Active = reader.GetString(reader.GetOrdinal("Active"));
                return product;
            }
            return null;


        }
    }
}
