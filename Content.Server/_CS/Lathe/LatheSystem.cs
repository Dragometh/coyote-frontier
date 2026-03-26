using Content.Shared.Lathe;

namespace Content.Server.Lathe
{
    public sealed partial class LatheSystem
    {
        public delegate void GetMaterialAmountDelegate(EntityUid uid, LatheComponent component, string material, ref int amount);
        public delegate void DeductMaterialDelegate(EntityUid uid, LatheComponent component, string material, ref int amount);
        public delegate void GetBufferAmountDelegate(EntityUid uid, LatheComponent component, ref int? bufferAmount);

        public event GetMaterialAmountDelegate? OnGetMaterialAmount;
        public event DeductMaterialDelegate? OnDeductMaterial;
        public event GetBufferAmountDelegate? OnGetBufferAmount;

    }
}
