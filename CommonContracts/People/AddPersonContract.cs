using System.ComponentModel.DataAnnotations;

namespace CommonContracts.People
{
    public class AddPersonContract
    {
        [Required,MaxLength(80)]
        public string Name { get; set; }
    }
}