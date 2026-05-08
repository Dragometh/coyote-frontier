namespace Content.Server._CS.LightControl;

public sealed class LightControlSystem : EntitySystem
{
    // [Dependency] private readonly PowerCellSystem _cell = default!;
    // [Dependency] private readonly UserInterfaceSystem _uiSystem = default!;

    public override void Initialize()
    {
        base.Initialize();
        // SubscribeLocalEvent<LightControlComponent, BoundUIOpenedEvent>(OnUIOpened);
    }

    // private void OnUIOpened(EntityUid uid, LightControlComponent component, BoundUIOpenedEvent args)
    // {
    //     UpdateUserInterface(uid, component);
    // }

    // private void UpdateUserInterface(EntityUid uid, LightControlComponent? component = null)
    // {
    //     if (!Resolve(uid, ref component))
    //         return;

    //     if (!_uiSystem.IsUiOpen(uid, LightControlUIKey.Key))
    //         return;

    //     _uiSystem.SetUiState(uid, LightControlUIKey.Key, new LightControlState());
    // }
}
