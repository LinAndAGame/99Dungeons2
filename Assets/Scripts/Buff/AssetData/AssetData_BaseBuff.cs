using MyGameUtility;
using UnityEngine;

namespace Buff {
    public class AssetData_BaseBuff : ScriptableObject {
        [SerializeField]
        private string _ResourcePath;
        public string ResourcePath => _ResourcePath;
        
        private void OnValidate() {
            setResourcePath();

            void setResourcePath() {
                _ResourcePath = OtherUtility.GetResourcePath(this);
            }
        }
    }
}