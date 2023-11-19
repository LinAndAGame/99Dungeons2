using System;
using MyGameUtility;
using NewSkillCard;
using UnityEngine;

namespace NewRole {
    [Serializable]
    public class SaveData_Role {
        public SaveData_RoleValueCollection RoleValueCollectionInfo;
        public MinMaxValueFloat             Hp;
        public SaveData_CardBag             CardBag;

        [SerializeField]
        private string         AssetDataPath;
        public  AssetData_Role AssetData => Resources.Load<AssetData_Role>(AssetDataPath);
        
        public SaveData_Role() { }

        public SaveData_Role(AssetData_Role assetData) {
            AssetDataPath           = assetData.ResourcePath;
            RoleValueCollectionInfo = assetData.RoleValueCollectionInfo.Copy();
            CardBag                 = new SaveData_CardBag();
            Hp                      = new MinMaxValueFloat(0, AssetData.Hp, AssetData.Hp);
            foreach (AssetData_Card assetDataAllDefaultCard in AssetData.AllDefaultCards) {
                CardBag.DrawPile.AllCards.Add(new SaveData_Card(assetDataAllDefaultCard));
            }
        }
    }
}