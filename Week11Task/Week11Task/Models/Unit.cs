using System.ComponentModel.DataAnnotations;

namespace Week11Task.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UnitCode { get; set; }

        [Required]
        public string UnitName { get; set; }
    }
}
