using System.Collections.Generic;
using BattleScene.RandomBag;
using NewRole;

namespace Card {
    public class RuntimeData_Card {
        public bool IsTempCard;

        public RuntimeData_BaseCardSelectObject RuntimeDataBaseCardSelectObject;
        public BaseRuntimeData_CardEffect       MainCardEffect;
        public List<BaseRuntimeData_CardEffect> AllAdditionalCardEffects = new List<BaseRuntimeData_CardEffect>();
        
        private RuntimeData_RandomBag _RandomBag;
        public  RuntimeData_RandomBag RandomBag => _RandomBag;
        
        public  RuntimeData_Role      RuntimeDataRole { get; private set; }
        public  SaveData_Card         SaveData        { get; private set; }
        
        public RuntimeData_Card(RuntimeData_Role runtimeDataRole, SaveData_Card saveData) {
            RuntimeDataRole = runtimeDataRole;
            SaveData        = saveData;
            MainCardEffect  = CardEffectFactory.GetRuntimeData(RuntimeDataRole, saveData.MainCardEffect);
            foreach (var saveDataAllAdditionalCardEffect in saveData.AllAdditionalCardEffects) {
                AllAdditionalCardEffects.Add(CardEffectFactory.GetRuntimeData(RuntimeDataRole, saveDataAllAdditionalCardEffect));
            }

            RuntimeDataBaseCardSelectObject = CardSelectObjectFactory.GetRuntimeData(SaveData.AssetData.AssetDataCardSelectObject);
        }

        public void CreateRandomBag() {
            _RandomBag = RandomBagFactory.GetRandomBag();
        }

        public RandomBag_Result GetRandomBagResult() {
            var result = _RandomBag.Result;
            RandomBagFactory.ReleaseRandomBag(_RandomBag);
            return result;
        }
        
        public List<RoleCtrl> GetSelectRoles() {
            return RuntimeDataBaseCardSelectObject.GetAllAllowedSelectObjects(RuntimeDataRole);
        }

        public void RunEffect(int value, params object[] otherDatas) {
            MainCardEffect.RunEffect(RuntimeDataRole, value, otherDatas);
        }

        public RuntimeData_RoleValue GetUsedRoleValue() {
            var roleValueType = MainCardEffect.SaveData.AssetData.RoleValueType;
            return RuntimeDataRole.RoleValueCollectionInfo.GetRoleValue(roleValueType);
        }
    }
}