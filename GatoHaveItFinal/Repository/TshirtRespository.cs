using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using GatoHaveItFinal.Models;


//namespace GatoHaveItFinal.Repository
//{
//    public class TshirtRespository
//    {
//        private SqlConnection connect; //To handle connection related activities

//        private void connection()
//        {
//            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
//            //configMgr is web.config
//            connect = new SqlConnection(constr);  //creates connection method to connect to database
//        }


//        public List<MerchandiseModel> Tshirts()
//        {
//            connection();
//            List<MerchandiseModel> TshirtList = new List<MerchandiseModel>();
//            SqlCommand command = new SqlCommand("Tshirts", connect); //1 param is stored proc name,  2 param is connection defined above
//            command.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter da = new SqlDataAdapter(command); //this is connection used to receive data back from command
//            DataTable table = new DataTable(); //this handles data that is returned

//            connect.Open(); // opens connection to database
//            da.Fill(table); //data adapter, get/fill the table with data entered
//            connect.Close(); //close data connection, always close after data received, database may only allow limited num of connections

//            foreach (DataRow dr in table.Rows) //loop through rows in data table and assigning to data row (dr) table.rows is collection of data
//            {
//                TshirtList.Add(
//                    new MerchandiseModel
//                    {
//                        ProductId = Convert.ToInt32(dr["Product"]),
//                        Description = Convert.ToString(dr["Description"]),
//                        UnitPrice = Convert.ToDecimal(dr["Amount"]),
//                        Image = Convert.ToString(dr["Image"])
//                    });
//            }

//            return TshirtList;

//        }
//    }
//}



