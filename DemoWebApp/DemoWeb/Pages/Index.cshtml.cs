using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PeopleContext _db;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,PeopleContext db)
        {
            _logger = logger;
            _db = db;
        }
        //Take only desired data
        public void OnGet()
        {
            LoadSampleData();
            var people = _db.People
                .Include(a => a.Addresses)
                .Include(e => e.EmailAddresses)
                .Where(x=>x.Age>=18 && x.Age<=65)
                .ToList();
        }
        //Insert Query On many Items and Save To Database
        private void LoadSampleData() {
            if (_db.People.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _db.AddRange(people);
                _db.SaveChanges();
            }
        
        }
    }
}
