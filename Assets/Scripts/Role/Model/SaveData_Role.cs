using System;
using System.Collections.Generic;
using Item;
using MyGameExpand;
using MyGameUtility;
using Role.Action;
using Role.Brand;
using Role.Characterization;
using Role.RoleBody;
using Role.UnlockAction;
using UnityEngine;
using UnlockData.UnlockProcess;
using UnlockData.UnlockSystem;
using Utility;

namespace Role {
    [Serializable]
    public class SaveData_Role {
        [SerializeField]
        private string AssetDataPath;
        public  string RoleName;
        public bool             IsPlayer;
        public MinMaxValueFloat Hp;
        
        public List<SaveData_RoleIdentity>     AllRoleIdentities            = new List<SaveData_RoleIdentity>();
        public List<Guid>                      AllActiveRoleIdentityGuids   = new List<Guid>();
        public List<SaveData_Item>             AllItemDatas                 = new List<SaveData_Item>();
        public List<SaveData_RoleAction>       AllRoleActionDatas           = new List<SaveData_RoleAction>();
        public List<SaveData_RoleAction>       AllLearnedRoleActions        = new List<SaveData_RoleAction>();
        public List<SaveData_RoleUnlock>       AllRoleUnlockDatas           = new List<SaveData_RoleUnlock>();
        public List<Guid>                      AllActiveRoleUnlockDataGuids = new List<Guid>();
        public List<SaveData_Characterization> AllRoleCharacterizations     = new List<SaveData_Characterization>();
        public SaveData_RoleBody               RoleBody;
        public SaveData_UnlockSystem           UnlockSystem;
        public List<SaveData_Brand>            AllRoleBrands    = new List<SaveData_Brand>();

        public List<SaveData_Weakness> AllWeaknessDatas {
            get {
                List<SaveData_Weakness> result = new List<SaveData_Weakness>();
                foreach (SaveData_Brand saveDataBrand in AllRoleBrands) {
                    result.Add(saveDataBrand.SaveDataWeakness);
                }
                foreach (SaveData_RoleBodySlot saveDataRoleBodySlot in RoleBody.AllBodySlots) {
                    result.AddRange(saveDataRoleBodySlot.SaveDataRoleBodyPart.AllWeaknesses);
                }

                return result;
            }
        }

        public AssetData_BaseRole AssetData => Resources.Load<AssetData_BaseRole>(AssetDataPath);

        public List<SaveData_RoleIdentity> AllActiveRoleIdentities {
            get {
                List<SaveData_RoleIdentity> result = new List<SaveData_RoleIdentity>();
                foreach (Guid activeRoleIdentityGuid in AllActiveRoleIdentityGuids) {
                    result.Add(AllRoleIdentities.Find(data=>data.UniqueId == activeRoleIdentityGuid));
                }

                return result;
            }
        }
        
        public List<SaveData_RoleUnlock> AllActiveRoleUnlockDatas {
            get {
                List<SaveData_RoleUnlock> result = new List<SaveData_RoleUnlock>();
                foreach (var activeRoleUnlockDataGuid in AllActiveRoleUnlockDataGuids) {
                    result.Add(AllRoleUnlockDatas.Find(data=>data.UniqueId == activeRoleUnlockDataGuid));
                }

                return result;
            }
        }

        public List<SaveData_Item> AllEquippedItems {
            get {
                List<SaveData_Item> result = new List<SaveData_Item>();
                foreach (SaveData_RoleBodySlot saveDataRoleBodySlot in RoleBody.AllBodySlots) {
                    foreach (SaveData_RoleItemSlot saveDataRoleItemSlot in saveDataRoleBodySlot.SaveDataRoleBodyPart.AllRoleItemSlots) {
                        if (saveDataRoleItemSlot.EquippedItem == null) {
                            continue;
                        }

                        result.Add(saveDataRoleItemSlot.EquippedItem);
                    }
                }

                return result;
            }
        }

        public SaveData_Role() { }

        public SaveData_Role(AssetData_BaseRole assetDataRole, bool isPlayer) {
            AssetDataPath = assetDataRole.ResourcePath;
            RoleName      = assetDataRole.RoleName;
            IsPlayer      = isPlayer;
            
            Hp     = new MinMaxValueFloat(0, AssetData.Hp, AssetData.Hp);
            
            foreach (AssetData_BaseRoleIdentity possibleRoleIdentity in AssetData.AllPossibleRoleIdentities) {
                var saveDataRoleIdentity = possibleRoleIdentity.GetSaveDataRoleIdentity();
                AllRoleIdentities.Add(saveDataRoleIdentity);
                AllRoleUnlockDatas.AddRange(saveDataRoleIdentity.GetInitUnlockDatas());
            }
            
            foreach (var assetDataAllCharacterization in AssetData.AllCharacterizations) {
                AllRoleCharacterizations.Add(new SaveData_Characterization(assetDataAllCharacterization));
            }
            
            foreach (AssetData_RoleAction defaultRoleAction in AssetData.AllDefaultRoleActions) {
                AllRoleActionDatas.Add(defaultRoleAction.GetSaveData());
            }
            
            foreach (var defaultItem in AssetData.AllDefaultItems) {
                AllItemDatas.Add(defaultItem.GetSaveData());
            }
            
            foreach (AssetData_Brand assetDataAllRoleBrand in GameCommonAsset.I.AllRoleBrands.GetRandomList(GameCommonAsset.I.PlayerRoleBrandCount)) {
                AllRoleBrands.Add(new SaveData_Brand(assetDataAllRoleBrand));
            }

            UnlockSystem = new SaveData_UnlockSystem(AssetData.AllUnlockProcesses);
            RoleBody     = new SaveData_RoleBody(AssetData.RoleBody);

            RefreshActiveRoleIdentities();
            RefreshActiveRoleUnlockDatas();
        }

        public void RefreshActiveRoleIdentities() {
            AllActiveRoleIdentityGuids.Clear();
            foreach (SaveData_RoleIdentity saveDataRoleIdentity in AllRoleIdentities) {
                if (saveDataRoleIdentity.AssetData.IsMeetIdentityRequirement(this)) {
                    AllActiveRoleIdentityGuids.Add(saveDataRoleIdentity.UniqueId);
                }
            }
        }

        public void RefreshActiveRoleUnlockDatas() {
            AllActiveRoleUnlockDataGuids.Clear();
            foreach (SaveData_RoleIdentity activeRoleIdentity in AllActiveRoleIdentities) {
                AllActiveRoleIdentityGuids.AddRange(activeRoleIdentity.AllUnlockDataGuids);
            }
        }

        public void UnEquipItem(SaveData_RoleItemSlot itemSlot) {
            if (itemSlot.OverrideItem == null) {
                Debug.LogException(new Exception("装备槽中没有物品，不能将物品卸载！"));
                return;
            }
            
            AllItemDatas.Add(itemSlot.OverrideItem);
            itemSlot.OverrideItem = null;
        }
    }
}