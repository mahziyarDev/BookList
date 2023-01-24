using System.ComponentModel.DataAnnotations;

namespace RazorPage.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "نام را وارد کنید")]
    [MaxLength(300)]
    public string Name { get; set; }

    [Required(ErrorMessage = "نام نویسنده را وارد کنید")]
    [MaxLength(400)]
    public string Author { get; set; }

    [Required]
    public DateTime CreateData { get; set; }
    
}