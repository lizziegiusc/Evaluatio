

namespace webEval.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Eval
    {
        [Key]
        public int IdStudent { get; set; }
        [Required]
        public  string Name { get; set; }
    }
}