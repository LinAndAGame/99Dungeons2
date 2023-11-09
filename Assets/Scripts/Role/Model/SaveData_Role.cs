﻿using System;
using System.Collections.Generic;
using Item;
using MyGameUtility;
using Role.Action;
using Role.RoleItemSlot;
using Role.RoleItemSlotProvider;
using Role.UnlockAction;
using UnityEngine;
using Utility;

namespace Role {
    [Serializable]
    public class SaveData_Role {
        [SerializeField]
        private string AssetDataName;
        public  string RoleName;
        // TODO : 此属性待删除，Role本身没有是否为玩家的概念
        public bool             IsPlayer;
        public float            Damage = 1;
        public MinMaxValueFloat Hp;
        
        public List<SaveData_RoleIdentity>              AllRoleIdentities             = new List<SaveData_RoleIdentity>();
        public List<Guid>                               AllActiveRoleIdentityGuids    = new List<Guid>();
        public List<SaveData_Item>                      AllItemDatas                  = new List<SaveData_Item>();
        public List<SaveData_Weakness>                  AllWeaknessDatas              = new List<SaveData_Weakness>();
        public List<SaveData_RoleAction>                AllRoleActionDatas            = new List<SaveData_RoleAction>();
        public List<SaveData_RoleUnlock>                AllRoleUnlockDatas            = new List<SaveData_RoleUnlock>();
        public List<Guid>                               AllActiveRoleUnlockDataGuids  = new List<Guid>();
        public List<SaveData_RoleItemSlotProvider> AllRoleEquipmentSlotProviders = new List<SaveData_RoleItemSlotProvider>();
        
        public AssetData_Role AssetData => Resources.Load<AssetData_Role>($"{GameCommonAsset.I.AssetFolderInfo_Role}{AssetDataName}");

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

        public SaveData_Role() { }

        public SaveData_Role(AssetData_Role assetDataRole, bool isPlayer) {
            AssetDataName = assetDataRole.name;
            RoleName      = assetDataRole.RoleName;
            IsPlayer      = isPlayer;
            
            Damage = AssetData.Damage;
            Hp     = new MinMaxValueFloat(0, AssetData.Hp, AssetData.Hp);
            AllWeaknessDatas.AddRange(AssetData.AllWeaknessDatas);
            
            foreach (BaseRoleIdentity possibleRoleIdentity in AssetData.AllPossibleRoleIdentities) {
                var saveDataRoleIdentity = possibleRoleIdentity.GetSaveDataRoleIdentity();
                AllRoleIdentities.Add(saveDataRoleIdentity);
                AllRoleUnlockDatas.AddRange(saveDataRoleIdentity.GetInitUnlockDatas());
            }
            
            foreach (AssetData_RoleAction defaultRoleAction in AssetData.AllDefaultRoleActions) {
                AllRoleActionDatas.Add(defaultRoleAction.GetSaveData());
            }
            
            foreach (var defaultItem in AssetData.AllDefaultItems) {
                AllItemDatas.Add(defaultItem.GetSaveData());
            }
            
            foreach (var roleEquipmentSlot in AssetData.AllRoleEquipmentSlotProviders) {
                AllRoleEquipmentSlotProviders.Add(roleEquipmentSlot.GetSaveData());
            }

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
            if (itemSlot.EquippedItem == null) {
                Debug.LogException(new Exception("装备槽中没有物品，不能将物品卸载！"));
                return;
            }
            
            AllItemDatas.Add(itemSlot.EquippedItem);
            itemSlot.EquippedItem = null;
        }
    }
}