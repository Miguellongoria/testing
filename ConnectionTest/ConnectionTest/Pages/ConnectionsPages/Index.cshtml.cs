using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConnectionTest.Pages.ConnectionsPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string afterAddMessages { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Connections> myConnections { get; set; }

        public async Task OnGet()
        {
            myConnections = await _db.Connectionitems.ToListAsync();

        }

        public async Task<IActionResult>OnPostDelete(int id)
        {
            var theConnection = _db.Connectionitems.Find(id);
            _db.Connectionitems.Remove(theConnection);
            await _db.SaveChangesAsync();
            afterAddMessages = "Connection deleted sucessfully!";
            //if you dont place anything in these parentheses then it redirects to the same page (refreshes)
            return RedirectToPage();
        }
    }
}