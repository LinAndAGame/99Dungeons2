using MyGameUtility;
using Player;
using UnlockData.UnlockSystem;

namespace UnlockData.UnlockProcess {
    public abstract class SystemData_BaseUnlockProcess<T> {
        protected CacheCollection        CC = new CacheCollection();

        protected T                       DataOwner    { get; private set; }
        protected SystemData_UnlockSystem<T> UnlockSystem { get; private set; }
        public    SaveData_UnlockProcess  SaveData     { get; private set; }
        protected SystemData_BaseUnlockProcess(T dataOwner, SystemData_UnlockSystem<T> unlockSystem, SaveData_UnlockProcess saveDataUnlockProcess) {
            DataOwner    = dataOwner;
            UnlockSystem = unlockSystem;
            SaveData     = saveDataUnlockProcess;
        }

        protected void TryUnlock() {
            if (CheckIsUnlock()) {
                OtherUnlockHandle();
                CC.Clear();
                UnlockSystem.RemoveAndRuneNextUnlockProcess(this);
            }
        }
        
        protected virtual void OtherUnlockHandle(){ }

        protected abstract bool CheckIsUnlock();
    }
}