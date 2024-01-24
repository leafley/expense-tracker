using System.ComponentModel.DataAnnotations;

public class Category
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public ICollection<Expense> Expenses { get; } = Array.Empty<Expense>();
}