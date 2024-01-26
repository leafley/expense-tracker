using System.ComponentModel.DataAnnotations;

namespace Rillion.Domain.Entities;

public class Category
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public ICollection<Expense> Expenses { get; } = new List<Expense>();
}