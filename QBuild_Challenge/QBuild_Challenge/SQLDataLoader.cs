using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QBuild_Challenge
{
    class SQLDataLoader
    {
        [STAThread]
        public static Components GetComponents()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database"));
            SqlConnection _conn = new SqlConnection();
            _conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|QBuildChallenge_Datas.mdf;Integrated Security=True";
            try
            {
                _conn.Open();
                if (_conn.State == ConnectionState.Open)
                {
                    SqlCommand _sqlCmd = new SqlCommand();
                    _sqlCmd.CommandTimeout = 60;
                    _sqlCmd.Connection = _conn;
                    _sqlCmd.CommandType = CommandType.Text;
                    _sqlCmd.CommandText = @"SELECT Count(*) FROM dbo.BOM
                                            LEFT JOIN dbo.Parts ON dbo.BOM.COMPONENT_NAME = dbo.Parts.NAME";
                    object _count = _sqlCmd.ExecuteScalar();
                    int _iCount = (int)_count;
                    _sqlCmd.CommandText = @"SELECT 
                                            RTRIM(dbo.BOM.PARENT_NAME), 
                                            RTRIM(dbo.BOM.COMPONENT_NAME),
                                            RTRIM(dbo.Parts.PART_NUMBER),
                                            RTRIM(dbo.Parts.TITLE),
                                            RTRIM(dbo.Parts.TYPE), 
	                                        RTRIM(dbo.Parts.ITEM),
                                            RTRIM(LTRIM(dbo.Parts.MATERIAL)), 
                                            dbo.BOM.QUANTITY
                                            FROM dbo.BOM
                                            LEFT JOIN dbo.Parts ON dbo.BOM.COMPONENT_NAME = dbo.Parts.NAME
                                            ORDER BY PARENT_NAME";
                    SqlDataReader _dr = _sqlCmd.ExecuteReader(CommandBehavior.SingleResult);
                    Component[] _tArraycmpnt = new Component[_iCount];
                    for (int i = 0; i < _iCount; i++)
                    {
                        _dr.Read();
                        _tArraycmpnt[i] = new Component(_dr[0].ToString(), _dr[1].ToString(), _dr[2].ToString(), _dr[3].ToString(), _dr[4].ToString(), _dr[5].ToString(), _dr[6].ToString(), (int)_dr[7]);
                    }
                    _conn.Close();
                    return new Components(_tArraycmpnt);
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _conn.Close();
            return null;
        }
    }
}
