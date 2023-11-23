using System;
using System.Collections.Generic;
using Card.ClassLibrary;
using Dungeon.EncounterEnemy;
using NewRole;

namespace Card {
    public static class CardSelectObjectFactory {
        public static RuntimeData_BaseCardSelectObject GetRuntimeData(AssetData_CardSelectObject assetData) {
            switch (assetData.CardSelectObjectType) {
                case CardSelectObjectTypeEnum.NoSelect:
                case CardSelectObjectTypeEnum.SelectFriends:
                case CardSelectObjectTypeEnum.SelectEnemies:
                case CardSelectObjectTypeEnum.SelectAll:
                    return new RuntimeData_NormalCardSelectObject(assetData);
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
    }
}