
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Chemistry.EntitySystems;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;

namespace Content.Shared.Coyote.Helpers;

public struct AphrodisiacChecker
{
    private readonly string _aphrodisiacGroup = "Aphrodisiac";
    private readonly string _aphrodisiacDrinkGroup = "AphrodisiacDrink";

    public AphrodisiacChecker() { }
    public bool CheckForAphrodisiacs(IPrototypeManager prototypeManager, Solution solution)
    {
        foreach (var (reagent, _) in solution.Contents)
        {
            if (prototypeManager.Index<ReagentPrototype>(reagent.Prototype).Group == _aphrodisiacGroup ||
                prototypeManager.Index<ReagentPrototype>(reagent.Prototype).Group == _aphrodisiacDrinkGroup)
            {
                return true;
            }
        }

        return false;
    }
}
