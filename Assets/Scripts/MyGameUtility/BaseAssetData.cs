using UnityEngine;

namespace MyGameUtility {
    public class BaseAssetData : ScriptableObject {
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