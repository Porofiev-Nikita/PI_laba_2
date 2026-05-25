// регулировка света
public class LightningSystem : GardenDeviceBase
{
  public int Illumination { get; set; } = 100; //допустим тут 100 процентов освященности терриории
  public LightningSystem(string name) : base(name)
  {
  }

  // тут будут параметры
  public override void Configure(Dictionary<string, object> parameters)
  {
    if (parameters.TryGetValue("Освещенность", out var illumination)) Illumination = (int)illumination;
    Configuration = parameters;
    throw new NotImplementedException();
  }

  // тут перезапись конфигурации/ override
  public override string GetInfo() => $"Система освящения, Статус: {Status}, Процесс освященности территории: {Illumination} минут";
}


