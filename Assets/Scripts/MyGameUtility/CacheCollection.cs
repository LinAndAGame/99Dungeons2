namespace MyGameUtility {
    public class CacheCollection {
        public ValueCacheCollection  Value = new ValueCacheCollection();
        public CustomEventCollection Event = new CustomEventCollection();
        public BuffCollection        Buff  = new BuffCollection();

        public void Clear() {
            Value.Clear();
            Event.Clear();
            Buff.Clear();
        }
    }
}