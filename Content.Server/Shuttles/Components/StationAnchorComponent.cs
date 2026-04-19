using Content.Server.Shuttles.Systems;
using Content.Shared.DeviceLinking; // Frontier
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype; // Frontier

namespace Content.Server.Shuttles.Components;

[RegisterComponent]
[Access(typeof(StationAnchorSystem))]
public sealed partial class StationAnchorComponent : Component
{
    // Frontier: Add ports for linking
    [DataField("onPort", customTypeSerializer: typeof(PrototypeIdSerializer<SinkPortPrototype>))]
    public string OnPort = "On";

    [DataField("offPort", customTypeSerializer: typeof(PrototypeIdSerializer<SinkPortPrototype>))]
    public string OffPort = "Off";

    [DataField("togglePort", customTypeSerializer: typeof(PrototypeIdSerializer<SinkPortPrototype>))]
    public string TogglePort = "Toggle";
    // End Frontier

    [DataField("switchedOn")]
    public bool SwitchedOn { get; set; } = true;

    // Frontier: expedition duration extension
    /// <summary>
    /// When true and this anchor is active, any salvage expedition on the same map will
    /// have its end-time continuously pushed forward, effectively pausing the countdown
    /// for as long as the anchor remains powered and switched on.
    /// </summary>
    [DataField]
    public bool ExtendExpeditionDuration { get; set; } = false;
    // End Frontier: expedition duration extension
}
