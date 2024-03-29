// Nick Patterson "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1Part3.Pages.DataCollabs
{
    public class IndexModel : PageModel
    {

        public List<DataCollab> DataCollabsTable { get; set; }

        public IndexModel()
        {
            DataCollabsTable = new List<DataCollab>();
        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.TableReader();
            while (TableReader.Read())
            {
                DataCollabsTable.Add(new DataCollab
                {

                    //CollabID = Int32.Parse(TableReader["CollabID"].ToString()),
                    //DataName = TableReader["DataName"].ToString(),
                }
            );
            }
        
            // Close your connection in DBClass
            DBClass.LABTHREEDBConnection.Close();
        }
    }
}
