using System;
using MyGameUtility;
using NewRole;

namespace Buff {
    public static class BuffFactory {
        public static BaseBuff GeyPlayerBuff(RuntimeData_Role runtimeDataRole,  AssetData_BaseBuff assetDataBaseBuff, int layer) {
            switch (assetDataBaseBuff.BuffType) {
                case BuffTypeEnum.Vertigo:
                    break;
                case BuffTypeEnum.Poison:
                    return new Buff_Poison(assetDataBaseBuff, runtimeDataRole, layer);
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
     }
}