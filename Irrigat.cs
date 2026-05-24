
public class IrrigationSystem : IGardenDevice
{
  public string? name;
  public StatusDevices status;
  public int Flow;
  public int TimeDuration;
  public IrrigationSystem()
  {
    name = "Система полива";
    status = StatusDevices.Off;
    Flow = 50;
    TimeDuration = 50;
  }
  public void Configure(Dictionary<string, object> parameters)
  {

    // throw new NotImplementedException();
  }

  public string GetInfo() => System.Console.WriteLine(name, status, Flow, TimeDuration);


  public string GetName() => name;


  public StatusDevices GetStatus() => status;


  public void TurnOff()
  {
    // а если устройство на обслуживаании?
    status - StatusDevices.Off;

    // throw new NotImplementedException();
  }

  public void TurnOn()
  {
    // а если устройство на обслуживании?
    status - StatusDevices.On;
    // throw new NotImplementedException();
  }


}