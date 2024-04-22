using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Ninja
{
    [Key] 
    public int Id { get; set; }

    [Required] 
    [MaxLength(45)] 
    public string Name { get; set; }

    public int Gold { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<NinjaGear> NinjaGear { get; set; }
}