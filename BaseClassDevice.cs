public abstract class GardenDeviceBase : IGardenDevice
{
  public string? Name { get; set; }
  public StatusDevices Status { get; set; } = StatusDevices.Off;
  public Dictionary<string, object> Configuration { get; set; } = new();

  // пускай наследникам передается с инкапсуляцией 
  protected GardenDeviceBase(string name) => Name = name;

  public abstract void Configure(Dictionary<string, object> parameters);

  public abstract string GetInfo();


  public string GetName() => Name;


  public StatusDevices GetStatus() => Status;


  public virtual void TurnOff() => Status = StatusDevices.Off;


  public virtual void TurnOn() => Status = StatusDevices.On;

}