using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApplication1.Dao
{
    public class ConnDao
    {
        protected String StrConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\App_Data\CEP.mdf;Integrated Security=True";
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Carlao\Downloads\TesteCandidato\TesteCandidato\WebApplication1\App_Data\CEP.mdf;Integrated Security=True
        public ConnDao()
        {
            
            String p = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)).Replace("file:\\", "").Replace("\\", @"\");

            StrConn = StrConn.Replace("|DataDirectory|", p);
            
        }

  
    }
}