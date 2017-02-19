using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetInfra.Domain
{
  public class Person
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Ad { get; set; }

    [Required]
    [StringLength(50)]
    public string Soyad { get; set; }
  }
}
