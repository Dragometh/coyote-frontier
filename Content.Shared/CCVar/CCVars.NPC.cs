using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
    public static readonly CVarDef<int> NPCMaxUpdates =
        CVarDef.Create("npc.max_updates", 96);

    public static readonly CVarDef<bool> NPCEnabled = CVarDef.Create("npc.enabled", true);

    /// <summary>
    ///     Should NPCs pathfind when steering. For debug purposes.
    /// </summary>
    public static readonly CVarDef<bool> NPCPathfinding = CVarDef.Create("npc.pathfinding", true);

    /// <summary>
    ///     If true, shared-path reuse is restricted to NPCs actively chasing a combat target.
    /// </summary>
    public static readonly CVarDef<bool> NPCPathfindingCombatOnly =
        CVarDef.Create("npc.pathfinding_combat_only", true);

    /// <summary>
    ///     If true, NPC steering can reuse nearby NPC paths when destinations are similar.
    /// </summary>
    public static readonly CVarDef<bool> NPCPathShareEnabled =
        CVarDef.Create("npc.path_share_enabled", true);

    /// <summary>
    ///     Max distance between NPCs to allow path reuse.
    /// </summary>
    public static readonly CVarDef<float> NPCPathShareRadius =
        CVarDef.Create("npc.path_share_radius", 8f);

    /// <summary>
    ///     Max distance from chase target to allow joining a shared chase-path group.
    /// </summary>
    public static readonly CVarDef<float> NPCPathShareActivationRange =
        CVarDef.Create("npc.path_share_activation_range", 20f);

    /// <summary>
    ///     Max distance between destinations to allow path reuse.
    /// </summary>
    public static readonly CVarDef<float> NPCPathShareTargetTolerance =
        CVarDef.Create("npc.path_share_target_tolerance", 3f);

    /// <summary>
    ///     Chance that an NPC temporarily breaks from shared-path chaining and computes its own path.
    /// </summary>
    public static readonly CVarDef<float> NPCPathShareBreakawayChance =
        CVarDef.Create("npc.path_share_breakaway_chance", 0.10f);

    /// <summary>
    ///     How long (seconds) a breakaway NPC keeps using independent pathfinding before rejoining chain reuse.
    /// </summary>
    public static readonly CVarDef<float> NPCPathShareBreakawayDuration =
        CVarDef.Create("npc.path_share_breakaway_duration", 1.25f);

    /// <summary>
    ///     If direct target distance is less than this fraction of shared-entry distance,
    ///     prefer independent pathing over shared chaining.
    /// </summary>
    public static readonly CVarDef<float> NPCPathShareDirectOverrideRatio =
        CVarDef.Create("npc.path_share_direct_override_ratio", 0.70f);

}
