using System.ComponentModel.DataAnnotations;

namespace NetInfra.Domain
{
  public class Computer
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Stn { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Seri No")]
    public string Serino { get; set; }

    public AgTip AgTip { get; set; }

    [Display(Name = "Ağ Tipi")]
    public byte? AgTipId { get; set; }
  }
}
