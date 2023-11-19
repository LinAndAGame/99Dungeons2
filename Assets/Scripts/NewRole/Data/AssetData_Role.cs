using System.Collections.Generic;
using MyGameUtility;
using NewSkillCard;
using UnityEngine;

namespace NewRole {
    [CreateAssetMenu(fileName = "Role", menuName = "纯数据资源/NewRole/Role")]
    public class AssetData_Role : BaseAssetData {
        public string               RoleName;
        public Sprite               RoleSprite;
        public int                  Hp = 100;
        public List<AssetData_Card> AllDefaultCards;

        public SaveData_RoleValueCollection RoleValueCollectionInfo;
    }
}