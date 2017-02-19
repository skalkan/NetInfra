using System.ComponentModel.DataAnnotations;

namespace NetInfra.Domain
{
  public class AgTip 
  {
    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Ad { get; set; }
  }
}
