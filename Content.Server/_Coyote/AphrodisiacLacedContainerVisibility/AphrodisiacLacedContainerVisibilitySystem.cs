using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;
using Content.Shared.Coyote.Helpers;

namespace Content.Server.Coyote.AphrodisiacLacedContainerVisibility;

/// <summary>
/// System that shows visual feedback to any container that is injected with a aphrodisiac.
/// </summary>
public sealed class AphrodisiacLacedContainerVisibilitySystem : EntitySystem
{
    [Dependency] private readonly SharedSolutionContainerSystem _solutionContainerSystem = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    private AphrodisiacChecker _helper = new();

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<AphrodisiacLacedContainerVisibilityComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<AphrodisiacLacedContainerVisibilityComponent, SolutionContainerChangedEvent>(OnSolutionChange);
    }

    public void OnMapInit(Entity<AphrodisiacLacedContainerVisibilityComponent> entity, ref MapInitEvent args)
    {
        // TODO: Add check for preference here;
        if (!entity.Comp.Laced)
            CheckForAphrodisiacs(entity); // Checks for horny juices if it's not tagged as laced.
        else
            UpdateVisual(true); // Just update visual if it is tagged as laced.
    }

    public void OnSolutionChange(Entity<AphrodisiacLacedContainerVisibilityComponent> entity, ref SolutionContainerChangedEvent args)
    {
        // TODO: Add check for preference here;
        CheckForAphrodisiacs(entity);
    }

    public void CheckForAphrodisiacs(Entity<AphrodisiacLacedContainerVisibilityComponent> entity)
    {
        if (!EntityManager.HasComponent<SolutionContainerManagerComponent>(entity))
            return;

        if (_solutionContainerSystem.TryGetSolution(entity.Owner, entity.Comp.Solution, out _, out var solution))
        {
            entity.Comp.Laced = _helper.CheckForAphrodisiacs(_prototypeManager, solution);
            // Update visuals with the final boolean value of the component
            UpdateVisual(entity.Comp.Laced);
        }
    }

    public void UpdateVisual(bool laced)
    {
        // TODO: Visual logic
    }
}
