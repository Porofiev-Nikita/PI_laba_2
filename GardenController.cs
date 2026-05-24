public class GardenController
{
  private static GardenController _instance;
  private static readonly object _lock = new object();
  private List<IGardenDevice> _devices = new List<IGardenDevice>();

  // Приватный конструктор и реализация Singleton
  // Методы для управления садовыми устройствами

  private GardenController()
  {
    System.Console.WriteLine("Система умного полива инициализирована, Здраствтуйте");
  }

  // Приватный конструктор

  public static GardenController Instance
  {
    get
    {
      lock (_lock)
      {
        if (_instance == null)
        {
          _instance = new GardenController();
        }
        return _instance;
      }
    }
  }
  // сюда: добавить, удалить, включить, выключить, список устройств
  public void Add(IGardenDevice _devices)
  {
    // добавить, переписать в норм вид
    _devices.Add(device);
    System.Console.WriteLine("Устройство {0} было добавлено", device.GetName());
  }
  public void Remove(IGardenDevice _devices)
  {
    // аналогично с добавить
    _devices.Remove(device);
    System.Console.WriteLine("Устройство {0} было удалено", device.GetName());
  }
  public void Get(IGardenDevice _devices)
  {
    foreach (var item in _devices)
    {
      System.Console.WriteLine(item);
    }
  }
  public void TurnOn(

  )
  {
    _devices.Remove(device);
    System.Console.WriteLine("Устройство {0} было удалено", device.GetName());
  }
  public void SomeBusinessLogic()
  {
    // Логика одиночки
  }
}

