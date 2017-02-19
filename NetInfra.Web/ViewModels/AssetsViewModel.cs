using NetInfra.Domain;
using System.Collections.Generic;

namespace NetInfra.ViewModels
{
  public class AssetsViewModel
  {
    public Person Person { get; set; }
    public List<Computer> Computers { get; set; }
  }
}
