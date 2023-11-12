using System.Collections.Generic;
using Dungeon.EncounterEnemy;
using MyGameUtility;

namespace UnlockData.UnlockElement {
    public abstract class AssetData_BaseUnlockElement : BaseAssetData {
        public abstract List<string> GetUnlockNames();
    }
}