using System;
using System.Collections.Generic;
using Dungeon.EncounterEnemy;
using NewRole;

namespace Card.ClassLibrary {
    public class RuntimeData_NormalCardSelectObject : RuntimeData_BaseCardSelectObject {
        public RuntimeData_NormalCardSelectObject(AssetData_CardSelectObject assetData) : base(assetData) { }
        
        public override List<RoleCtrl> GetAllAllowedSelectObjects(RuntimeData_Role runtimeDataRole) {
                switch (AssetData.CardSelectObjectType) {
                    case CardSelectObjectTypeEnum.NoSelect:
                        return new List<RoleCtrl>();
                    case CardSelectObjectTypeEnum.SelectFriends:
                        return DungeonEvent_EncounterEnemyCtrl.I.GetAllFriendRoles(runtimeDataRole.RoleCtrlOwner);
                    case CardSelectObjectTypeEnum.SelectEnemies:
                        return DungeonEvent_EncounterEnemyCtrl.I.GetAllOtherRoles(runtimeDataRole.RoleCtrlOwner);
                    case CardSelectObjectTypeEnum.SelectAll:
                        return DungeonEvent_EncounterEnemyCtrl.I.AllRoles;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return null;
        }
    }
}