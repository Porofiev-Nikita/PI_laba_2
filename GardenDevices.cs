
public interface IGardenDevice
{
  string GetName();
  StatusDevices GetStatus();
  void TurnOn();
  void TurnOff();
  void Configure(Dictionary<string, object> parameters);
  string GetInfo();
}

