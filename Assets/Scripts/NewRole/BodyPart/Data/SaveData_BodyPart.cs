using System.Collections.Generic;
using Equipment;
using UnityEngine;

namespace NewRole {
    public class SaveData_BodyPart {
        public bool                            IsDisability;
        public SaveData_Equipment              SaveDataEquipment;
        public List<SaveData_RoleValueChanger> AllRoleValueChanger = new List<SaveData_RoleValueChanger>();

        [SerializeField]
        private string AssetDataPath;
        public AssetData_BodyPart AssetData => Resources.Load<AssetData_BodyPart>(AssetDataPath);

        public SaveData_BodyPart() { }

        public SaveData_BodyPart(AssetData_BodyPart assetData) {
            AssetDataPath = assetData.ResourcePath;

            if (assetData.DefaultEquipment != null) {
                SaveDataEquipment = new SaveData_Equipment(assetData.DefaultEquipment);
            }
            
            foreach (var disabilityRoleValueChanger in assetData.AllDisabilityRoleValueChangers) {
                AllRoleValueChanger.Add(disabilityRoleValueChanger.Copy());
            }
        }
    }
}