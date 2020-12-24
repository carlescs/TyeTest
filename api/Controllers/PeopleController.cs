using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;

        public PeopleController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

    public class AddPersonContract
    {
        [Required,MaxLength(80)]
        public string Name { get; set; }
    }

    public class PersonContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}