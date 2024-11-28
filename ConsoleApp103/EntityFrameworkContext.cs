using System;

namespace Test
{
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Runtime.Remoting.Contexts;
    using System.Web.UI.WebControls;
    
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext()
        {
        }
    }

    class SqlInjection
    {
        TextBox categoryTextBox;
        string connectionString;

        public void GetDataSetByCategory()
        {

            // BAD: the category might have SQL special characters in it
            using (var connection = new SqlConnection(connectionString))
            {
                var query1 = "SELECT ITEM,PRICE FROM PRODUCT WHERE ITEM_CATEGORY='"
                  + categoryTextBox.Text + "' ORDER BY PRICE";
                var adapter = new SqlDataAdapter(query1, connection);
                var result = new DataSet();
                adapter.Fill(result);
            }

            // The variable used in SQL is not recognized as tainted (coming from the user
            // input) and therefore the tool does not recognize the SQL injection vulnerability.
            using (var connection = new SqlConnection(connectionString))
            {
                string myNotTaintedString = "CONSUMER_GOODS";

                var query1 = "SELECT ITEM,PRICE FROM PRODUCT WHERE ITEM_CATEGORY='"
                  + myNotTaintedString + "' ORDER BY PRICE";
                var adapter = new SqlDataAdapter(query1, connection);
                var result = new DataSet();
                adapter.Fill(result);
            }

            // The variable used in SQL is recognized as tainted because of custom configuration 
            // indicating that the UnknownAPI.getCategory() is considerd a source of user input
            using (var connection = new SqlConnection(connectionString))
            {
                var query1 = "SELECT ITEM,PRICE FROM PRODUCT WHERE ITEM_CATEGORY='"
                  + UnknownAPI.getCategory() + "' ORDER BY PRICE";
                var adapter = new SqlDataAdapter(query1, connection);
                var result = new DataSet();
                adapter.Fill(result);
            }



        }

    }
}
