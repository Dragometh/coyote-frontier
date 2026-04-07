using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;
using Content.Server._Coyote.Helpers;
using Content.Shared.SSDIndicator;
using Content.Shared.StatusIcon.Components;
using Content.Shared._Coyote.AphroLacedVisibility;
using Content.Shared.Chemistry.Components;
using Content.Shared.Examine;

namespace Content.Server._Coyote.AphroLacedVisibility;

/// <summary>
/// System that shows visual feedback to any container that is injected with a aphrodisiac.
/// </summary>
public sealed class AphroLacedVisibilitySystem : EntitySystem
{
    [Dependency] private readonly SharedSolutionContainerSystem _solutionContainerSystem = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    private ServerAphrodisiacChecker _helper = new();

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<AphroLacedVisibilityComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<AphroLacedVisibilityComponent, SolutionContainerChangedEvent>(OnSolutionChange);
        SubscribeLocalEvent<AphroLacedVisibilityComponent, ExaminedEvent>(OnExamine);
    }

    public void OnMapInit(Entity<AphroLacedVisibilityComponent> entity, ref MapInitEvent args)
    {
        EnsureComp<StatusIconComponent>(entity);
        CheckForAphrodisiacs(entity);
    }

    public void OnSolutionChange(Entity<AphroLacedVisibilityComponent> entity, ref SolutionContainerChangedEvent args)
    {
        if (args.Solution != null)
            CheckForAphrodisiacs(entity, args.Solution);
        else
            CheckForAphrodisiacs(entity);
    }

    private void OnExamine(EntityUid uid, AphroLacedVisibilityComponent comp, ref ExaminedEvent args)
    {
        if (comp.Laced)
            args.PushMarkup(Loc.GetString("container-laced-with-aphrodisiacs"));
    }

    public void CheckForAphrodisiacs(Entity<AphroLacedVisibilityComponent> entity)
    {
        if (!EntityManager.HasComponent<SolutionContainerManagerComponent>(entity))
            return;

        if (_solutionContainerSystem.TryGetSolution(entity.Owner, entity.Comp.Solution, out _, out var solution))
        {
            CheckForAphrodisiacs(entity, solution);
        }
    }

    // Override to skip solution TryGet.
    private void CheckForAphrodisiacs(Entity<AphroLacedVisibilityComponent> entity, Solution solution)
    {
        var laced = _helper.CheckForAphrodisiacs(_prototypeManager, solution);
        entity.Comp.Laced = laced;
    }
}
