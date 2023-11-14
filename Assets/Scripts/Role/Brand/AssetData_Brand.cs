using MyGameUtility;
using UnityEngine;

namespace Role.Brand {
    [CreateAssetMenu(fileName = "Brand", menuName = "纯数据资源/Role/Brand")]
    public class AssetData_Brand : BaseAssetData {
        public string             BrandName;
        public AssetData_Weakness AssetDataWeakness;
    }
}