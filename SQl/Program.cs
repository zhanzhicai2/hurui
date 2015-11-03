using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;

namespace SQl
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string source = "server=116.254.206.41;database=db_gzbdc;uid=u_gzbdc;pwd=p_gzbdc";//连接字符串
            SqlConnection con = new SqlConnection(source);
            con.Open();//打开数据库连接
            Console.WriteLine("djsa");
            //string sql = "update dbo.News set Newstitle ='历史性' where NewsID =156";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //int cout = cmd.ExecuteNonQuery();//影响行数
            //Console.WriteLine(cout);
            //string sqlselect = "select NewsTitle,NewsContent from dbo.News";
            //SqlCommand cmd2 = new SqlCommand(sqlselect,con);
            //SqlDataReader reeder = cmd2.ExecuteReader();
            //if(reeder.Read())
            //{
            //    Console.WriteLine("NewsTitle:{0,-300} NewsContent:{1}",reeder[0],reeder[1]);
            //}
            string sql3 = "select * from dbo.News for xml auto";
            SqlCommand cmd3 = new SqlCommand(sql3,con);
            XmlReader xmldata = cmd3.ExecuteXmlReader();
            xmldata.Read();
            string data;
            do
            {
                data = xmldata.ReadOuterXml();
                if (!string.IsNullOrEmpty(data))
                {
                    Console.WriteLine(data);
                }
            } while (!string.IsNullOrEmpty(data));
            //Console.WriteLine(o);
            con.Close();//关闭数据库连接
            Console.ReadLine();
        }
        
    }
}
