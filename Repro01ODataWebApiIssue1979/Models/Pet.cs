using System.ComponentModel.DataAnnotations;

namespace Repro01ODataWebApiIssue1979.Models
{
    public partial class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Person Owner { get; set; }
    }
}
