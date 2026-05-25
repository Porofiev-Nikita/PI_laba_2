using System;
namespace project
{
  class Program
  {
    static void Main()
    {
      GardenController controller = GardenController.Instance;
      bool exit = false;
      while (!exit)
      {
        // Главное меню
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Добавить устройство");
        Console.WriteLine("2. Управлять устройствами");
        Console.WriteLine("3. Настроить автоматизацию");
        Console.WriteLine("4. Просмотреть статус системы");
        Console.WriteLine("5. Выход");
        Console.Write("Ваш выбор: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
        {
          case "1": AddDeviceMenu(controller); break;
          case "2": ManageDevicesMenu(controller); break;
          case "3": ConfigureAutomation(controller); break;
          case "4": ShowSystemStatus(controller); break;
          case "5": exit = true; break;
          default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
            break;
        }
      }
    }

    // Меню добавления устройства
    static void AddDeviceMenu(GardenController controller)
    {
      Console.WriteLine("Выберите тип устройства:");
      Console.WriteLine("1. Система полива");
      Console.WriteLine("2. Система освещения");
      Console.WriteLine("3. Система контроля климата");
      Console.WriteLine("4. Датчик почвы");
      Console.Write("Ваш выбор: ");
      string typeChoice = Console.ReadLine();

      string deviceType;
      switch (typeChoice)
      {
        case "1": deviceType = "irrigation"; break;
        case "2": deviceType = "lighting"; break;
        case "3": deviceType = "climate"; break;
        case "4": deviceType = "soilsensor"; break;
        default:
          Console.WriteLine("Неверный выбор.\n");
          return;
      }

      Console.Write("Введите название устройства: ");
      string name = Console.ReadLine();

      // Создаём устройство через фабрику
      IGardenDevice device = FactoryDevices.CreateDevice(deviceType, name);

      // Запрашиваем специфичные параметры
      Console.Write("Настроить параметры устройства? (да/нет): ");
      string ans = Console.ReadLine()?.ToLower();
      if (ans == "да" || ans == "yes" || ans == "y")
      {
        ConfigureDeviceParams(device, deviceType);
      }

      // Добавляем в контроллер
      controller.AddDevice(device);
      Logger.Log("Устройство успешно добавлено в систему.\n");
    }

    // Запрос параметров в зависимости от типа устройства
    static void ConfigureDeviceParams(IGardenDevice device, string deviceType)
    {
      var parameters = new Dictionary<string, object>();

      switch (deviceType)
      {
        case "irrigation":
          Console.WriteLine("\nВыберите область полива:");
          Console.WriteLine("1. Газон");
          Console.WriteLine("2. Грядки");
          Console.WriteLine("3. Клумбы");
          Console.WriteLine("4. Деревья");
          Console.Write("Ваш выбор: ");
          string areaChoice = Console.ReadLine();
          string area = areaChoice switch
          {
            "1" => "Газон",
            "2" => "Грядки",
            "3" => "Клумбы",
            "4" => "Деревья",
            _ => "Не выбрано"
          };
          parameters.Add("area", area);

          Console.Write("Введите интенсивность полива (л/м²): ");
          double intensity = double.Parse(Console.ReadLine());
          parameters.Add("intensity", intensity);

          Console.Write("Введите длительность полива (мин): ");
          int duration = int.Parse(Console.ReadLine());
          parameters.Add("duration", duration);
          break;

        case "lighting":
          Console.Write("Введите яркость (0-100%): ");
          int brightness = int.Parse(Console.ReadLine());
          parameters.Add("brightness", brightness);

          Console.Write("Введите цветовую температуру (K): ");
          int colorTemp = int.Parse(Console.ReadLine());
          parameters.Add("colorTemp", colorTemp);
          break;

        case "climate":
          Console.Write("Введите целевую температуру (°C): ");
          double temp = double.Parse(Console.ReadLine());
          parameters.Add("temperature", temp);

          Console.Write("Введите целевую влажность (%): ");
          double hum = double.Parse(Console.ReadLine());
          parameters.Add("humidity", hum);
          break;

        case "soilsensor":
          Console.WriteLine("Выберите тип измерения:");
          Console.WriteLine("1. Только влажность");
          Console.WriteLine("2. Влажность и температура");
          Console.WriteLine("3. Влажность, температура и pH");
          Console.Write("Ваш выбор: ");
          int measType = int.Parse(Console.ReadLine());
          parameters.Add("measurementType", measType);

          Console.Write("Введите глубину установки (см): ");
          int depth = int.Parse(Console.ReadLine());
          parameters.Add("depth", depth);
          break;
      }

      device.Configure(parameters);   // Применяем настройки
    }

    // Меню управления устройствами
    static void ManageDevicesMenu(GardenController controller)
    {
      var devices = controller.AllDevices();
      if (devices.Count == 0)
      {
        Console.WriteLine("Нет добавленных устройств.\n");
        return;
      }

      Console.WriteLine("=== Управление устройствами ===");
      for (int i = 0; i < devices.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {devices[i].GetName()} ({devices[i].GetStatus()})");
      }
      Console.Write("Выберите устройство (номер): ");
      if (!int.TryParse(Console.ReadLine(), out int devIndex) || devIndex < 1 || devIndex > devices.Count)
      {
        Console.WriteLine("Неверный номер.\n");
        return;
      }

      IGardenDevice selected = devices[devIndex - 1];
      DeviceActionMenu(selected, controller);
    }

    // Подменю действий с выбранным устройством
    static void DeviceActionMenu(IGardenDevice device, GardenController controller)
    {
      bool back = false;
      while (!back)
      {
        Console.WriteLine($"\nВыберите действие для устройства \"{device.GetName()}\":");
        Console.WriteLine("1. Включить");
        Console.WriteLine("2. Выключить");
        Console.WriteLine("3. Настроить параметры");
        Console.WriteLine("4. Назад");
        Console.Write("Ваш выбор: ");
        string act = Console.ReadLine();

        switch (act)
        {
          case "1":
            Logger.Log($"Включение устройства \"{device.GetName()}\"...");
            device.TurnOn();
            Logger.Log($"Устройство \"{device.GetName()}\" включено.");
            break;
          case "2":
            Logger.Log($"Выключение устройства \"{device.GetName()}\"...");
            device.TurnOff();
            Logger.Log($"Устройство \"{device.GetName()}\" выключено.");
            break;
          case "3":
            // Повторно запрашиваем параметры (тип можно узнать через имя класса)
            string devType = device.GetType().Name switch
            {
              "IrrigationSystem" => "irrigation",
              "LightingSystem" => "lighting",
              "ClimateControl" => "climate",
              "SoilSensor" => "soilsensor",
              _ => ""
            };
            if (!string.IsNullOrEmpty(devType))
            {
              Console.Write("Настроить параметры заново? (да/нет): ");
              if (Console.ReadLine()?.ToLower() == "да")
                ConfigureDeviceParams(device, devType);
            }
            break;
          case "4":
            back = true;
            break;
          default:
            Console.WriteLine("Неверный выбор.");
            break;
        }
      }
    }

    // Заглушка для настройки автоматизации
    static void ConfigureAutomation(GardenController controller)
    {
      Logger.Log("Настройка автоматизации пока не реализована.\n");
    }

    // Отображение общего статуса системы
    static void ShowSystemStatus(GardenController controller)
    {
      var devices = controller.AllDevices();
      Console.WriteLine("=== Статус системы ===");
      Console.WriteLine($"Активные устройства: {devices.Count(d => d.GetStatus() == StatusDevices.On)}/{devices.Count}");
      Console.WriteLine($"Дата и время: {DateTime.Now:dd.MM.yyyy HH:mm:ss}\n");

      for (int i = 0; i < devices.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {devices[i].GetInfo()}");
      }
      Console.WriteLine(); // попыткаа удления
    }
    public static class Logger
    {
      public static void Log(string message)
      {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
      }
    }
  }
}