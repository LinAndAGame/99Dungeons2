using System.Collections.Generic;
using Card;
using Equipment;

namespace NewRole {
    public class RuntimeData_BodyPart {
        public CustomAction<bool> OnDisabilityStateChanged = new CustomAction<bool>();

        public RuntimeData_Equipment RuntimeDataEquipment;
        
        public List<RuntimeData_RoleValueChanger> AllRoleValueChangers { get; private set; }
        
        public RuntimeData_Role  RoleRef  { get; private set; }
        public SaveData_BodyPart SaveData { get; private set; }

        public bool IsDisability => SaveData.IsDisability;

        public RuntimeData_BodyPart(RuntimeData_Role runtimeDataRole, SaveData_BodyPart saveData) {
            RoleRef  = runtimeDataRole;
            SaveData = saveData;

            AllRoleValueChangers = new List<RuntimeData_RoleValueChanger>();
            foreach (var saveDataRoleValueChanger in SaveData.AllRoleValueChanger) {
                AllRoleValueChangers.Add(new RuntimeData_RoleValueChanger(RoleRef, saveDataRoleValueChanger));
            }

            if (SaveData.SaveDataEquipment != null) {
                RuntimeDataEquipment = new RuntimeData_Equipment(this, SaveData.SaveDataEquipment);
            }
        }

        /// <summary>
        /// 进入伤残状态
        /// </summary>
        public void Disability() {
            if (SaveData.IsDisability) {
                return;
            }
            
            SaveData.IsDisability = true;
            foreach (var runtimeDataRoleValueChanger in AllRoleValueChangers) {
                runtimeDataRoleValueChanger.RunValueChanger();
            }

            OnDisabilityStateChanged.Invoke(IsDisability);
        }

        /// <summary>
        /// 从伤残状态恢复
        /// </summary>
        public void Recovery() {
            if (SaveData.IsDisability == false) {
                return;
            }
            
            SaveData.IsDisability = false;
            foreach (var runtimeDataRoleValueChanger in AllRoleValueChangers) {
                runtimeDataRoleValueChanger.ClearValueChangerData();
            }
            
            OnDisabilityStateChanged.Invoke(IsDisability);
        }
    }
}