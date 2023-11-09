namespace MyGameUtility.ASM {
    public abstract class BaseState {
        protected CacheCollection CC = new CacheCollection();
        
        public virtual void OnEnterState() { }
        public virtual void OnStayState() { }

        public virtual void OnExitState() {
            CC.Clear();
        }
    }
}