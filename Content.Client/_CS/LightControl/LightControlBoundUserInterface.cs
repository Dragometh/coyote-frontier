using Content.Shared.Medical.CrewMonitoring;
using Robust.Client.UserInterface;

namespace Content.Client._CS.LightControl;

public sealed class LightControlBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private LightControlWindow? _menu;

    public LightControlBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();

        _menu = this.CreateWindow<LightControlWindow>();
        _menu.Initialize();
    }

    // protected override void UpdateState(BoundUserInterfaceState state)
    // {
    //     base.UpdateState(state);

    //     switch (state)
    //     {
    //         case LightControlState st:
    //             break;
    //     }
    // }
}
