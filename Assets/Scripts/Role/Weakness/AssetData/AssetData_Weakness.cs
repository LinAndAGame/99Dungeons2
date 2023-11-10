using MyGameUtility;
using UnityEngine;

namespace Role {
    [CreateAssetMenu(fileName = "Weakness", menuName = "纯数据资源/Role/Weakness")]
    public class AssetData_Weakness : ScriptableObject {
        public WeaknessTypeEnum WeaknessType;
        public float            DefaultMaxValue;
        
        [SerializeField]
        private string _ResourcePath;
        public string ResourcePath => _ResourcePath;

        public SaveData_Weakness GetSaveData() {
            return new SaveData_Weakness(this);
        }
        
        private void OnValidate() {
            setResourcePath();

            void setResourcePath() {
                _ResourcePath = OtherUtility.GetResourcePath(this);
            }
        }
    }
}