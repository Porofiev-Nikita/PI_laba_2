// регулировка ntvgthfnehs
using System.Dynamic;
class ClimateControl : GardenDeviceBase
{
  public double CurrentTempererature { get; set; } = 26.0;

  public ClimateControl(string name) : base(name)
  {
  }

  // тут будут параметры
  // аналогично прошлым перезапись
  public override void Configure(Dictionary<string, object> parameters)
  {
    if (parameters.TryGetValue("Температура", out var temperature)) CurrentTempererature = Convert.ToDouble(temperature);
    Configuration = parameters;
    throw new NotImplementedException();
  }

  // гет инф
  public override string GetInfo() => $"Система климат контроля, Статус: {Status}, Температура: {CurrentTempererature} градусов Цельсия";

}




