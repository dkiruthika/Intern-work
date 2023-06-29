using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using static ProductManagement.Models.ProductModel;

namespace ProductManagement.Models
{
    public interface IRepositoryClass
    {
        bool Add(ProductModel pdt);
        bool Edit(ProductModel pdt);
        ProductModel GetOldDetail(int pdtId);
        bool Add(PurchaseModel purchase);
    }
    public class RepositoryClass : IRepositoryClass
    {
        public bool Add(ProductModel pdt)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand("XC_Ki_InsertProduct", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductName", pdt.ProductName);
            command.Parameters.AddWithValue("@Active", pdt.Active);
            conn.Open();
            command.ExecuteNonQuery();

            return true;
        }
        public bool Edit(ProductModel pdt)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand("XC_Ki_UpdateProduct", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", pdt.Id);
            command.Parameters.AddWithValue("@ProductName", pdt.ProductName);
            command.Parameters.AddWithValue("@Active", pdt.Active);
            conn.Open();
            command.ExecuteNonQuery();
            return true;
        }
        public ProductModel GetOldDetail(int pdtId)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand("GetProductById", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", pdtId);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.Id= reader.GetInt32(reader.GetOrdinal("Id"));
                product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                product.Active = reader.GetString(reader.GetOrdinal("Active"));
                return product;
            }
            return null;
            
            
        }
        public bool Add(PurchaseModel purchase)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand("XC_Ki_InsertPurchase", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            // Add parameters to the stored procedure
            command.Parameters.AddWithValue("@ProductId", purchase.ProductId);
            command.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);
            command.Parameters.AddWithValue("@Quantity", purchase.Quantity);
            conn.Open();
            // Execute the stored procedure
            command.ExecuteNonQuery();
            return true;
        }
    }
}