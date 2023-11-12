using MyGameUtility;
using UnityEngine;
using Utility;

namespace Role {
    [CreateAssetMenu(fileName = "Weakness", menuName = "纯数据资源/Role/Weakness")]
    public class AssetData_Weakness : BaseAssetData {
        public WeaknessTypeEnum WeaknessType;
        public float            DefaultMaxValue;
        public string           DetailInfo;

        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.WeaknessSprite, WeaknessType.ToString());

        public SaveData_Weakness GetSaveData() {
            return new SaveData_Weakness(this);
        }
    }
}