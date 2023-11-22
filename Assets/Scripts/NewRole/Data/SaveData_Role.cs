using System;
using System.Collections.Generic;
using Card;
using MyGameUtility;
using UnityEngine;

namespace NewRole {
    [Serializable]
    public class SaveData_Role {
        public SaveData_RoleValueCollection RoleValueCollectionInfo;
        public MinMaxValueFloat             Hp;
        public SaveData_CardBag             CardBag;
        public List<SaveData_BodyPart>      AllBodyParts = new List<SaveData_BodyPart>();

        [SerializeField]
        private string         AssetDataPath;
        public  AssetData_Role AssetData => Resources.Load<AssetData_Role>(AssetDataPath);
        
        public SaveData_Role() { }

        public SaveData_Role(AssetData_Role assetData) {
            AssetDataPath           = assetData.ResourcePath;
            CardBag                 = new SaveData_CardBag();
            Hp                      = new MinMaxValueFloat(0, AssetData.Hp, AssetData.Hp);
            foreach (AssetData_Card assetDataAllDefaultCard in AssetData.AllDefaultAssetDataCards) {
                CardBag.DrawPile.AllCards.Add(new SaveData_Card(assetDataAllDefaultCard));
            }
            RoleValueCollectionInfo = new SaveData_RoleValueCollection(assetData.AssetDataRoleValueCollection);
            foreach (var assetDataAllAssetDataBodyPart in assetData.AllAssetDataBodyParts) {
                AllBodyParts.Add(new SaveData_BodyPart(assetDataAllAssetDataBodyPart));
            }
        }
    }
}