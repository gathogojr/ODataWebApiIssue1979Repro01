using System.ComponentModel.DataAnnotations;

namespace Repro01ODataWebApiIssue1979.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
