
public class IrrigationSystem : GardenDeviceBase
{
  // сделать табло выбора задержки полива
  public int Duration { get; set; } = 5;
  public string Area { get; private set; } = "Не выбрано";
  public IrrigationSystem(string name) : base(name)
  {
  }

  public override void Configure(Dictionary<string, object> parameters)
  {
    if (parameters.TryGetValue("Задержка", out var duration)) Duration = (int)duration;
    if (parameters.TryGetValue("Область", out var area)) Area = area.ToString();

    Configuration = parameters;
  }

  public override string GetInfo() => $"Система полива, Статус: {Status}, Область полива: {Area}, Полив с задержкой в: {Duration} минут";

}