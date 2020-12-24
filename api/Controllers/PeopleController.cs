using System.Linq;
using System.Threading.Tasks;
using api.Model;
using CommonContracts.People;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _context.People;
            return Ok(people.Select(t => new PersonContract
            {
                Id = t.Id,
                Name = t.Name
            }));
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonContract contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var person=await _context.People.AddAsync(new Person {Name = contract.Name});
            await _context.SaveChangesAsync();
            return Ok(new PersonContract
            {
                Id = person.Entity.Id,
                Name = person.Entity.Name
            });
        }
    }
}