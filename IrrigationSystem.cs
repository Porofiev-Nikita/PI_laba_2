
public class IrrigationSystem : GardenDeviceBase
{
  // сделать табло выбора задержки полива
  public int Duration { get; set; } = 5;
  public IrrigationSystem(string name) : base(name)
  {
  }

  public override void Configure(Dictionary<string, object> parameters)
  {
    if (parameters.TryGetValue("Задержка", out var duration)) Duration = (int)duration;
    Configuration = parameters;
    throw new NotImplementedException();
  }

  public override string GetInfo() => $"Система полива, Статус: {Status}, Полив с задержкой в: {Duration} минут";

}