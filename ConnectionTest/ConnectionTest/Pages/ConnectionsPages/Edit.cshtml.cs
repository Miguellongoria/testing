using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionTest.Pages.ConnectionsPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Connections Connection { set; get; }

        [TempData]
        public string afterAddMessage { set; get; }

        //first add a parameter that is an integer
        public void OnGet(int id)
        {
            Connection = _db.Connectionitems.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
          if (ModelState.IsValid)
          {  
                   var connectionInDb=_db.Connectionitems.Find(Connection.ID);
                    connectionInDb.ConnectionName=Connection.ConnectionName;
                    connectionInDb.ConnectionDescription = Connection.ConnectionDescription;
                    connectionInDb.StarRating = Connection.StarRating;

                //do this for all your properties...

                await _db.SaveChangesAsync();
                afterAddMessage = "List item updated successfully!";

                return RedirectToPage("index");
          }
            else
            {
                return RedirectToPage();
            }
         }
    }       
}