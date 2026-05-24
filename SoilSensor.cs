// датчик почва
public class SoilSensor : GardenDeviceBase
{
  public double PH { get; set; } = 7.0;
  public double SaltContent { get; set; } = 20.0;

  public SoilSensor(string name) : base(name)
  {
  }

  // придумать параметры
  public override void Configure(Dictionary<string, object> parameters)
  {
    if (parameters.TryGetValue("Кислотность", out var ph)) PH = Convert.ToDouble(ph);
    if (parameters.TryGetValue("Соленость", out var salt)) SaltContent = Convert.ToDouble(salt);

    Configuration = parameters;
  }

  public override string GetInfo() => $"Система датчиков почвы, Статус: {Status}, Степень кислотности: {PH}, Уровень соли: {SaltContent}";

}
