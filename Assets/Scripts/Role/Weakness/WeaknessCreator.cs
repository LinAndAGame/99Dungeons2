using System;

namespace Role {
    public static class WeaknessCreator {
        public static SystemData_BaseWeakness CreateWeakness(RoleCtrl roleCtrl, SaveData_Weakness saveData) {
            switch (saveData.AssetData.WeaknessType) {
                case WeaknessTypeEnum.TotalDamage:
                    return new Weakness_TotalDamage(roleCtrl, saveData);
                case WeaknessTypeEnum.BeHitTimeOneRound:
                    return new Weakness_BeHitOneRound(roleCtrl, saveData);
                case WeaknessTypeEnum.FireBrand:
                    return new Weakness_FireBrand(roleCtrl, saveData);
                case WeaknessTypeEnum.PowerBrand:
                    return new Weakness_PowerBrand(roleCtrl, saveData);
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            return null;
        }
    }
}