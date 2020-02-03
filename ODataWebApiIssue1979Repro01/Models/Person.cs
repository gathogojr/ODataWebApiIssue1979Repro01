using System.ComponentModel.DataAnnotations;

namespace ODataWebApiIssue1979Repro01.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
