using System.ComponentModel.DataAnnotations;

namespace CalcService.Backend.Api.Data;

public class Numbers
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int Num1 { get; set; }    
    [Required]
    public int Num2 { get; set; }
}