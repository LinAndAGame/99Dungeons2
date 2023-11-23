using System;
using System.Collections.Generic;
using Card;
using MyGameUtility;
using NewRole;
using UnityEngine;

namespace Equipment {
    [CreateAssetMenu(fileName = "装备", menuName = "纯数据资源/装备")]
    public class AssetData_Equipment : BaseAssetData {
        public string                          EquipmentName;
        public Sprite                          SpriteEquipment;
        public AssetData_Card                  Card;
        public List<SaveData_RoleValueChanger> AllRoleValueChangers;
    }
}