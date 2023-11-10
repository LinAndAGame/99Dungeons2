using System;

namespace Role {
    public static class WeaknessCreator {
        public static SystemData_BaseWeakness CreateWeakness(RoleCtrl roleCtrl, SaveData_Weakness saveData) {
            switch (saveData.WeaknessType) {
                case WeaknessTypeEnum.TotalDamage:
                    return new Weakness_TotalDamage(roleCtrl, saveData);
                case WeaknessTypeEnum.BeHitTimeOneRound:
                    return new Weakness_BeHitOneRound(roleCtrl, saveData);
            }
            
            return null;
        }
    }
}