public static class FactoryDevices
{
  public static IGardenDevice CreateDevice(string deviceType, string name)
  {
    return deviceType.ToLower() switch
    {
      "irrigation" => new IrrigationSystem(name),
      "lighting" => new LightningSystem(name),
      "climate" => new ClimateControl(name),
      "soilsensor" => new SoilSensor(name),
      _ => throw new NotImplementedException("Неизвестная ошибка"),
    };
  }
}