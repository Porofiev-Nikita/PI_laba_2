using System.Security.Cryptography.X509Certificates;

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
  public void AddDevice(IGardenDevice device)
  {
    // добавить, переписать в норм вид
    if (device == null) System.Console.WriteLine("Нет значения");
    _devices.Add(device);
  }
  public void Remove(IGardenDevice device)
  {
    // аналогично с добавить
    if (device != null)
    {
      _devices.Remove(device);
      System.Console.WriteLine("Было удалено устройство: {0}", device.GetName());
    }
    else System.Console.WriteLine("Ошибка удаления устройства");
  }
  public IGardenDevice GetDevice(string name) => _devices.FirstOrDefault(device => device.GetName() == name);

  public void TurnOn(string name)
  {
    var Name = GetDevice(name);
    if (Name != null)
    {
      Name.TurnOn();
      System.Console.WriteLine("Устройство {0}, включено", Name);
    }
    else System.Console.WriteLine("Устройство не удалось включить или оно не найдено");
  }
  public void TurnOff(string name)
  {
    var Name = GetDevice(name);
    if (Name != null)
    {
      Name.TurnOff();
      System.Console.WriteLine("Устройство {0}, выключено", Name);
    }
    else System.Console.WriteLine("Устройство не удалось выключить или оно не найдено");

  }
  // все устройства?
  public void AllDevices()
  {
    System.Console.WriteLine("Все устройства:");
    foreach (var item in _devices)
    {
      System.Console.WriteLine(item.GetInfo());
    }
  }
  public void SomeBusinessLogic()
  {
    // Логика одиночки
  }
}

