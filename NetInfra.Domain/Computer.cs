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
    public int? AgTipId { get; set; }

    [Display(Name = "Latitude")]
    [DisplayFormat(DataFormatString = "{0:N6}, ApplyFormatInEditMode = true")]
    public decimal? Lat { get; set; }

    [Display(Name = "Longitude")]
    [DisplayFormat(DataFormatString = "{0:N6}, ApplyFormatInEditMode = true")]
    public decimal? Lon { get; set; }
  }
}
