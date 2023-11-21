namespace Card {
    public class BaseSaveDataT_CardEffect<T> : BaseSaveData_CardEffect where T : BaseAssetData_CardEffect {
        public T AssetDataT;

        public BaseSaveDataT_CardEffect(T assetDataT) : base(assetDataT) {
            AssetDataT = assetDataT;
        }
    }
}