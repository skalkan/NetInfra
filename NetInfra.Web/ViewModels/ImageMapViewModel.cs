using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetInfra.Web.ViewModels
{
  public class ImageMapViewModel
  {
    public string ImagePath { get; set; }
    public List<int> x_points { get; set; } = new List<int>();
    public List<int> y_points { get; set; } = new List<int>();
  }
}
