using System;
namespace project
{
  class Program
  {
    static void Main()
    {
      // синглтон
      GardenController controller = GardenController.Instance;
      System.Console.WriteLine("НАчало работы");

      // добавление устройств в контролер
      IGardenDevice irrrigation = FactoryDevices.CreateDevice("irrigation", "Система полива");
      irrrigation.Configure(new Dictionary<string, object> { { "Задержка", 10 } });

      IGardenDevice lightning = FactoryDevices.CreateDevice("lightning", "Система освещения");
      lightning.Configure(new Dictionary<string, object> { { "Освещенность", 100 } });

      IGardenDevice climate = FactoryDevices.CreateDevice("climate", "Система теплорегуляции");
      climate.Configure(new Dictionary<string, object> { { "Температура", 30 } });

      IGardenDevice sensor = FactoryDevices.CreateDevice("climate", "Система теплорегуляции");
      // sensor.Configure(new Dictionary<string, object> { { "Кислотность", 6.0 }, { "Соленость", 26.0 } });

      // добавление
      controller.AddDevice(irrrigation);
      controller.AddDevice(lightning);
      controller.AddDevice(climate);
      controller.AddDevice(sensor);


      // управление ими

      // проверкаа любой из систем


      // попыткаа удления
    }
  }
}