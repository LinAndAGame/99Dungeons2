using System.Collections.Generic;
using MyGameExpand;
using NewRole;
using RandomValue;
using RandomValue.RandomBag;
using RandomValue.RandomEffect;
using UnityEngine;

namespace Card {
    public class RuntimeData_Card {
        public bool IsTempCard;

        public RuntimeData_BaseCardSelectObject RuntimeDataBaseCardSelectObject;
        public BaseRuntimeData_CardEffect       MainCardEffect;
        public List<BaseRuntimeData_CardEffect> AllAdditionalCardEffects = new List<BaseRuntimeData_CardEffect>();
        // TODO : 换成其他的固定RoleValue类
        public List<RuntimeData_RoleValue>             AllRoleValues         = new List<RuntimeData_RoleValue>();
        public List<RuntimeData_BaseRandomValueEffect> AllRandomValueEffects = new List<RuntimeData_BaseRandomValueEffect>();

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
            
            foreach (SaveData_RoleValue saveDataAllRoleValue in SaveData.AllRoleValues) {
                AllRoleValues.Add(new RuntimeData_RoleValue(saveDataAllRoleValue));
            }
            
            foreach (SaveData_BaseRandomValueEffect saveDataBaseRandomValueEffect in SaveData.AllRandomValueEffects) {
                AllRandomValueEffects.Add(RandomValueFactory.GetRuntimeData(saveDataBaseRandomValueEffect));
            }
        }

        public void CreateRandomBag() {
            _RandomBag = RandomBagFactory.GetRandomBag();
        }

        public void AddRandomValueEffect() {
            int count         = Mathf.Min(_RandomBag.AllNoMustFailureValues.Count, SaveData.AllRandomValueEffects.Count);
            var addEffectList = _RandomBag.AllNoMustFailureValues.GetRandomList(count);
            for (int i = 0; i < addEffectList.Count; i++) {
                RandomBag_Value randomBagValue = addEffectList[i];
                if (randomBagValue.IsMustFailure) {
                    continue;
                }
                randomBagValue.AllRandomValueEffects.Add(RandomValueFactory.GetRuntimeData(SaveData.AllRandomValueEffects[i]));
            }
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