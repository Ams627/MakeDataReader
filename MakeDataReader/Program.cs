using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MakeDataReader
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var table = new DataTable();
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("tradeid", typeof(string));

                var data = new[]
                {
                    (id:1, tradeId:"XY10008"),
                    (id:2, tradeId:"XY10009"),
                    (id:3, tradeId:"XY10010"),
                };         

                foreach (var (id, tradeId) in data)
                {
                    var row = table.NewRow();
                    row["id"] = id;
                    row["tradeId"] = tradeId;
                    table.Rows.Add(row);
                }

                IDataReader rdr = table.CreateDataReader();
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
