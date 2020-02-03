using System.ComponentModel.DataAnnotations;

namespace ODataWebApiIssue1979Repro01.Models
{
    public partial class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Person Owner { get; set; }
    }
}
