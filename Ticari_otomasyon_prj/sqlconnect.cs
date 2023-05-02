using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari_otomasyon_prj
{
    internal class sqlconnect
    { 
        public SqlConnection bağlan()
        {
            SqlConnection bağla = new SqlConnection(@"Data Source = localhost\SQLEXPRESS ; Initial Catalog = Dbo_ticariotomasyon; Integrated Security = True");
            bağla.Open();
            return bağla;
        }

            
            

    }
}
