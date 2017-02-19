using NetInfra.Domain;
using System.Linq;

namespace NetInfra.Data
{
  public static class DbInitializer
  {
    public static void Initialize(ApplicationDbContext context)
    {
      context.Database.EnsureCreated();

      // Look for any persons.
      if (!context.Persons.Any())
      {
        var persons = new Person[]
        {
          new Person { Ad = "Serdar", Soyad = "KALKAN" },
          new Person { Ad = "Hakan", Soyad = "KEREM" },
          new Person { Ad = "Ahmet", Soyad = "ÇAMSARI" },
          new Person { Ad = "Ömer", Soyad = "KOCAOĞLU" },
          new Person { Ad = "Serdar", Soyad = "BALIK" },
          new Person { Ad = "Selim", Soyad = "ZEYDANLI" },
        };
        foreach (Person s in persons)
        {
          context.Persons.Add(s);
        }
        context.SaveChanges();
      }

      if (!context.AgTips.Any())
      {
        var agTips = new AgTip[]
        {
          new AgTip { Id = 1, Ad = "Kara Ağı" },
          new AgTip { Id = 2, Ad = "İnternet" },
          new AgTip { Id = 3, Ad = "Yerel Ağ" },
        };
        foreach (AgTip a in agTips)
        {
          context.AgTips.Add(a);
        }
        context.SaveChanges();
      }

      if (!context.Computers.Any())
      {
        var computers = new Computer[]
        {
          new Computer { Stn = "B410-0001", Serino = "TRF3440A1", AgTipId = 1},
          new Computer { Stn = "B410-0002", Serino = "TRF3440A2", AgTipId = 1},
          new Computer { Stn = "IB410-2001", Serino = "TRF3440B1", AgTipId = 2},
          new Computer { Stn = "IB410-2002", Serino = "TRF3440B2", AgTipId = 2},
        };
        foreach (Computer c in computers)
        {
          context.Computers.Add(c);
        }
        context.SaveChanges();
      }
    }
  }
}
