namespace RandomValue.RandomEffect {
    public abstract class SaveData_BaseRandomValueEffectT<T> : SaveData_BaseRandomValueEffect where T : AssetData_BaseRandomValueEffect {
        public T AssetDataT => AssetData as T;

        protected SaveData_BaseRandomValueEffectT(T assetData) : base(assetData) { }
    }
}