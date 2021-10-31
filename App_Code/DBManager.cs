using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for DBManager
/// </summary>
public class DBManager
{
	MySqlConnection cn;
	MySqlCommand cmd;

	string cnstring = ConfigurationManager.ConnectionStrings["BooksMahalConnectionString"].ConnectionString.ToString();

    public bool ExInsertUpdateorDelete(string ycmd)
    {
		cn = new MySqlConnection(cnstring);
		MySqlCommand mycmd = new MySqlCommand(ycmd, cn);
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        int NumofAffectedRows = mycmd.ExecuteNonQuery();
        cn.Close();
        if (NumofAffectedRows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public DataTable SelectQuery(string commond)
    {
		cn = new MySqlConnection(cnstring);
		MySqlDataAdapter da = new MySqlDataAdapter(commond, cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}