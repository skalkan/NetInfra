using System.ComponentModel.DataAnnotations;

namespace NetInfra.Domain
{
  public class AgTip 
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Ad { get; set; }
  }
}
