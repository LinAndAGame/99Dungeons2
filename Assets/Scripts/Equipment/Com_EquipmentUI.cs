using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

namespace Equipment {
    public class Com_EquipmentUI : BaseComponent<ComGroup_Equipment> {
        public TextMeshPro    TMP_EquipmentName;
        public SpriteRenderer SR_Equipment;

        public Transform ParentTrans;

        public override void Init(ComGroup_Equipment comOwner) {
            base.Init(comOwner);
            RefreshUI(ComOwner.RuntimeData);
        }

        public void RefreshUI(RuntimeData_Equipment runtimeDataEquipment) {
            TMP_EquipmentName.text = runtimeDataEquipment.SaveData.AssetData.EquipmentName;
            SR_Equipment.sprite    = runtimeDataEquipment.SaveData.AssetData.SpriteEquipment;
            
            foreach (var roleValueChanger in runtimeDataEquipment.AllRoleValueChangers) {
                var ins = Instantiate(GameCommonAsset.I.ComRoleDataValueChangerPrefab, ParentTrans);
                ins.RefreshUI(roleValueChanger);
            }
        }
    }
}