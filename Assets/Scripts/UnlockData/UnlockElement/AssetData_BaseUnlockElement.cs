using System.Collections.Generic;
using Dungeon.EncounterEnemy;
using MyGameUtility;
using Role;

namespace UnlockData.UnlockElement {
    public abstract class AssetData_BaseUnlockElement : BaseAssetData {
        public abstract List<string> GetUnlockNames();
        public virtual  void         AddToRole(SaveData_Role saveDataRole) { }
    }
}