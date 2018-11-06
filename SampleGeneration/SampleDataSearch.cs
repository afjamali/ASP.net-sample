using CandidateTestStandard.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CandidateTestStandard.SampleGeneration
{
    public class SampleDataSearch
    {
        public static IEnumerable<Order> SearchOrder(string firstName, string lastName, string fromDate, string toDate, string orderMethod)
        {
            if (!IsvalidInput(firstName) || !IsvalidInput(lastName) || !IsvalidInput(fromDate) || !IsvalidInput(toDate) || !IsvalidInput(orderMethod))
                return null;
            var result = new List<Order>();
            SqlCommand cmd = DBConnection.Connect2db("localhost", "AdventureWorks2017");
            cmd.CommandText = "spSalesOrderSearch";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DateType", orderMethod);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(fromDate, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(toDate, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy-MM-dd HH:mm:ss"));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Order
                {
                    Name = reader["FirstName"].ToString().Trim() + " " + reader["LastName"].ToString().Trim(),
                    AccountNumber = reader["AccountNumber"].ToString().Trim(),
                    ShipToAddress = reader["ShipToAddress"].ToString().Trim(),
                    ShipMethod = reader["ShipMethod"].ToString().Trim(),
                    SubTotal = reader["SubTotal"].ToString().Trim(),
                    Tax = reader["TaxAmt"].ToString().Trim(),
                    Freight = reader["Freight"].ToString().Trim(),
                    Total = reader["TotalDue"].ToString().Trim(),
                    SalesOrderID = reader["SalesOrderID"].ToString().Trim()
                });
            }
            reader.Close();
            DBConnection.Disconnect_from_db();
            return result;
        }

        public static Product ProductInfo(string salesOrderID)
        {
            if (salesOrderID == null)
                return null;

            try
            {
                int t = int.Parse(salesOrderID);
            }
            catch
            {
                return null;
            }

            SqlCommand cmd = DBConnection.Connect2db("localhost", "AdventureWorks2017");
            cmd.CommandText = "spSalesOrderDetail";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", salesOrderID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var result = new Product
            {
                Name = reader["Name"].ToString().Trim(),
                ProductNumber = reader["ProductNumber"].ToString().Trim(),
                Quantity = reader["OrderQty"].ToString().Trim(),
                UnitPrice = reader["UnitPrice"].ToString().Trim(),
                Discount = reader["UnitPriceDiscount"].ToString().Trim(),
                LineTotal = reader["LineTotal"].ToString().Trim()
            };

            reader.Close();
            DBConnection.Disconnect_from_db();
            return result;
        }

        private static bool IsvalidInput(string input)
        {
            if (input != null && input != "")
                return true;

            return false;
        }
    }

}