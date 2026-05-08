using Content.Shared.Medical.SuitSensor;
using Robust.Shared.Serialization;

namespace Content.Shared._CS.LightControl;

[Serializable, NetSerializable]
public enum LightControlUIKey
{
    Key
}

[Serializable, NetSerializable]
public sealed class LightControlState : BoundUserInterfaceState
{

    public LightControlState()
    {
    }
}
