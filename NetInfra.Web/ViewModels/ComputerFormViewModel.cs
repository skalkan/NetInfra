using NetInfra.Domain;
using System.Collections.Generic;

namespace NetInfra.ViewModels
{
  public class ComputerFormViewModel
  {
    public Computer Computer { get; set; }
    public List<AgTip> AgTips { get; set; } = new List<AgTip>();
  }
}
