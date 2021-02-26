using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gym_Management_system.Models
{
    public class DBAccess
    {
        //SQLiteConnection cn = new SQLiteConnection(@"Data Source=|DataDirectory|\Kaya.db;Version=3;");
        //SQLiteConnection cn = new SQLiteConnection(@"Data Source=C:\Users\you97\Desktop\Kaya Store management\stock.db;Version=3;");
        //SQLiteCommand cmd;
        //SQLiteDataReader dr;
        static SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Kaya.mdf;Integrated Security=True");
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static DataTable Read(string Requete)
        {
            try
            {
                cmd = new SqlCommand(Requete, cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                DataTable Table = new DataTable();
                Table.Load(dr);
                cn.Close();
                return Table;
            }
            catch
            {
                cn.Close();
                return null;
            }
        }

        public static int Affect(string Requete)
        {
            try
            {
                cmd = new SqlCommand(Requete, cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                cn.Close();
                return i;
            }
            catch
            {
                cn.Close();
                return 0;
            }
        }

    }
}