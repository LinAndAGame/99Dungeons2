using System.Collections.Generic;
using Card;
using MyGameUtility;
using UnityEngine;

namespace NewRole {
    [CreateAssetMenu(fileName = "玩家", menuName = "纯数据资源/NewRole/玩家")]
    public class AssetData_Role : BaseAssetData {
        public string               RoleName;
        public Sprite               RoleSprite;
        public int                  Hp = 100;
        public List<AssetData_Card> AllDefaultCards;

        public SaveData_RoleValueCollection RoleValueCollectionInfo;
    }
}