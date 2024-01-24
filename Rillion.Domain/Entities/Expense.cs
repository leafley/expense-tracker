using System.ComponentModel.DataAnnotations;

public class Expense
{
    [Required]
    public long Id { get; set; }
    [Required]
    public long UserId { get; set; }
    [Required]
    public long Amount { get; set; }
    [Required]
    public long CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
}