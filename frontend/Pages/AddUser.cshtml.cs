using System.Threading.Tasks;
using CommonContracts.People;
using frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace frontend.Pages
{
    public class AddUser : PageModel
    {
        private readonly PeopleService _peopleService;
        private readonly ILogger<AddUser> _logger;

        public AddUser(PeopleService peopleService, ILogger<AddUser> logger)
        {
            _peopleService = peopleService;
            _logger = logger;
        }

        [BindProperty]
        public AddPersonContract Person { get; set; }

        public async Task<ActionResult> OnPost()
        {
            await _peopleService.SaveUser(Person.Name);
            _logger.LogInformation("Saved User");
            return new RedirectToPageResult("Index");
        }
    }
}