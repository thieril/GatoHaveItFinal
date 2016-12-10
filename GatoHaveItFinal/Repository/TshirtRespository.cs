using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatoHaveItFinal.Repository
{
    public class TshirtRespository
    {
    }
}








//MusicStore ADO CODE
public List<AlbumModel> GetAllAblums()
{
    connection();
    List<AlbumModel> AlbumList = new List<AlbumModel>();
    SqlCommand command = new SqlCommand("Select_All_Albumns", connect); //1 param is stored proc name,  2 param is connection defined above
    command.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter da = new SqlDataAdapter(command); //this is connection used to receive data back from command
    DataTable table = new DataTable(); //this handles data that is returned

    connect.Open(); // opens connection to database
    da.Fill(table); //data adapter, get/fill the table with data entered
    connect.Close(); //close data connection, always close after data received, database may only allow limited num of connections

    foreach (DataRow dr in table.Rows) //loop through rows in data table and assigning to data row (dr) table.rows is collection of data
    {
        AlbumList.Add(
            new AlbumModel
            {
                AlbumID = Convert.ToInt32(dr["AlbumID"]), //convert sql database type int to datatype (32) so C# can use it 
                        Title = Convert.ToString(dr["Title"]), //convert varchar to string 
                        Price = Convert.ToDecimal(dr["Price"]),
                AlbumArtURL = Convert.ToString(dr["AlbumArtURL"])
            }
            ); //Database has stored procedures, we loop through each row in datatable, adding album model to value in data row and converting into datatype VB/C# can use
    }
    return AlbumList;  //returning model
}