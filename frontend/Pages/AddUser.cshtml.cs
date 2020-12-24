using System.Threading.Tasks;
using CommonContracts.People;
using frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend.Pages
{
    public class AddUser : PageModel
    {
        private readonly PeopleService _peopleService;

        public AddUser(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [BindProperty]
        public AddPersonContract Person { get; set; }

        public async Task<ActionResult> OnPost()
        {
            await _peopleService.SaveUser(Person.Name);
            return new RedirectToPageResult("Index");
        }
    }
}