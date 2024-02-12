//Nick Patterson
// "import statements"
using Lab1Part3.Pages.DataClasses;
using Lab1Part3.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab1Part3.Pages.Chats
{
    public class IndexModel : PageModel
    {
        
        public int ChatID { get; set; }

        
        public string ChatDateTime { get; set; }

        [BindProperty]
        public int EmployeeID { get; set; }

        [BindProperty]
        [Required]
        public Chat NewChats { get; set; }


        public string ChatMessage { get; set; }
        
        [BindProperty]      
        public List<Chat> NewChat { get; set; }

       

        public IndexModel()
        {
            NewChat = new List<Chat>();

        }

        public void OnGet()
        {
            SqlDataReader TableReader = DBClass.ChatReader();
            while (TableReader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(TableReader["ChatID"].ToString()),
                    ChatMessage = TableReader["ChatMessage"].ToString(),
                    ChatDateTime = TableReader["ChatDateTime"].ToString(),
                    EmployeeID = Int32.Parse(TableReader["EmployeeID"].ToString())
                }
            );
            }
            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            
            // Close your connection in DBClass
            DBClass.Lab1DBConnection.Close();

            DBClass.InsertChat(NewChats);


            DBClass.Lab1DBConnection.Close();


            SqlDataReader TableReader = DBClass.ChatReader();
            while (TableReader.Read())
            {
                NewChat.Add(new Chat
                {
                    ChatID = Int32.Parse(TableReader["ChatID"].ToString()),
                    ChatMessage = TableReader["ChatMessage"].ToString(),
                    ChatDateTime = TableReader["ChatDateTime"].ToString(),
                    EmployeeID = Int32.Parse(TableReader["EmployeeID"].ToString())
                }
            );
            }
            return Page();
        }
    }
}